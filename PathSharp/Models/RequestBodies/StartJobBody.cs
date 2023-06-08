using PathSharp.Models.Enums;
using PathSharp.Models.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.RequestBodies
{
    public class StartJobBody : RequestBody
    {
        [JsonConverter(typeof(RuntimeTypeConverter))]
        public RuntimeType RuntimeType { get; set; } = RuntimeType.Unattended;
        public string ReleaseKey { get; set; }
        public List<int> MachineSessionIds { get; set; }
        public List<int> RobotIds { get; set; }
        public int JobsCount { get; set; } = 1;
        public string? JobPriority { get; set; }
        public string Strategy { get; set; } = "ModernJobsCount";
        public bool ResumeOnSameContext { get; set; }
        public bool RunAsMe { get; set; }
        public string InputArguments { get { return GetInputArgumentsJson(); } }
        private Dictionary<string, object> inputArguments = new Dictionary<string, object>();

        public StartJobBody(string releaseKey, int machineSessionId, int robotId) : base("startInfo")
        {
            ReleaseKey = releaseKey;
            MachineSessionIds = new List<int>() { machineSessionId };
            RobotIds = new List<int>() { robotId };
        }

        public StartJobBody(string releaseKey, List<int> machineSessionIds, List<int> robotIds) : base("startInfo")
        {
            ReleaseKey = releaseKey;
            MachineSessionIds = machineSessionIds;
            RobotIds = robotIds;
        }

        private string GetInputArgumentsJson()
        {
            if (inputArguments == null)
            {
                return "";
            }

            return JsonSerializer.Serialize(inputArguments);
        }

        public void RemoveRunTimeArgument(string key)
        {
            inputArguments.Remove(key);
        }

        public void AddRunTimeArgument(string key, string value)
        {
            inputArguments.Add(key, value);
        }

        public void AddRunTimeArgument(string key, int value)
        {
            inputArguments.Add(key, value);
        }

        public void AddRunTimeArgument(string key, bool value)
        {
            inputArguments.Add(key, value);
        }

        public void AddRunTimeArgument(string key, object value)
        {
            inputArguments.Add(key, value);
        }

        public override string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
