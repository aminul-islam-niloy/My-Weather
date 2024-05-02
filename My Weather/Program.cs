using Microsoft.OpenApi.Models;
using My_Weather.Models;
using My_Weather.Services;

var builder = WebApplication.CreateBuilder(args);

// Add configuration for OpenWeatherMap
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Configure WeatherSettings
var weatherSettings = builder.Configuration.GetSection("OpenWeatherMap").Get<WeatherSettings>();
builder.Services.Configure<WeatherSettings>(builder.Configuration.GetSection("OpenWeatherMap"));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<WeatherService>();
builder.Services.AddScoped<HttpClient>();



// Configure Swagger
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Weather API", Version = "v1" });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Weather API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
