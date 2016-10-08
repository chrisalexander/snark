using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Snark.Slack.Client.Serialization;
using Snark.Slack.Client.Sources.Model;
using Snark.Slack.Responses;

namespace Snark.Slack.Client.Sources
{
    class Rpc
    {
        private static readonly string Endpoint = "https://slack.com/api";

        private readonly HttpClient client;

        private readonly JsonSerializerSettings jsonSettings;

        public Rpc()
        {
            this.client = new HttpClient();

            this.jsonSettings = new JsonSerializerSettings()
            {
                ContractResolver = new UnderscorePropertyNamesContractResolver()
            };
        }

        internal Task<StartRealtimeResponse> StartRealtime(Token token)
        {
            return this.Get<StartRealtimeResponse>("/rtm.start", new { Token = token });
        }

        private async Task<T> Get<T>(string path, object arguments)
        {
            var str = await this.client.GetStringAsync(this.GenerateUri(path, arguments));
            return JsonConvert.DeserializeObject<T>(str, this.jsonSettings);
        }

        private string GenerateUri(string path, object arguments)
        {
            return Endpoint +
                    path +
                    "?" +
                    string.Join(
                        "&",
                        arguments.GetType().GetProperties().Select(
                            p => p.Name.ToLower() +
                                    "=" +
                                    p.GetValue(arguments).ToString()));
        }
    }
}
