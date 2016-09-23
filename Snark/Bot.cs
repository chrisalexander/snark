using System;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Client;
using Snark.Handlers;
using Snark.Handlers.Events;

namespace Snark
{
    public class Bot
    {
        private readonly string token;

        private IClient client;

        public Bot(IClient client, string token)
        {
            this.client = client;
            this.token = token;
        }

        public async Task ConnectAsync()
        {
            await this.client.ConnectAsync(token);
        }

        public void Subscribe<T, U>(IAsyncEventResponder<T, U> responder)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Unsubscribe<T, U>(IAsyncEventResponder<T, U> responder)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Subscribe<T, U>(IDeferredEventResponder<T, U> responder)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Unsubscribe<T, U>(IDeferredEventResponder<T, U> responder)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Subscribe<T, U>(IEventReceiver<T, U> responder)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Unsubscribe<T, U>(IEventReceiver<T, U> responder)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Subscribe<T, U>(ISyncEventResponder<T, U> responder)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Unsubscribe<T, U>(ISyncEventResponder<T, U> responder)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Subscribe<T, U>(Func<U, Task<OutMessage>> callback)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Subscribe<T, U>(Action<U, Func<OutMessage>> callback)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Subscribe<T, U>(Action<U> callback)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Subscribe<T, U>(Func<U, OutMessage> callback)
            where T : IEventType<U>
            where U : IEventData
        {

        }

        public void Reply(IReplyToken token, OutMessage message)
        {

        }

        public void Send(IChannel channel, OutMessage message)
        {

        }

        public void Typing(IChannel channel)
        {

        }
    }
}
