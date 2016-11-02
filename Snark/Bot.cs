using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snark.Chat;
using Snark.Client;
using Snark.Events;
using Snark.Handlers;
using Snark.Implementation;

namespace Snark
{
    public class Bot
    {
        private readonly ICredentials credentials;

        private readonly MessageHandlingCollection messageHandlers = new MessageHandlingCollection();

        private IClient client;

        public Bot(IClient client, ICredentials credentials)
        {
            this.client = client;
            this.credentials = credentials;
        }

        public IReadOnlyDictionary<ChannelId, Channel> Channels
        {
            get
            {
                return this.client.Session.Channels.ToDictionary(c => c.Id);
            }
        }

        public IReadOnlyDictionary<UserId, User> Users
        {
            get
            {
                return this.client.Session.Users.ToDictionary(u => u.Id);
            }
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
        
        public void Subscribe(Action<IEvent> callback, IEnumerable<Type> types = null)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback, types));
        }

        public void Unsubscribe(Action<IEvent> callback)
        {
            this.messageHandlers.Remove(callback);
        }

        public void Subscribe(Func<IEvent, Task> callback, IEnumerable<Type> types = null)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback, types));
        }

        public void Unsubscribe(Func<IEvent, Task> callback)
        {
            this.messageHandlers.Remove(callback);
        }

        public void Subscribe(Func<IEvent, OutMessage> callback, IEnumerable<Type> types = null)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback, types));
        }

        public void Unsubscribe(Func<IEvent, OutMessage> callback)
        {
            this.messageHandlers.Remove(callback);
        }

        public void Subscribe(Func<IEvent, Task<OutMessage>> callback, IEnumerable<Type> types = null)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback, types));
        }

        public void Unsubscribe(Func<IEvent, Task<OutMessage>> callback)
        {
            this.messageHandlers.Remove(callback);
        }

        public void Subscribe(Action<IEvent, Action<OutMessage>> callback, IEnumerable<Type> types = null)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback, types));
        }

        public void Unsubscribe(Action<IEvent, Action<OutMessage>> callback)
        {
            this.messageHandlers.Remove(callback);
        }

        public void Subscribe(Func<IEvent, Action<OutMessage>, Task> callback, IEnumerable<Type> types = null)
        {
            this.messageHandlers.Add(callback, new WrappedLambdaHandler(callback, types));
        }

        public void Unsubscribe(Func<IEvent, Action<OutMessage>, Task> callback)
        {
            this.messageHandlers.Remove(callback);
        }
        
        public void Reply(ReplyToken token, OutMessage message)
        {

        }

        public void Send(Channel channel, OutMessage message)
        {

        }

        public void Typing(Channel channel)
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
