using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Constants
{
    public class RequestAddress
    {
        public class Base
        {
            public const string Default = "https://cloud.uipath.com";
        }

        public class Identity
        {
            public const string Token = "/identity_/connect/token";
        }

        public class Jobs
        {
            public const string Get = "/odata/Jobs";
            public const string GetById = "/odata/Jobs({0})";
            public const string StopById = "/odata/Jobs({0})/UiPath.Server.Configuration.OData.StopJob";
            public const string ValidateExistingJobId = "/odata/Jobs({0})/UiPath.Server.Configuration.OData.ValidateExistingJob";
            public const string Export = "/odata/Jobs/UiPath.Server.Configuration.OData.ExportJobs";
            public const string RestartJob = "/odata/Jobs({0})/UiPath.Server.Configuration.OData.RestartJob";
            public const string ResumeJob = "/odata/Jobs({0})/UiPath.Server.Configuration.OData.ResumeJob";
            public const string StartJobs = "/odata/Jobs/UiPath.Server.Configuration.OData.StartJobs";
            public const string StopJobs = "/odata/Jobs/UiPath.Server.Configuration.OData.StopJobs";
            public const string ValidateDynamicJob = "/odata/Jobs/UiPath.Server.Configuration.OData.ValidateDynamicJob";
        }

        public class Folders
        {
            public const string Get = "/odata/Folders";
        }

        public class Robots
        {
            public const string Get = "/odata/Robots";
            public const string FindAll = "/odata/Robots/UiPath.Server.Configuration.OData.FindAllAcrossFolders";
        }

        public class Machines
        {
            public const string Get = "/odata/Machines";
        }
    }
}
