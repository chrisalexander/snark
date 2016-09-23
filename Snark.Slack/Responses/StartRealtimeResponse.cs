using System.Collections.Generic;
using Snark.Slack.Model;

namespace Snark.Slack.Responses
{
    class StartRealtimeResponse : SlackResponse
    {
        public IEnumerable<SlackUser> Users { get; set; }
    }
}
