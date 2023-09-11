using System;
using System.IO;

using Microsoft.Extensions.Configuration;

using Serilog;

namespace ConsoleUI
{
    static class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                             .ReadFrom.Configuration(builder.Build())
                             .Enrich.FromLogContext()
                             .WriteTo.Console()
                             .CreateLogger();
            
            Log.Logger.Information("Application Starting...");
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true)
                   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                   .AddEnvironmentVariables();
        }
    }
}