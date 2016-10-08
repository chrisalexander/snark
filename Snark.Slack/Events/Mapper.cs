using Snark.Events;
using Snark.Events.System;
using Snark.Slack.Client;

namespace Snark.Slack.Events
{
    static class Mapper
    {
        public static IEvent Map(SlackEvent @event)
        {
            // All currently unmapped
            return new UnmappedEvent(SlackClient.Id, @event.Type, @event.Data);
        }
    }
}
