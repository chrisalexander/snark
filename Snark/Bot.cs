using System;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Client;
using Snark.Events;
using Snark.Handlers;

namespace Snark
{
    public class Bot<Credentials>
        where Credentials : ICredentials
    {
        private readonly Credentials credentials;

        private IClient<Credentials> client;

        public Bot(IClient<Credentials> client, Credentials credentials)
        {
            this.client = client;
            this.credentials = credentials;
        }

        public async Task ConnectAsync()
        {
            // TODO proper mapping
            this.client.EventReceived += Console.WriteLine;
            await this.client.ConnectAsync(credentials);
        }

        public void Subscribe<E>(IAsyncEventResponder<E> responder)
            where E : IEvent
        {

        }

        public void Unsubscribe<E>(IAsyncEventResponder<E> responder)
            where E : IEvent
        {

        }

        public void Subscribe<E>(IDeferredEventResponder<E> responder)
            where E : IEvent
        {

        }

        public void Unsubscribe<E>(IDeferredEventResponder<E> responder)
            where E : IEvent
        {

        }

        public void Subscribe<E>(IEventReceiver<E> receiver)
            where E : IEvent
        {

        }

        public void Unsubscribe<E>(IEventReceiver<E> receiver)
            where E : IEvent
        {

        }

        public void Subscribe<E>(ISyncEventResponder<E> responder)
            where E : IEvent
        {

        }

        public void Unsubscribe<E>(ISyncEventResponder<E> responder)
            where E : IEvent
        {

        }

        public void Subscribe<E>(Func<E, Task<OutMessage>> callback)
            where E : IEvent
        {

        }

        public void Unsubscribe<E>(Func<E, Task<OutMessage>> callback)
            where E : IEvent
        {

        }

        public void Subscribe<E>(Action<E, Func<OutMessage>> callback)
            where E : IEvent
        {

        }

        public void Unsubscribe<E>(Action<E, Func<OutMessage>> callback)
            where E : IEvent
        {

        }

        public void Subscribe<E>(Action<E> callback)
            where E : IEvent
        {

        }

        public void Unsubscribe<E>(Action<E> callback)
            where E : IEvent
        {

        }

        public void Subscribe<E>(Func<E, OutMessage> callback)
            where E : IEvent
        {

        }

        public void Unsubscribe<E>(Func<E, OutMessage> callback)
            where E : IEvent
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
