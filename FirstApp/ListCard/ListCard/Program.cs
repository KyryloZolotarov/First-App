using FluentValidation.AspNetCore;
using Infrastructure.Services.Interfaces;
using Infrastructure.Services;
using ListCard.Repositories;
using ListCard.Repositories.Interfaces;
using ListCard.Services;
using ListCard.Services.Interfaces;
using ListCard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Formatters;

var configuration = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AppSettings>(configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IListService, ListService>();
builder.Services.AddTransient<IListRepository, ListRepository>();
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddOptions();
builder.Services.AddMemoryCache();

builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
});

var app = builder.Build();

app.UseRouting();
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
