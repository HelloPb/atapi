using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace atapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                var builtConfig = config.Build();

                if (context.HostingEnvironment.IsDevelopment())
                {
                    config.AddAzureKeyVault(
                        $"https://atkey.vault.azure.net/keys/at",
                        "9cea0a51-bf38-4900-a8db-ef04a4ad59ec",
                        "p7aEUuH/zGssz5G/pYaa7Iiek/8AskkrpmCyIfuEIv4=");

                }
                else if (context.HostingEnvironment.IsStaging())
                {
                    config.AddAzureKeyVault(
                        $"https://atkey.vault.azure.net/keys/at",
                        "9cea0a51-bf38-4900-a8db-ef04a4ad59ec",
                        "p7aEUuH/zGssz5G/pYaa7Iiek/8AskkrpmCyIfuEIv4=");

                }
                else if (context.HostingEnvironment.IsProduction())
                {
                    config.AddAzureKeyVault(
                        $"https://atkey.vault.azure.net/keys/at",
                        "9cea0a51-bf38-4900-a8db-ef04a4ad59ec",
                        "p7aEUuH/zGssz5G/pYaa7Iiek/8AskkrpmCyIfuEIv4=");
                }
                else
                {
                    config.AddAzureKeyVault(
                        $"https://atkey.vault.azure.net/keys/at",
                        "9cea0a51-bf38-4900-a8db-ef04a4ad59ec",
                        "p7aEUuH/zGssz5G/pYaa7Iiek/8AskkrpmCyIfuEIv4=");
                }

                builtConfig = config.Build();

            }).UseStartup<Startup>();
    }
}
