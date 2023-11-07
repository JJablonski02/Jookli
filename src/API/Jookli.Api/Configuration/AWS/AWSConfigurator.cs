using Amazon.Runtime;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.SimpleSystemsManagement;
using Amazon;

namespace Jookli.Api.Configuration.AWS
{
    public static class AWSConfigurator
    {
        public async static Task<IConfiguration> ConfigureBuilderAsync(IConfigurationBuilder builder)
        {
            var client = new AmazonSimpleSystemsManagementClient(RegionEndpoint.EUNorth1);

            var request = new GetParameterRequest()
            {
                Name = $"/development/JookliApi/ConnectionString"
            };

            var value = await client.GetParameterAsync(request: request);

            builder.AddInMemoryCollection(new Dictionary<string, string>
            {
                {"JookliConnectionString", value.Parameter.Value}
            });

            var configuration = builder.Build();

            return configuration;
        }
    }
}
