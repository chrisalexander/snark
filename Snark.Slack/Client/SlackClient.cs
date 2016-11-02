using System;
using System.Threading.Tasks;
using Snark.Client;
using Snark.Implementation;
using Snark.Slack.Client.Sources;
using Snark.Slack.Client.Sources.Model;
using Snark.Slack.Events;
using Snark.Slack.Responses;

namespace Snark.Slack.Client
{
    class SlackClient : IClient
    {
        private Session session;

        public event EventReceived EventReceived;

        public Rpc Rpc { get; }

        public Realtime Realtime { get; }

        public static ServiceIdentifier Id => new Slack();

        public SlackClient()
        {
            this.Rpc = new Rpc();
            this.Realtime = new Realtime();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ISession Session => this.session;

        public async Task ConnectAsync(ICredentials credentials)
        {
            var token = credentials.As<Token>();

            var realtime = await this.Rpc.StartRealtime(token);

            this.session = this.CreateSession(realtime, token);

            this.Realtime.SocketStatusChanged += e => this.EventReceived?.Invoke(e);
            this.Realtime.EventReceived += e => this.EventReceived?.Invoke(Mapper.Map(e));

            await this.Realtime.Connect(this.session);
        }

        private Session CreateSession(StartRealtimeResponse realtime, Token token)
        {
            return new Session(realtime.Users, realtime.Channels, token, new RealtimeConnectionDetails(realtime.Url));
        }
    }
}
