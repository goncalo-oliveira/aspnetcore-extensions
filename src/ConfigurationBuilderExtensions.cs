using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Faactory.Extensions.AspNetCore;

/// <summary>
/// Extension methods for <see cref="IConfigurationBuilder"/>
/// </summary>
public static class ConfigurationBuilderExtensions
{
    /// <summary>
    /// Adds environment variables and config.json if in development mode
    /// </summary>
    public static IConfigurationBuilder AddDefaults( this IConfigurationBuilder builder, IHostEnvironment env )
    {
        builder.AddEnvironmentVariables();

        if ( env.IsDevelopment() )
        {
            builder.AddJsonFile( "config.json", optional: true, reloadOnChange: false );
        }

        return ( builder );
    }
}
