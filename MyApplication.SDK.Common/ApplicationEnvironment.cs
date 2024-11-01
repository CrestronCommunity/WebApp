using System.Globalization;
using System.Reflection;
using Crestron.SimplSharp;

namespace MyApplication.SDK.Common;

public static class ApplicationEnvironment
{
    private static Version? _programVersion;

    public static string AppIdentifier
        => IsRunningOnServer
            ? InitialParametersClass.RoomId
            : InitialParametersClass.ApplicationNumber.ToString("D2", CultureInfo.InvariantCulture);

    public static Version AppVersion => _programVersion ??= Assembly.GetExecutingAssembly().GetName().Version!;

    public static bool IsRunningOnServer
        => CrestronEnvironment.DevicePlatform == eDevicePlatform.Server;

    public static string ProgramDirectory => AppDomain.CurrentDomain.BaseDirectory;

    public static bool HasRouter()
        => InitialParametersClass.IsRouterPresent;

    public static string PromptName
        => IsRunningOnServer ? "VC-4" : InitialParametersClass.ControllerPromptName;

    public static string GetPath(string path)
    {
        var separator = Path.DirectorySeparatorChar;
        return Path.Combine(Crestron.SimplSharp.CrestronIO.Directory.GetApplicationRootDirectory().TrimEnd(separator) + separator, path.TrimStart(separator));
    }
}