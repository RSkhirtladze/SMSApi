using SMSApi.API.Middleware;
using SMSApi.App.SmsProviders;
using SMSApi.Application.Interfaces;
using SMSApi.Application.Services;
using SMSApi.Domain.Interfaces;
using SMSApi.Domain.Services;
using SMSApi.Infrastructure.Providers.Interfaces;
using SMSApi.Infrastructure.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Graylog;
using SMSApi;
using SMSApi.Application.ProviderSelectors;
using Amazon.SecretsManager;

var builder = WebApplication.CreateBuilder(args);

#region Reading configurations

builder.Configuration.AddJsonFile("appsettings.json");

//Read configuratios from env variables
//(deploying on k8s cluster pod will result in easily maintining, changing and updating this configurations)
//Compared to aws secret manager has disadvantage of being less secure and open to everyone who has access
//to that cluster tho(mainly developers)


/// builder.Configuration.AddEnvironmentVariables();

//2) Read configuration from aws secret manager
// has advantage of being much more secure and we have luxury to be able to change from Hertzner to Google cloud service
//without worrying about lossing config maps.
// (has disadvatage of being not free tho :d )
//system has to be authenticated with aws account
//note: we could also change f.e IOptions<SMSProviderConfigs>  to IOptionsMonitor<SMSProviderConfigs> 
// => if our aws secret manager has support for updating values on the fly (we would not have to reload application)

///builder.Configuration.AddSecretsManager(configurator: options =>
///{
///    options.SecretFilter = entry =>
///        entry.Name.StartsWith($"{builder.Environment.EnvironmentName}_{builder.Environment.ApplicationName}_");
///    options.KeyGenerator = (_, s) => s
///        .Replace("{env}_{appName}_", string.Empty)
///        .Replace("__", ":");
///});

#endregion


// Add services to the container.

var smsApiConfig = builder.Configuration.GetSection("SMSApiConfig").Get<SMSApiConfig>();
//Configure providers configuration
builder.Services.Configure<SMSProviderConfigs>(builder.Configuration.GetSection("SMSApiConfig:SMSProviderConfigs"));

#if !Debug
Log.Logger = new LoggerConfiguration()
    .WriteTo.Graylog(
        smsApiConfig.LoggerConfig.GrayLogAddress,
        smsApiConfig.LoggerConfig.GrayLogPort,
        Serilog.Sinks.Graylog.Core.Transport.TransportType.Http)
    .Filter.ByExcluding(logEvent => logEvent.Level == Serilog.Events.LogEventLevel.Information)
    .CreateLogger();

builder.Logging.AddSerilog();
#endif   

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register applications services and dependencies


builder.Services.AddSingleton<ISMSService, SMSService>();
builder.Services.AddSingleton<ISMSDomainService, SMSDomainService>();
builder.Services.AddSingleton<ISMSProvider, MagtiProvider>();
builder.Services.AddSingleton<ISMSProvider, GeocellProvider>();
builder.Services.AddSingleton<ISMSProvider, TwilioProvider>();

//პირველი ვარიანტი რომელიც დაგვჭირდება ეგ გვექწნება ოლმე დაინჯექთებული თუ ეგ იგულისხმება მარტივად გამოცვლაში
//builder.Services.AddSingleton<IProviderSelector, RandomProviderSelector>();
builder.Services.AddSingleton<IProviderSelector, ProviderSelectorByPercentage>();

//ვერ მივხვდი ზუსტად რა იყო ნაგულისხმევი, ამიტომ მეორე ალტერნატივად ასეც შეიძლებოდა და მერე სადაც დაგვჭირდებოდა
//Func<string, IProviderSelector> providerSelectorFactoryს დავაინჯექთებდით და შესაბამისი ქით შესაბამის 
// სელექტორს მოგვემდა მაგრამ რაღაცა გავართულე მგონი და პირობაში ალბათ უფრო მარტივი და სხვა რამეა ნაგულისხმევი :დ
/*builder.Services.AddSingleton<RandomProviderSelector>();
builder.Services.AddSingleton<ProviderSelectorByPercentage>();

builder.Services.AddSingleton<Func<string, IProviderSelector>>(serviceProvider => (key) =>
{
    switch (key)
    {
        case "Random":
            return serviceProvider.GetService<RandomProviderSelector>();
        case "Percent":
            return serviceProvider.GetService<ProviderSelectorByPercentage>();
        default:
            throw new ArgumentException($"Provider selector '{key}' not recognized.");
    }
});*/




var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
