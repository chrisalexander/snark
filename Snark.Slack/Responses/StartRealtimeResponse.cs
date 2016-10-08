using System;
using System.Collections.Generic;
using Snark.Slack.Model;

namespace Snark.Slack.Responses
{
    class StartRealtimeResponse : SlackResponse
    {
        public IEnumerable<Channel> Channels { get; set; }

        public IEnumerable<User> Users { get; set; }

        public Uri Url { get; set; }
    }
}
