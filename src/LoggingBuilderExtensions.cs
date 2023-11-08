using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Faactory.Extensions.AspNetCore;

/// <summary>
/// Logging builder extensions
/// </summary>
public static class LoggingBuilderExtensions
{
    /// <summary>
    /// Configures default logging options
    /// </summary>
    public static ILoggingBuilder AddDefaults( this ILoggingBuilder builder, Action<SimpleConsoleFormatterOptions>? configure = null )
    {
        builder.ClearProviders()
            .AddSimpleConsole( options =>
            {
                options.SingleLine = true;
                options.IncludeScopes = true;

                configure?.Invoke( options );
            } )
            .AddFilter( "Microsoft.AspNetCore.Http.Result", LogLevel.Warning )
            .AddFilter( "Microsoft.AspNetCore.Routing.EndpointMiddleware", LogLevel.Warning )
            .AddFilter( "Microsoft.AspNetCore.Cors.Infrastructure", LogLevel.Warning )
            .AddFilter( "Microsoft.AspNetCore.Mvc.Infrastructure", LogLevel.Warning )
            .AddFilter( "System.Net.Http.HttpClient.*.LogicalHandler", LogLevel.Warning )
            ;

        return ( builder );
    }
}
