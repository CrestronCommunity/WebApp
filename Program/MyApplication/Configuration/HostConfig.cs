namespace MyApplication.Configuration;

public sealed class HostConfig
{
    public string Environment { get; init; } = null!;
    public string ConfigurationPath { get; init; } = null!;
}