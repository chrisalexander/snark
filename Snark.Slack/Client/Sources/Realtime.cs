using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Snark.Events.System;
using Snark.Slack.Events;
using WebSocketSharp;

namespace Snark.Slack.Client.Sources
{
    class Realtime : IDisposable
    {
        private WebSocket socket;

        private bool disposed = false;

        public event SlackEventReceived EventReceived;

        public event SocketStatus SocketStatusChanged;

        internal async Task Connect(Session session)
        {
            // TODO configure socket with proxy
            this.socket = new WebSocket(session.RealtimeConnectionDetails.WebsocketEndpoint.ToString());

            socket.OnOpen += (o, e) => this.SocketStatusChanged?.Invoke(new Connect());
            socket.OnError += (o, e) => this.SocketStatusChanged?.Invoke(new Error());
            socket.OnClose += (o, e) => this.SocketStatusChanged?.Invoke(new Disconnect());
            socket.OnMessage += (o, e) =>
            {
                var slackEvent = JsonConvert.DeserializeObject<SlackEvent>(e.Data);
                slackEvent.Data = JsonConvert.DeserializeObject<dynamic>(e.Data);
                this.EventReceived?.Invoke(slackEvent);
            };

            await Task.Run(() => socket.Connect());
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (this.socket != null)
                    {
                        ((IDisposable)this.socket).Dispose();
                    }
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }

    delegate void SlackEventReceived(SlackEvent @event);

    public delegate void SocketStatus(ISystemEvent @event);
}
