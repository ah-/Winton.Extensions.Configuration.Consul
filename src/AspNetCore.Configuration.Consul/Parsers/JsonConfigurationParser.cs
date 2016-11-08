using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Chocolate.AspNetCore.Configuration.Consul.Parsers
{
    /// <summary>
    /// Implemenation of <see cref="IConfigurationParser"/> for parsing JSON Configuration
    /// </summary>
    public class JsonConfigurationParser : IConfigurationParser
    {
        /// <inheritdoc/>
        public IDictionary<string, string> Parse(Stream stream)
        {
            var serializer = new JsonSerializer();

            using (var streamReader = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                return serializer.Deserialize<Dictionary<string, string>>(jsonTextReader);
            }
        }
    }
}