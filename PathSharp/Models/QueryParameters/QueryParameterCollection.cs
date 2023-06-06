using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Models.QueryParameters
{
    /// <summary>
    /// Represents a collection of query parameters. To be used as a base class for when creating query parameter classes.
    /// </summary>
    public abstract class QueryParameterCollection
    {
        private bool forceLowerCase;
        private bool useDollarSigns;

        /// <summary>
        /// Constructor for the query parameter collection. The api requires the parameter names to be lower case and prefixed with a dollar sign.
        /// </summary>
        /// <param name="forceLowerCase">Wether or not the parameter names should be forced to lower case</param>
        /// <param name="useDollarSigns">Wether or not the parameter names should be prefixed with a dollar sign</param>
        public QueryParameterCollection(bool forceLowerCase = true, bool useDollarSigns = true)
        {
            this.forceLowerCase = forceLowerCase;
            this.useDollarSigns = useDollarSigns;
        }

        /// <summary>
        /// Will return a query parameter collection object formatted as a query string. Will not contain the question mark at the start.
        /// </summary>
        /// <returns>The properties of the object as a query string</returns>
        public override string ToString() // will take all the properties of the objet and return them as a query string, will not include the question mark
        {
            StringBuilder queryStringBuilder = new StringBuilder();

            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead)
                {
                    object? value = property.GetValue(this);
                    if (value != null)
                    {
                        string? valueAsString = value.ToString();

                        if (!string.IsNullOrEmpty(valueAsString))
                        {
                            string propertyName = forceLowerCase ? property.Name.ToLower() : property.Name; // make the property name lower case if we should
                            string propertyValue = Uri.EscapeDataString(valueAsString);

                            queryStringBuilder.Append(string.Format($"{"{0}"}{propertyName}={propertyValue}&", useDollarSigns ? "$" : "")); // add $ if we should
                        }
                    }
                }
            }

            if (queryStringBuilder.Length > 0) // remove the trailing '&' if there are any parameters
                queryStringBuilder.Length--;

            return queryStringBuilder.ToString();
        }
    }
}
