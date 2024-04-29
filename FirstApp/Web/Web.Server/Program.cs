using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Web.Server;

var configuration = GetConfiguration();
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AppSettings>(configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddControllers();
builder.Services.AddOptions();
builder.Services.AddMemoryCache();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("https://localhost:5173") // React app address
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
});

app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true)
        .AddEnvironmentVariables();

    return builder.Build();
}
