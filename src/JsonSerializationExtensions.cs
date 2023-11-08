using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace Faactory.Extensions.AspNetCore;

/// <summary>
/// JSON serialization extensions
/// </summary>
public static class JsonSerializationExtensions
{
    /// <summary>
    /// Configures default options used for reading and writing JSON with minimal APIs
    /// </summary>
    public static IServiceCollection ConfigureJsonDefaults( this IServiceCollection services )
    {
        services.ConfigureHttpJsonOptions( options => ConfigureJsonDefaults( options.SerializerOptions ) );

        return ( services );
    }

    /// <summary>
    /// Configures default options used for reading and writing JSON with MVC
    /// </summary>
    public static IMvcBuilder AddJsonDefaults( this IMvcBuilder builder )
        => builder.AddJsonOptions( options => ConfigureJsonDefaults( options.JsonSerializerOptions ) );

    private static void ConfigureJsonDefaults( JsonSerializerOptions options )
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.PropertyNameCaseInsensitive = true;
        options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        options.Converters.Add( new JsonStringEnumConverter( JsonNamingPolicy.CamelCase, false ) );
    }
}
