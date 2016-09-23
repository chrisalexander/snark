using Snark.Handlers.Events;

namespace Snark.Handlers
{
    public interface IDeferredEventResponder<T, U>
        where T : IEventType<U>
        where U : IEventData
    {
    }
}
