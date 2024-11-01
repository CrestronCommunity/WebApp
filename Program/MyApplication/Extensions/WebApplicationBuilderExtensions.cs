using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MyApplication.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder Configure<T>(this WebApplicationBuilder builder, string sectionKey)
        where T : class
    {
        builder.Services.Configure<T>(builder.Configuration.GetSection(sectionKey));
        return builder;
    }
}