using Microsoft.Extensions.Configuration;

namespace MyApplication;

public static class ConfigurationExtensions
{
    public static T GetSectionOrThrow<T>(this IConfiguration configuration, string sectionKey)
    {
        var config = configuration.GetRequiredSection(sectionKey).Get<T>();
        return config ?? throw new ConfigSectionIsNullException(sectionKey);
    }
}