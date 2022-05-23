using System;

namespace ReportPortal.Client.IntegrationTests
{
    public class BaseFixture
    {
        protected static readonly string Username = "default";
        protected static readonly string ProjectName = "aleh-yanushkevich_personal";
        protected readonly Service Service = new Service(new Uri("https://demo.reportportal.io/api/v1"), ProjectName, "221be394-5d2d-4252-9d6f-365a0b1c9816");

        //protected static readonly string Username = "default";
        //protected static readonly string ProjectName = "default_personal";
        //protected readonly Service Service = new Service(new Uri("http://localhost:8080/api/v1"), ProjectName, "694b1c68-a3dd-4fd5-a752-8cd233cb2733");
    }
}
