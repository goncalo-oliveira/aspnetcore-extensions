# Extensions for ASPNET projects

This project provides some shortcuts to configure ASPNET projects with common defaults for micro-apis.

## Getting Started

Install the package from NuGet:

```bash
dotnet add package Faactory.Extensions.AspNetCore
```

## Usage

After installing, use the following code to configure the defaults:

```csharp
var builder = WebApplication.CreateBuilder( args )
    .WithDefaults();

var app = builder.Build();

if ( app.Environment.IsDevelopment() )
{
    app.UseDeveloperExceptionPage();
}

app.UseForwardedHeaders();
app.UseCorsDefaults();

app.MapGet( "/", () => "Hello World!" );

app.Run();
```

The above automatically configures the following:

- Environment variables configuration
- Json configuration mapping from `config.json` on development environment
- Logging with console provider
- Json serialization for minimal APIs
- Kestrel defaults on ports 8080 and 8081
- Forwarded headers middleware
- CORS middleware with the following defaults:
  - Allow any origin
  - Allow any header
  - Allow any method
  - Exposes headers `Content-Disposition`

Alternatively, the defaults can added one be one. See the example folder for more details.

###  Json serialization on MVC

The defaults explained so far are for minimal APIs. If you are using MVC controllers, you can configure the defaults with the following code:

```csharp
builder.Services.AddControllers()
    .AddJsonDefaults();
```

### Forwarded headers

Using the defaults, the headers processed are `X-Forwarded-Host` and `X-Forwarded-Proto`. This behaviour can be overriden by using the following code:

```csharp
builder.Services.ConfigureForwardedHeaders( options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedHost | ForwardedHeaders.XForwardedFor;
} );
```

### Kestrel

When using the defaults, Kestrel is configured to listen on ports 8080 and 8081. To set up individually, or to extend the behaviour use the following:

```csharp
builder.WebHost.UseKestrel( new int[] { 8080, 8081 }, options =>
{
    // use a maximum request body size of 3mb
    options.Limits.MaxRequestBodySize = 3 * 1024 * 1024;
} );
```
