using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyApplication.Configuration;
using MyApplication.SDK.Common;

namespace MyApplication.Services;

public sealed class ProgramService : BackgroundService
{
    private readonly ILogger<ProgramService> _logger;
    private readonly IControlSystemContext _controlSystemContext;

    private readonly HostConfig _hostConfig;

    public ProgramService(ILogger<ProgramService> logger, IOptions<HostConfig> hostConfig, IControlSystemContext controlSystemContext)
    {
        _logger = logger;
        _controlSystemContext = controlSystemContext;
        _hostConfig = hostConfig.Value;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _logger.LogInformation("Program service started");
            _logger.LogInformation("Control System: {ControlSystem}", _controlSystemContext.ControlSystem.ControllerPrompt);
            _logger.LogInformation("Configuration: {ConfigurationPath}", _hostConfig.ConfigurationPath);
        }
        catch (OperationCanceledException ex) when (ex.CancellationToken == stoppingToken)
        {
            // Ignore
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the program service");
        }

        return Task.CompletedTask;
    }
}