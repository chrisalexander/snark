using System;
using System.Threading.Tasks;
using Snark.Events;

namespace Snark.Client
{
    public interface IClient : IDisposable
    {
        Task ConnectAsync(ICredentials credentials);

        event EventReceived EventReceived;
    }

    public delegate void EventReceived(IEvent @event);
}
