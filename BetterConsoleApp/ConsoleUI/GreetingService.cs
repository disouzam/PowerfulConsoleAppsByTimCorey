using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsoleUI
{
    public class GreetingService : IGreetingService
    {
        private readonly ILogger<GreetingService> log;

        private readonly IConfiguration config;

        public GreetingService(ILogger<GreetingService> log, IConfiguration config)
        {
            this.log=log;
            this.config=config;
        }

        public void Run()
        {
            for (int i = 0; i < config.GetValue<int>("LoopTimes"); i++)
            {
                log.LogInformation("Run number {runNumber}", i);
            }
        }
    }
}