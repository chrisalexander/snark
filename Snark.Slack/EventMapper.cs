using Snark.Events;
using Snark.Events.System;
using Snark.Slack.Events;

namespace Snark.Slack
{
    static class EventMapper
    {
        public static IEvent Map(SlackEvent @event)
        {
            // All currently unmapped
            return new UnmappedEvent(SlackClient.Id, @event.Type, @event.Data);
        }
    }
}
