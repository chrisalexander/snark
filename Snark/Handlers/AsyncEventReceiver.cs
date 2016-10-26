using System;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Events;

namespace Snark.Handlers
{
    public abstract class AyncEventReceiver : AbstractHandler
    {
        /// <summary>
        /// Handle the given event asynchronously.
        /// </summary>
        /// <param name="event">The event.</param>
        public abstract Task HandleEventAsync(IEvent @event);

        public sealed override async Task ProcessEventAsync(IEvent @event, Action<OutMessage> reply)
        {
            await this.HandleEventAsync(@event);
        }
    }
}
