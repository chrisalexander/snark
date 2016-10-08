using System;

namespace Snark.Slack.Client.Sources.Model
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
