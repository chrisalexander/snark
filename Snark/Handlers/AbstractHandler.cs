using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Events;

namespace Snark.Handlers
{
    public abstract class AbstractHandler
    {
        /// <summary>
        /// Returns the types of the messages that are supported by this handler.
        /// </summary>
        /// <remarks>
        /// This method will only be guaranteed to be called once, when the handler
        /// is passed to one of the subscribe methods. Any changes after this point
        /// will not be reflected unless you re-call the Subscribe method with the
        /// handler again.
        /// Calling unsubscribe will ignore the types returned here and remove the
        /// instance from all subscriptions.
        /// </remarks>
        /// <returns>Supported types.</returns>
        public virtual IEnumerable<Type> SupportedMessageTypes()
        {
            yield break;
        }

        public abstract Task ProcessEventAsync(IEvent @event, Action<OutMessage> reply);
    }
}
