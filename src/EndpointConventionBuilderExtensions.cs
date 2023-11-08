using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Faactory.Extensions.AspNetCore;

/// <summary>
/// Extension methods for <see cref="IEndpointConventionBuilder"/>
/// </summary>
public static class EndpointConventionBuilderLocalExtensions
{
    /// <summary>
    /// Requires that the local port matches the specified port.
    /// </summary>
    public static IEndpointConventionBuilder RequireLocalPort( this IEndpointConventionBuilder builder, int port )
        => builder.AddEndpointFilter( async ( context, next ) =>
        {
            if ( context.HttpContext.Connection.LocalPort != port )
            {
                return Results.NotFound();
            }

            return await next( context );
        } );
}
