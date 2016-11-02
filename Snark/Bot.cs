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

        private readonly MessageHandlingCollection messageHandlers = new MessageHandlingCollection();

        private IClient<Credentials> client;

        public Bot(IClient<Credentials> client, Credentials credentials)
        {
            this.client = client;
            this.credentials = credentials;
        }

        public async Task ConnectAsync()
        {
            this.client.EventReceived += this.HandleEvent;
            await this.client.ConnectAsync(credentials);
        }

        public void Subscribe(AbstractHandler handler)
        {
            this.messageHandlers.Add(handler);
        }

        public void Unsubscribe(AbstractHandler handler)
        {
            this.messageHandlers.Remove(handler);
        }
        
        public void Subscribe(Action<IEvent> callback)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback));
        }

        public void Unsubscribe(Action<IEvent> callback)
        {
            this.messageHandlers.Remove(callback);
        }

        public void Subscribe(Func<IEvent, Task> callback)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback));
        }

        public void Unsubscribe(Func<IEvent, Task> callback)
        {
            this.messageHandlers.Remove(callback);
        }

        public void Subscribe(Func<IEvent, OutMessage> callback)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback));
        }

        public void Unsubscribe(Func<IEvent, OutMessage> callback)
        {
            this.messageHandlers.Remove(callback);
        }

        public void Subscribe(Func<IEvent, Task<OutMessage>> callback)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback));
        }

        public void Unsubscribe(Func<IEvent, Task<OutMessage>> callback)
        {
            this.messageHandlers.Remove(callback);
        }

        public void Subscribe(Action<IEvent, Action<OutMessage>> callback)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback));
        }

        public void Unsubscribe(Action<IEvent, Action<OutMessage>> callback)
        {
            this.messageHandlers.Remove(callback);
        }

        public void Subscribe(Func<IEvent, Action<OutMessage>, Task> callback)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback));
        }

        public void Unsubscribe(Func<IEvent, Action<OutMessage>, Task> callback)
        {
            this.messageHandlers.Remove(callback);
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

        private async void HandleEvent(IEvent @event)
        {
            var handlers = this.messageHandlers.Subscribers(@event.GetType());

            foreach (var handler in handlers)
            {
                await handler.ProcessEventAsync(
                                            @event,
                                            outMessage => Console.WriteLine(outMessage));
            }
        }
    }
}
