using System;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Events;

namespace Snark.Handlers
{
    public abstract class SyncDeferredEventResponder : AbstractHandler
    {
        /// <summary>
        /// Handle the given event synchronously and reply later.
        /// </summary>
        /// <param name="event">The event.</param>
        public abstract void HandleEvent(IEvent @event, Action<OutMessage> reply);

        public sealed override Task ProcessEventAsync(IEvent @event, Action<OutMessage> reply)
        {
            this.HandleEvent(@event, reply);
            return Task.FromResult<object>(null);
        }
    }
}
