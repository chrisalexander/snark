using System;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Client;
using Snark.Events;
using Snark.Handlers;
using Snark.Implementation;

namespace Snark
{
    public class Bot<Credentials>
        where Credentials : ICredentials
    {
        private readonly Credentials credentials;

        private readonly MessageHandlingCollection<AsyncEventResponder> asyncEventResponders;

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

        public void Subscribe(AsyncEventResponder responder)
        {
            this.asyncEventResponders.Add(responder);
        }

        public void Unsubscribe(AsyncEventResponder responder)
        {
            this.asyncEventResponders.Remove(responder);
        }

        public void Subscribe(DeferredEventResponder responder)
        {

        }

        public void Unsubscribe(DeferredEventResponder responder)
        {

        }

        public void Subscribe(EventReceiver receiver)
        {

        }

        public void Unsubscribe(EventReceiver receiver)
        {

        }

        public void Subscribe(SyncEventResponder responder)
        {

        }

        public void Unsubscribe(SyncEventResponder responder)
        {

        }

        public void Subscribe(Func<IEvent, Task<OutMessage>> callback)
        {

        }

        public void Unsubscribe(Func<IEvent, Task<OutMessage>> callback)
        {

        }

        public void Subscribe(Action<IEvent, Action<OutMessage>> callback)
        {

        }

        public void Unsubscribe(Action<IEvent, Action<OutMessage>> callback)
        {

        }

        public void Subscribe(Action<IEvent> callback)
        {

        }

        public void Unsubscribe(Action<IEvent> callback)
        {

        }

        public void Subscribe(Func<IEvent, OutMessage> callback)
        {

        }

        public void Unsubscribe(Func<IEvent, OutMessage> callback)
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
