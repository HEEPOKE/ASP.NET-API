using System.Reflection;
using app.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DB_CONNECT"));
});

builder.Services.AddScoped<DbContext, DataContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EXAMPLE API",
        Description = "An ASP.NET Core Web API for learning",
        TermsOfService = new Uri("https://github.com/HEEPOKE"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://github.com/HEEPOKE")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
    options.OperationFilter<SecurityRequirementsOperationFilter>(true, "Bearer");
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (JWT). Example: \"bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");

    c.ConfigObject.AdditionalItems["filter"] = true;
    c.ConfigObject.AdditionalItems["docExpansion"] = "list";
});
}

app.UsePathBase("/apis");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
