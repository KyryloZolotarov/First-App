using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Web.Server;
using Web.Server.Repositories;
using Web.Server.Repositories.Interfaces;
using Web.Server.Services;
using Web.Server.Services.Interfaces;

var configuration = GetConfiguration();
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AppSettings>(configuration);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<IListService, ListService>();
builder.Services.AddTransient<IListRepository, ListRepository>();
builder.Services.AddTransient<IHistoryService, HistoryService>();
builder.Services.AddTransient<IHistoryRepository, HistoryRepository>();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
});
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
builder.Services.AddAuthentication("CookieAuth")
            .AddCookie("CookieAuth", options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.Name = "YourAuthCookieName";
                options.Cookie.HttpOnly = false;
                // options.ExpireTimeSpan = ...
                // options.LoginPath = ...
                // options.LogoutPath = ...
            });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CookieAuth", policy =>
    {
        policy.AuthenticationSchemes.Add("CookieAuth");
        policy.RequireAuthenticatedUser();
        // Дополнительные требования
    });
});
var app = builder.Build();

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
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

public static class MyJPIF
{
    public static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
    {
        var builder = new ServiceCollection()
            .AddLogging()
            .AddMvc()
            .AddNewtonsoftJson()
            .Services.BuildServiceProvider();

        return builder
            .GetRequiredService<IOptions<MvcOptions>>()
            .Value
            .InputFormatters
            .OfType<NewtonsoftJsonPatchInputFormatter>()
            .First();
    }
}
