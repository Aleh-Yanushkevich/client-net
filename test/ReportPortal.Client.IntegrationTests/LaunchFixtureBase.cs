using ReportPortal.Client.Abstractions.Requests;
using System;
using System.Threading.Tasks;
using Xunit;

[assembly: CollectionBehavior(MaxParallelThreads = -1)]

namespace ReportPortal.Client.IntegrationTests
{
    public class LaunchFixtureBase : BaseFixture, IAsyncLifetime
    {
        public long LaunchId { get; set; }
        public string LaunchUuid { get; set; }

        public async Task InitializeAsync()
        {
            LaunchUuid = Service.Launch.StartAsync(new StartLaunchRequest
            {
                Name = "StartFinishDeleteLaunch",
                StartTime = DateTime.UtcNow
            }).GetAwaiter().GetResult().Uuid;

            LaunchId = (await Service.Launch.GetAsync(LaunchUuid)).Id;
        }

        public async Task DisposeAsync()
        {
            await Service.Launch.StopAsync(LaunchId, new FinishLaunchRequest { EndTime = DateTime.UtcNow });
            await Service.Launch.DeleteAsync(LaunchId);
        }
    }
}
