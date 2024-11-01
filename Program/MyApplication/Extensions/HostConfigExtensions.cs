using MyApplication.Configuration;

namespace MyApplication.Extensions;

public static class HostConfigExtensions
{
    public static bool IsDevelopment(this HostConfig config)
        => string.Equals(config.Environment, "Development", StringComparison.OrdinalIgnoreCase);

    public static bool IsStaging(this HostConfig config)
        => string.Equals(config.Environment, "Staging", StringComparison.OrdinalIgnoreCase);

    public static bool IsProduction(this HostConfig config)
        => string.Equals(config.Environment, "Production", StringComparison.OrdinalIgnoreCase);
}