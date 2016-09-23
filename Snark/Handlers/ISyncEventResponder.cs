using Snark.Handlers.Events;

namespace Snark.Handlers
{
    public interface ISyncEventResponder<T, U>
        where T : IEventType<U>
        where U : IEventData
    {
    }
}
