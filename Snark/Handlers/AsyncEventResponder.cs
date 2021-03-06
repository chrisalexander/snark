﻿using System;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Events;

namespace Snark.Handlers
{
    public abstract class AsyncEventResponder : AbstractHandler
    {
        /// <summary>
        /// Handle the given event asynchronously, returning a reply (or null for none).
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>A reply, or null.</returns>
        public abstract Task<OutMessage> HandleEventAsync(IEvent @event);

        public sealed override async Task ProcessEventAsync(IEvent @event, Action<OutMessage> reply)
        {
            reply(await this.HandleEventAsync(@event));
        }
    }
}
