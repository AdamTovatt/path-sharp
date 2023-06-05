using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PathSharpTests
{
    public class TestSecrets
    {
        public string? OrchestratorAddress { get; set; }
        public string? ClientSecret { get; set; }
        public string? ClientId { get; set; }
        public bool HasBeenSet { get; set; }

        public static TestSecrets? Read()
        {
            string json = File.ReadAllText("TestSecrets.txt");

            return JsonSerializer.Deserialize<TestSecrets>(json);
        }

        public static void WriteEmpty()
        {
            string json = JsonSerializer.Serialize(new TestSecrets());
            File.WriteAllText("TestSecrets.txt", JsonSerializer.Serialize(new TestSecrets()));
        }
    }
}
