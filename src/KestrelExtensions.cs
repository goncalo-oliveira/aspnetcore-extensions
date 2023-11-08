using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Faactory.Extensions.AspNetCore;

/// <summary>
/// Kestrel extensions
/// </summary>
public static class KestrelExtensions
{
    /// <summary>
    /// Configures Kestrel to listen on the specified ports
    /// </summary>
    public static IWebHostBuilder UseKestrel( this IWebHostBuilder builder, int[] ports, Action<KestrelServerOptions>? configure = null )
    {
        if ( !ports.Any() )
        {
            throw new ArgumentException( "At least one port must be specified.", nameof( ports ) );
        }

        var urls = ports.Select( port => $"http://*:{port}" )
            .ToArray();

        builder.UseKestrel( options =>
        {
            configure?.Invoke( options );
        } )
        .UseUrls(
            ports.Select( port => $"http://*:{port}" ).ToArray()
        );

        return ( builder );        
    }
}
