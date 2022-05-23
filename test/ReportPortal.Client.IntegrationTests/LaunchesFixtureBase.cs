using ReportPortal.Client.Abstractions.Models;
using ReportPortal.Client.Abstractions.Requests;
using ReportPortal.Client.Abstractions.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ReportPortal.Client.IntegrationTests
{
    public class LaunchesFixtureBase : BaseFixture, IAsyncLifetime
    {
        private List<LaunchCreatedResponse> CreatedLaunches { get; } = new List<LaunchCreatedResponse>();

        public async Task InitializeAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                var createdLaunch = await Service.Launch.StartAsync(new StartLaunchRequest
                {
                    Name = "LaunchItemFixture",
                    StartTime = DateTime.UtcNow,
                    Mode = LaunchMode.Default
                });

                await Service.Launch.FinishAsync(createdLaunch.Uuid, new FinishLaunchRequest
                {
                    EndTime = DateTime.UtcNow
                });

                CreatedLaunches.Add(createdLaunch);
            }
        }

        public async Task DisposeAsync()
        {
            foreach (var createdLaunch in CreatedLaunches)
            {
                var gotCreatedLaunch = await Service.Launch.GetAsync(createdLaunch.Uuid);

               await Service.Launch.DeleteAsync(gotCreatedLaunch.Id);
            }
        }
    }
}
