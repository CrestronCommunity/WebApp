﻿using System.Runtime;
using MyApplication.SDK.Common;
using Crestron.SimplSharp;
using Crestron.SimplSharpPro;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApplication.Configuration;
using MyApplication.Extensions;
using MyApplication.Services;
using Serilog;

namespace MyApplication;

public sealed class ControlSystem : CrestronControlSystem, IDisposable
{
    private readonly CrestronConsoleTextWriter _consoleWriter = new();
    private static readonly CancellationTokenSource _cancellationTokenSource = new();

    public ControlSystem()
    {
        Console.SetOut(_consoleWriter);
        GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
        Crestron.SimplSharpPro.CrestronThread.Thread.MaxNumberOfUserThreads = 400;
        CrestronEnvironment.ProgramStatusEventHandler += ProgramStatusEventHandler;
    }

    public override void InitializeSystem()
    {
        _ = Task.Run(async () =>
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
                await RunAsync(_cancellationTokenSource.Token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ErrorLog.Exception("An error occurred while running the application", ex);
            }
        });
    }

    private async Task RunAsync(CancellationToken token)
    {
        var builder = WebApplication.CreateBuilder();

        // Configure application configuration
        builder.Configuration.AddJsonFile("ProgramConfig.json", optional: false, reloadOnChange: false);
        builder.Configuration.AddJsonFile("ProgramConfig.Overrides.json", optional: true, reloadOnChange: false);

        // Configure Serilog
        builder.Host.UseSerilog((context, _, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration)
                .Enrich.WithProperty("AppId", ApplicationEnvironment.AppIdentifier)
                .Enrich.WithProperty("Version", ApplicationEnvironment.AppVersion.ToString(3));
        });

        // Configure services
        var services = builder.Services;
        {
            builder.Configure<HostConfig>("HostConfig");

            services.AddSingleton<IControlSystemContext, ControlSystemContext>(_ => new ControlSystemContext(this));

            services.Configure<HostOptions>(options =>
            {
                options.ServicesStartConcurrently = true;
                options.ServicesStopConcurrently = true;
            });

            services.AddHostedService<ProgramService>();

            services.AddEndpointsApiExplorer();
        }

        var app = builder.Build();
        {
            app.MapGet("/hello", () => "Hello world!")
                .WithName("GetHello")
                .WithOpenApi();

            app.Lifetime.ApplicationStarted.Register(() =>
            {
                foreach (var url in app.Urls)
                {
                    var port = new Uri(url).Port;
                    PortForwardFactory.TryCreateTcp(new PortForward(port));
                }
            });
        }

        await app.RunAsync(token).ConfigureAwait(false);
    }

    private void ProgramStatusEventHandler(eProgramStatusEventType eventType)
    {
        if (eventType != eProgramStatusEventType.Stopping)
            return;

        _cancellationTokenSource.Cancel();
        Dispose();
    }

    public void Dispose()
    {
        _consoleWriter.Dispose();
    }
}