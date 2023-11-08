using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Faactory.Extensions.AspNetCore;

/// <summary>
/// CORS extensions
/// </summary>
public static class CorsExtensions
{
    /// <summary>
    /// Configures public CORS policy (any origin, any method, any header)
    /// </summary>
    public static IServiceCollection ConfigureCorsDefaults( this IServiceCollection services )
    {
        services.AddCors( options =>
        {
            options.AddPolicy(
                "Public",
                p => p.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders( "Content-Disposition" )
            );
        } );

        return ( services );
    }

    /// <summary>
    /// Uses public CORS policy
    /// </summary>
    public static IApplicationBuilder UseCorsDefaults( this IApplicationBuilder app )
        => app.UseCors( "Public" );
}
