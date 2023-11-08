using Microsoft.AspNetCore.Builder;

namespace Faactory.Extensions.AspNetCore;

public static class ApplicationBuilderDefaultsExtensions
{
    public static WebApplicationBuilder WithDefaults( this WebApplicationBuilder builder )
    {
        // logging
        builder.Logging.AddDefaults();

        // configuration
        builder.Configuration.AddDefaults( builder.Environment );

        // json serialization for minimal apis
        builder.Services.ConfigureJsonDefaults();

        // Kestrel
        builder.WebHost.UseKestrel( new int[] { 8080, 8081 } );

        // forwarded headers
        builder.Services.ConfigureForwardedHeaders();
        builder.Services.ConfigureCorsDefaults();

        return ( builder );
    }
}
