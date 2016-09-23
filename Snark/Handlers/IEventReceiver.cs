using Snark.Handlers.Events;

namespace Snark.Handlers
{
    public interface IEventReceiver<T, U>
        where T : IEventType<U>
        where U : IEventData
    {
    }
}
