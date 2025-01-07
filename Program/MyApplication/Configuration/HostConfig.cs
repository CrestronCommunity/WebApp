using MyApplication.SDK.Common;

namespace MyApplication.Configuration;

public sealed class HostConfig
{
    private readonly string _configurationPath = null!;
    public string Environment { get; init; } = null!;

    public string ConfigurationPath
    {
        get => _configurationPath.Replace("{APP_IDENTIFIER}", ApplicationEnvironment.AppIdentifier, StringComparison.Ordinal);
        init => _configurationPath = value;
    }
}