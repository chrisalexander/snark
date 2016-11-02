using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Events;

namespace Snark.Handlers
{
    class WrappedLambdaHandler : AbstractHandler
    {
        private Func<IEvent, Action<OutMessage>, Task> callback;

        private IEnumerable<Type> types;
        
        private WrappedLambdaHandler(IEnumerable<Type> types = null)
        {
            this.types = types;
        }

        public WrappedLambdaHandler(Action<IEvent> callback, IEnumerable<Type> types = null)
            : this(types)
        {
            this.callback = (e, _) =>
            {
                callback(e);
                return Task.FromResult<object>(null);
            };
        }

        public WrappedLambdaHandler(Func<IEvent, Task> callback, IEnumerable<Type> types = null)
            : this(types)
        {
            this.callback = (e, _) => callback(e);
        }

        public WrappedLambdaHandler(Func<IEvent, OutMessage> callback, IEnumerable<Type> types = null)
            : this(types)
        {
            this.callback = (e, c) =>
            {
                c(callback(e));
                return Task.FromResult<object>(null);
            };
        }

        public WrappedLambdaHandler(Func<IEvent, Task<OutMessage>> callback, IEnumerable<Type> types = null)
            : this(types)
        {
            this.callback = async (e, c) => c(await callback(e));
        }

        public WrappedLambdaHandler(Func<IEvent, Action<OutMessage>, Task> callback, IEnumerable<Type> types = null)
            : this(types)
        {
            this.callback = callback;
        }

        public WrappedLambdaHandler(Action<IEvent, Action<OutMessage>> callback, IEnumerable<Type> types = null)
            : this(types)
        {
            this.callback = (e, c) =>
            {
                callback(e, c);
                return Task.FromResult<object>(null);
            };
        }

        public override IEnumerable<Type> SupportedMessageTypes()
        {
            if (this.types == null)
            {
                yield break;
            }

            foreach (var type in this.types)
            {
                yield return type;
            }
        }

        public override Task ProcessEventAsync(IEvent @event, Action<OutMessage> reply)
        {
            return this.callback(@event, reply);
        }
    }
}
