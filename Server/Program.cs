global using Server.Models;
global using Server.Interfaces;
global using Server.Services;
global using Server.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Database>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductInterface, ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
