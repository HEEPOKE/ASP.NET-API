using app.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
});

var app = builder.Build();

if (app.Environment.IsDevelopment())    
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UsePathBase("/apis");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
