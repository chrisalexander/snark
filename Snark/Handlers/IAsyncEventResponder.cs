using Snark.Events;

namespace Snark.Handlers
{
    public interface IAsyncEventResponder<E>
        where E : IEvent
    {
    }
}
