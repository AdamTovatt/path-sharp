using PathSharp.Constants;
using PathSharp.Models.Dto;
using PathSharp.Models.QueryParameters;
using PathSharp.Models.RequestBodies;

namespace PathSharpTests
{
    [TestClass]
    public class ClientTests
    {
        private TestSecrets? secrets;
        private PathClient? client;

        public ClientTests() // this is the constructor, it will read the secrets file and create a client
        {
            try
            {
                TestSecrets? readSecrets = TestSecrets.Read(); // the secrets are needed to test the requets against the api

                if (readSecrets == null || !readSecrets.HasBeenSet) // hasBeenSet needs to be set to true in the secrets file so that we know that someone has used it
                {
                    throw new ArgumentNullException("Test secrets have not been specified. Should be a text file called TestSecrets.txt in the same directory as this executable");
                }

                secrets = readSecrets;
            }
            catch (Exception exception)
            {
                if (exception.GetType() == typeof(FileNotFoundException))
                    TestSecrets.WriteEmpty();

                throw new Exception("Error when reading test secrets. They should be in a text file called TestSecrets.txt in the same directory as this executable. An empty test secrets file has been created");
            }

            if (secrets != null && secrets.OrchestratorAddress != null && secrets.OrganizationUnitId != null)
                client = new PathClient(RequestAddress.Base.Default, secrets.OrchestratorAddress);
            else
                throw new Exception("Did not create new client because one of the required values were missing");
        }

        /// <summary>
        /// Will test that the client can authorize against the api
        /// </summary>
        /// <returns></returns>
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

            using (PathClient pathClient = new PathClient(RequestAddress.Base.Default, secrets.OrchestratorAddress))
            {
                await pathClient.AuthorizeAsync(secrets.ClientSecret, secrets.ClientId, PathClient.DefaultScope);

                Assert.IsNotNull(pathClient.Token);
                Assert.IsTrue(pathClient.IsAuthorized);
            }
        }

        /// <summary>
        /// Will test both that the client can get a list of jobs and that it can get a single job
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetJobs()
        {
            Assert.IsNotNull(secrets, "Secrets have been read the wrong way");
            Assert.IsNotNull(secrets.OrchestratorAddress, "Secrets are missing orchestratorAddress");
            Assert.IsNotNull(secrets.ClientSecret, "Secrets are missing clientSecret");
            Assert.IsNotNull(secrets.ClientId, "Secrets are missing clientId");
            Assert.IsNotNull(secrets.OrganizationUnitId, "Secrets are missing OrganizationUnitId, it is needed for running the get jobs test");

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

            List<Job>? jobs = await client.GetJobsAsync(secrets.OrganizationUnitId, parameters);

            Assert.IsNotNull(jobs);
            Assert.AreEqual(10, jobs.Count);
            Assert.IsNotNull(jobs.First().CreationTime);

            Job? job = await client.GetJobAsync(jobs[2].Id);

            Assert.IsNotNull(job);
            Assert.IsNotNull(job.CreationTime);

            Assert.AreEqual(jobs[2].Id, job.Id);
            Assert.AreEqual(jobs[2].CreationTime, job.CreationTime);
        }

        [TestMethod]
        public async Task ValidateDynamicJob()
        {
            Assert.IsNotNull(secrets, "Secrets have been read the wrong way");
            Assert.IsNotNull(secrets.OrchestratorAddress, "Secrets are missing orchestratorAddress");
            Assert.IsNotNull(secrets.ClientSecret, "Secrets are missing clientSecret");
            Assert.IsNotNull(secrets.ClientId, "Secrets are missing clientId");
            Assert.IsNotNull(secrets.StartJobReleaseKey, "Secrets are missing startJobReleaseKey, should be a release key of a job to start in the start job tests");
            Assert.IsNotNull(secrets.StartJobMachineSessionId, "Secrets are missing startJobMachineSessionId, should be machine session id to use with start job tests");
            Assert.IsNotNull(secrets.StartJobRobotId, "Secrets are missing startJobRobotId, should be a robot id to use with start job tests");

            if (!secrets.ShouldTestAgainstApi) // only run this test if we should test against the api
                return;

            Assert.IsNotNull(client, "Client was null when testing, this should not be happening");

            if (!client.IsAuthorized)
                await client.AuthorizeAsync(secrets.ClientSecret, secrets.ClientId, PathClient.DefaultScope);

            StartJobBody startJobBody = new StartJobBody(secrets.StartJobReleaseKey, secrets.StartJobMachineSessionId.Value, secrets.StartJobRobotId.Value);
            StartJobValidationResult? validationResult = await client.ValidateDynamicJobAsync(startJobBody);

            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.IsValid);
            Assert.IsNotNull(validationResult.Errors);
            Assert.AreEqual(0, validationResult.Errors.Count);
        }

        [TestMethod]
        public async Task GetFolders()
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

            List<Folder>? folders = await client.GetFoldersAsync();

            Assert.IsNotNull(folders);
            Assert.IsTrue(folders.Count > 0);
        }
    }
}