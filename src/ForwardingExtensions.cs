using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;

namespace Faactory.Extensions.AspNetCore;

/// <summary>
/// Forwarding extensions
/// </summary>
public static class ForwardingExtensions
{
    /// <summary>
    /// Configures forwarded headers (default is X-Forwarded-Host and X-Forwarded-Proto)
    /// </summary>
    public static IServiceCollection ConfigureForwardedHeaders( this IServiceCollection services, Action<ForwardedHeadersOptions>? configure = null )
    {
        services.Configure<ForwardedHeadersOptions>( options =>
        {
            options.ForwardedHeaders = 
                ForwardedHeaders.XForwardedHost | ForwardedHeaders.XForwardedProto;

            configure?.Invoke( options );
        } );

        return ( services );
    }
}
