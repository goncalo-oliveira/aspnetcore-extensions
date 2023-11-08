using Faactory.Extensions.AspNetCore;

var builder = WebApplication.CreateBuilder( args );

/*
Configuration defaults
- config.json on development environments
- environment variables
*/
builder.Configuration.AddDefaults( builder.Environment );

/*
Logging defaults
- console provider with single line formatter and timestamp
- filters for common noisy loggers (set to Warning)
*/
builder.Logging.AddDefaults();

/*
Json serialization defaults for minimal APIs
- camelCase naming policy
- case insensitive property name matching
- ignore null values when writing
- string enum converter
*/
builder.Services.ConfigureJsonDefaults();

/*
Kestrel defaults
- listen on ports 8080 and 8081
*/
builder.WebHost.UseKestrel( new int[] { 8080, 8081 }, options =>
{
    options.Limits.MaxRequestBodySize = 9 * 1024 * 1024;
} );

/*
Forwarded headers defaults
- X-Forwarded-Host
- X-Forwarded-Proto
*/
builder.Services.ConfigureForwardedHeaders();

/*
CORS defaults
- allow all origins
- allow all methods
- allow all headers
- expose Content-Disposition header
*/
builder.Services.ConfigureCorsDefaults();

/*
The above can be replaced with just

var builder = WebApplication.CreateBuilder( args ).WithDefaults();

The above does not include any MVC related defaults, such as:
    - IMvcBuilder.AddJsonDefaults()
*/

/*
Runtime
*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseDeveloperExceptionPage();
}

app.UseForwardedHeaders();
app.UseCorsDefaults();

app.MapGet( "/", () => "Hello World!" );

app.Run();
