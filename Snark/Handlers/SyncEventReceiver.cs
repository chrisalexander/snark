using System;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Events;

namespace Snark.Handlers
{
    public abstract class SyncEventReceiver : AbstractHandler
    {
        /// <summary>
        /// Handle the given event synchronously.
        /// </summary>
        /// <param name="event">The event.</param>
        public abstract void HandleEvent(IEvent @event);

        public sealed override Task ProcessEventAsync(IEvent @event, Action<OutMessage> reply)
        {
            this.HandleEvent(@event);
            return Task.FromResult<object>(null);
        }
    }
}
