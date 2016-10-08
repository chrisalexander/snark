using System;
using System.Threading.Tasks;
using Snark.Events;

namespace Snark.Client
{
    public interface IClient<T> : IDisposable
        where T : ICredentials
    {
        Task ConnectAsync(T credentials);

        event EventReceived EventReceived;
    }

    public delegate void EventReceived(IEvent @event);
}
