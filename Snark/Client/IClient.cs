using System;
using System.Threading.Tasks;
using Snark.Handlers.Events;

namespace Snark.Client
{
    public interface IClient<T> : IDisposable
        where T : ICredentials
    {
        Task ConnectAsync(T credentials);

        event EventReceived<IEventData> EventReceived;
    }

    public delegate void EventReceived<T>(IEventType<T> eventType, T eventData) where T : IEventData;
}
