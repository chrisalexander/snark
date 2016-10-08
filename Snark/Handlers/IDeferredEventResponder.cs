using Snark.Events;

namespace Snark.Handlers
{
    public interface IDeferredEventResponder<E>
        where E : IEvent
    {
    }
}
