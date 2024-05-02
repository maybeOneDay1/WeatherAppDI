using WeatherServiceContracts;
using WeatherServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddMvc();

var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();
