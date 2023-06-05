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

                if (readSecrets == null || !readSecrets.HasBeenSet)
                    throw new ArgumentNullException("Test secrets have not been specified. Should be a text file called TestSecrets.txt in the same directory as this executable");

                secrets = readSecrets;
            }
            catch
            {
                throw new Exception("Error when reading test secrets. They should be in a text file called TestSecrets.txt in the same directory as this executable");
            }
        }

        [TestMethod]
        public async Task Authorize()
        {
            Assert.IsNotNull(secrets, "Secrets have been read the wrong way");
            Assert.IsNotNull(secrets.OrchestratorAddress, "Secrets are missing orchestratorAddress");
            Assert.IsNotNull(secrets.ClientSecret, "Secrets are missing clientSecret");
            Assert.IsNotNull(secrets.ClientId, "Secrets are missing clientId");

            PathClient pathClient = new PathClient(RequestAddress.Base.Default, secrets.OrchestratorAddress);

            await pathClient.Authorize(secrets.ClientSecret, secrets.ClientId, PathClient.DefaultScope);
        }
    }
}