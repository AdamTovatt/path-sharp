using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PathSharp.Models.RequestBodies
{
    public abstract class RequestBody
    {
        private const string wrappingBaseString = "{{\"{0}\":{1}}}";
        private string? wrappingFieldName;

        /// <summary>
        /// Constructor for request body with a parameter for the wrapping field. The json will be created and will be put inside a field with the name as the wrapping field.
        /// </summary>
        /// <param name="wrappingFieldName">The name of the field that should contain the json of the request body. If no wrapping is desired, give it a value of null</param>
        public RequestBody(string? wrappingFieldName)
        {
            this.wrappingFieldName = wrappingFieldName;
        }

        /// <summary>
        /// Required method for returning the object as json, will be used when the JsonBody is created in ToJsonBody()
        /// </summary>
        /// <returns></returns>
        public abstract string ToJson();

        /// <summary>
        /// Will return the json of the request body, either wrapped in a field or not. Some (maybe all) api requests want the body to be wrapped in an object with a field that has the value of the actual request body. Use the constructor with the wrappingFieldName parameter to wrap the json in a field.
        /// </summary>
        /// <returns>HttpContent containing the json of the request body</returns>
        public HttpContent ToJsonBody()
        {
            string json;

            if(wrappingFieldName != null)
                json = string.Format(wrappingBaseString, wrappingFieldName, ToJson());
            else
                json = ToJson();

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
