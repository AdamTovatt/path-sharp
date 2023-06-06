namespace PathSharpTests
{
    [TestClass]
    public class ClientTests
    {
        private TestSecrets secrets;

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
        }

        [TestMethod]
        public async Task Authorize()
        {
            Assert.IsNotNull(secrets, "Secrets have been read the wrong way");
            Assert.IsNotNull(secrets.OrchestratorAddress, "Secrets are missing orchestratorAddress");
            Assert.IsNotNull(secrets.ClientSecret, "Secrets are missing clientSecret");
            Assert.IsNotNull(secrets.ClientId, "Secrets are missing clientId");

            if (!secrets.ShouldTestAgainstApi) // only run this test if we should test against the api
                return;

            PathClient pathClient = new PathClient(RequestAddress.Base.Default, secrets.OrchestratorAddress);

            await pathClient.Authorize(secrets.ClientSecret, secrets.ClientId, PathClient.DefaultScope);

            Assert.IsNotNull(pathClient.Token);
        }
    }
}