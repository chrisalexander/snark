using Snark.Client;

namespace Snark.Events.System
{
    public interface ISystemEvent : IEvent
    {
        ServiceIdentifier Service { get; }
    }
}
