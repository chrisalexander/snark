using System.Text.RegularExpressions;
using Newtonsoft.Json.Serialization;

namespace Snark.Slack.Client.Serialization
{
    /// <summary>
    /// <see cref="https://migara.li/2016/01/09/json-net-easy-serialization/"/>
    /// </summary>
    class UnderscorePropertyNamesContractResolver : DefaultContractResolver
    {
        public UnderscorePropertyNamesContractResolver() : base() { }

        protected override string ResolvePropertyName(string propertyName)
        {
            return Regex.Replace(propertyName, @"(\w)([A-Z])", "$1_$2").ToLower();
        }
    }
}
