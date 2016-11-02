using System;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Events;

namespace Snark.Handlers
{
    class WrappedLambdaHandler : AbstractHandler
    {
        private Func<IEvent, Action<OutMessage>, Task> callback;

        public WrappedLambdaHandler(Action<IEvent> callback)
        {
            this.callback = (e, _) =>
            {
                callback(e);
                return Task.FromResult<object>(null);
            };
        }

        public WrappedLambdaHandler(Func<IEvent, Task> callback)
        {
            this.callback = (e, _) => callback(e);
        }

        public WrappedLambdaHandler(Func<IEvent, OutMessage> callback)
        {
            this.callback = (e, c) =>
            {
                c(callback(e));
                return Task.FromResult<object>(null);
            };
        }

        public WrappedLambdaHandler(Func<IEvent, Task<OutMessage>> callback)
        {
            this.callback = async (e, c) => c(await callback(e));
        }

        public WrappedLambdaHandler(Func<IEvent, Action<OutMessage>, Task> callback)
        {
            this.callback = callback;
        }

        public WrappedLambdaHandler(Action<IEvent, Action<OutMessage>> callback)
        {
            this.callback = (e, c) =>
            {
                callback(e, c);
                return Task.FromResult<object>(null);
            };
        }

        public override Task ProcessEventAsync(IEvent @event, Action<OutMessage> reply)
        {
            return this.callback(@event, reply);
        }
    }
}
