using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

builder.Logging.AddConsole();

builder.Logging.AddDebug();

builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration)
                .AddCacheManager(x => x.WithDictionaryHandle());

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRouting();

await app.UseOcelot();

app.Run();