using Amazon.Runtime;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.SimpleSystemsManagement;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json;

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

            try
            {
                var value = await client.GetParameterAsync(request: request);

                builder.AddInMemoryCollection(new Dictionary<string, string>
            {
                {"JookliConnectionString", value.Parameter.Value}
            });
            }
            catch (Exception ex)
            {

            }


            var secret = "development/stripe/secret";

            IAmazonSecretsManager secretClient = new AmazonSecretsManagerClient(RegionEndpoint.EUNorth1);

            GetSecretValueRequest secretRequest = new GetSecretValueRequest
            {
                SecretId = secret,
                VersionStage = "AWSCURRENT"
            };

            GetSecretValueResponse secretResponse;

            try
            {
                secretResponse = await secretClient.GetSecretValueAsync(secretRequest);
                builder.AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "StripeSecret" , secretResponse.SecretString }
                });
            }
            catch (Exception ex)
            {
            }

            var configuration = builder.Build();

            return configuration;
        }
    }
}
