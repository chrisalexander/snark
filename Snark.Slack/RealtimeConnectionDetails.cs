using System;

namespace Snark.Slack
{
    class RealtimeConnectionDetails
    {
        public RealtimeConnectionDetails(Uri endpoint)
        {
            this.WebsocketEndpoint = endpoint;
        }

        public Uri WebsocketEndpoint { get; }
    }
}
