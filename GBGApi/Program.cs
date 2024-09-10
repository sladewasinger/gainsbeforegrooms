using GBGApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
ConfigureMiddleware(app);

// Configure endpoints and start the app
ConfigureEndpoints(app);

app.Run();

// Method to configure services (Dependency Injection, etc.)
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Add Controllers
    services.AddControllers();

    // Add Swagger for API documentation
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please insert JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }});
    });

    // Add JWT Authentication
    var jwtKey = builder.Configuration["JwtKey"];
    var jwtIssuer = builder.Configuration["JwtIssuer"];

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtIssuer,
                ValidAudience = jwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
            };
        });

    // Add Authorization (optional if you want to authorize some endpoints)
    services.AddAuthorization();

    // Add other services, like EF Core or repositories, here
}

// Method to configure middleware (HTTP pipeline)
void ConfigureMiddleware(WebApplication app)
{
    // Development-specific middleware
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
    }

    // Middleware for HTTPS redirection and routing
    app.UseHttpsRedirection();
    app.UseRouting();

    // Authentication and Authorization Middleware
    app.UseAuthentication();  // Ensure authentication is applied before authorization
    app.UseAuthorization();

    // Other middlewares, e.g., CORS or static files, can be added here
}

// Method to configure endpoints (API routes)
void ConfigureEndpoints(WebApplication app)
{
    // Map Controllers for API routes
    app.MapControllers();

    // More endpoint mappings (like gRPC, SignalR, etc.) can go here
}