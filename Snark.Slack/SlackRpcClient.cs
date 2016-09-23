using System;
using System.Net.Http;
using System.Threading.Tasks;
using Snark.Slack.Responses;

namespace Snark.Slack
{
    class SlackRpcClient
    {
        private readonly HttpClient client;

        public SlackRpcClient()
        {
            this.client = new HttpClient();
        }

        internal Task<StartRealtimeResponse> StartRealtime(string token)
        {
            throw new NotImplementedException();
        }
    }
}
