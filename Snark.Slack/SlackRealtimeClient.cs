using System;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Snark.Slack
{
    class SlackRealtimeClient : IDisposable
    {
        private WebSocket socket;

        private bool disposed = false;

        internal async Task Connect(SlackSession session)
        {
            this.socket = new WebSocket(session.RealtimeConnectionDetails.WebsocketEndpoint.ToString());

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
}
