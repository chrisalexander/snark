using Snark.Events;

namespace Snark.Handlers
{
    public interface IEventReceiver<E>
        where E : IEvent
    {
    }
}
