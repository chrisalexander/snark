﻿using System;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Events;

namespace Snark.Handlers
{
    public abstract class SyncEventResponder : AbstractHandler
    {
        /// <summary>
        /// Handle the given event synchronously, returning a reply (or null for none).
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>A reply, or null.</returns>
        public abstract OutMessage HandleEvent(IEvent @event);

        public sealed override Task ProcessEventAsync(IEvent @event, Action<OutMessage> reply)
        {
            reply(this.HandleEvent(@event));
            return Task.FromResult<object>(null);
        }
    }
}
