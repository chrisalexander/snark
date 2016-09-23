using Snark.Handlers.Events;

namespace Snark.Handlers
{
    public interface IAsyncEventResponder<T, U>
        where T : IEventType<U>
        where U : IEventData
    {
    }
}
