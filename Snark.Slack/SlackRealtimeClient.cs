using System;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Snark.Slack
{
    class SlackRealtimeClient : IDisposable
    {
        private WebSocket socket;

        private bool disposed = false;

        public event SlackMessage MessageReceived;

        internal async Task Connect(SlackSession session)
        {
            // TODO configure socket with proxy
            this.socket = new WebSocket(session.RealtimeConnectionDetails.WebsocketEndpoint.ToString());

            socket.OnOpen += (o, e) => this.MessageReceived?.Invoke("OnOpen");
            socket.OnError += (o, e) => this.MessageReceived?.Invoke("OnError");
            socket.OnClose += (o, e) => this.MessageReceived?.Invoke("OnClose");
            socket.OnMessage += (o, e) => this.MessageReceived?.Invoke(e.Data);

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

    public delegate void SlackMessage(string message);
}
