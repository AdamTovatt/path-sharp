using PathSharp.Models.Dto;
using PathSharp.Models.QueryParameters;

namespace PathSharpTests
{
    [TestClass]
    public class ClientTests
    {
        private TestSecrets? secrets;
        private PathClient? client;

        public ClientTests()
        {
            try
            {
                TestSecrets? readSecrets = TestSecrets.Read();

                if (readSecrets == null || !readSecrets.HasBeenSet) // hasBeenSet needs to be set to true in the secrets file so that we know that someone has used it
                {
                    throw new ArgumentNullException("Test secrets have not been specified. Should be a text file called TestSecrets.txt in the same directory as this executable");
                }

                secrets = readSecrets;
            }
            catch
            {
                TestSecrets.WriteEmpty();
                throw new Exception("Error when reading test secrets. They should be in a text file called TestSecrets.txt in the same directory as this executable. An empty test secrets file has been created");
            }

            if (secrets != null && secrets.OrchestratorAddress != null && secrets.OrganizationUnitId != null)
                client = new PathClient(RequestAddress.Base.Default, secrets.OrchestratorAddress, secrets.OrganizationUnitId);
        }

        [TestMethod]
        public async Task Authorize()
        {
            Assert.IsNotNull(secrets, "Secrets have been read the wrong way");
            Assert.IsNotNull(secrets.OrchestratorAddress, "Secrets are missing orchestratorAddress");
            Assert.IsNotNull(secrets.ClientSecret, "Secrets are missing clientSecret");
            Assert.IsNotNull(secrets.ClientId, "Secrets are missing clientId");
            Assert.IsNotNull(secrets.OrganizationUnitId, "Secrets are missing organizationUnitId");

            if (!secrets.ShouldTestAgainstApi) // only run this test if we should test against the api
                return;

            using (PathClient pathClient = new PathClient(RequestAddress.Base.Default, secrets.OrchestratorAddress, secrets.OrganizationUnitId))
            {
                await pathClient.AuthorizeAsync(secrets.ClientSecret, secrets.ClientId, PathClient.DefaultScope);

                Assert.IsNotNull(pathClient.Token);
            }
        }

        [TestMethod]
        public async Task GetJobs()
        {
            Assert.IsNotNull(secrets, "Secrets have been read the wrong way");
            Assert.IsNotNull(secrets.OrchestratorAddress, "Secrets are missing orchestratorAddress");
            Assert.IsNotNull(secrets.ClientSecret, "Secrets are missing clientSecret");
            Assert.IsNotNull(secrets.ClientId, "Secrets are missing clientId");

            if (!secrets.ShouldTestAgainstApi) // only run this test if we should test against the api
                return;

            Assert.IsNotNull(client, "Client was null when testing, this should not be happening");

            if (!client.IsAuthorized)
                await client.AuthorizeAsync(secrets.ClientSecret, secrets.ClientId, PathClient.DefaultScope);

            GetJobsParameters parameters = new GetJobsParameters()
            {
                Skip = 2,
                Top = 10
            };

            List<Job>? jobs = await client.GetJobsAsync(parameters);

            Assert.IsNotNull(jobs);
            Assert.AreEqual(10, jobs.Count);
            Assert.IsNotNull(jobs.First().CreationTime);
        }
    }
}