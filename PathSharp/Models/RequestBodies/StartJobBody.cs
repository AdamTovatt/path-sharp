using PathSharp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PathSharp.Models.RequestBodies
{
    public class StartJobBody
    {
        public string ReleaseKey { get; set; }
        public List<int> MachineSessionIds { get; set; }
        public List<int> RobotIds { get; set; }
        public int JobsCount { get; set; } = 1;
        public string? JobPriority { get; set; }
        public string Strategy { get; set; } = "ModernJobsCount";
        public bool ResumeOnSameContext { get; set; }
        public RuntimeType RuntimeType { get; set; } = RuntimeType.Unattended;
        public bool RunAsMe { get; set; }
        public string InputArguments { get { return GetInputArgumentsJson(); } }
        private Dictionary<string, object> inputArguments = new Dictionary<string, object>();

        public StartJobBody(string releaseKey, int machineSessionId, int robotId)
        {
            ReleaseKey = releaseKey;
            MachineSessionIds = new List<int>() { machineSessionId };
            RobotIds = new List<int>() { robotId };
        }

        public StartJobBody(string releaseKey, List<int> machineSessionIds, List<int> robotIds)
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
    }
}
