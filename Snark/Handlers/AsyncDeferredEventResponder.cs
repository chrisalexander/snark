using System;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Events;

namespace Snark.Handlers
{
    public abstract class AsyncDeferredEventResponder : AbstractHandler
    {
        /// <summary>
        /// Handle the given event asynchronously and reply later.
        /// </summary>
        /// <param name="event">The event.</param>
        public abstract Task HandleEventAsync(IEvent @event, Action<OutMessage> reply);

        public sealed override async Task ProcessEventAsync(IEvent @event, Action<OutMessage> reply)
        {
            await this.HandleEventAsync(@event, reply);
        }
    }
}
