using System;
using System.Threading.Tasks;
using Snark.Client;
using Snark.Slack.Responses;

namespace Snark.Slack
{
    class SlackClient : IClient
    {
        private SlackSession session;

        public SlackRpcClient Rpc { get; }

        public SlackRealtimeClient Realtime { get; }

        public SlackClient()
        {
            this.Rpc = new SlackRpcClient();
            this.Realtime = new SlackRealtimeClient();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task ConnectAsync(string token)
        {
            var realtime = await this.Rpc.StartRealtime(token);

            this.session = this.CreateSession(realtime, token);

            await this.Realtime.Connect(this.session);
        }

        private SlackSession CreateSession(StartRealtimeResponse realtime, string token)
        {
            throw new NotImplementedException();
        }
    }
}
