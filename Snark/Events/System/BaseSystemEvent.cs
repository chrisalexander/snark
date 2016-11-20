using Snark.Client;

namespace Snark.Events.System
{
    public abstract class BaseSystemEvent : ISystemEvent
    {
        public BaseSystemEvent(ServiceIdentifier service)
        {
            this.Service = service;
        }

        public ServiceIdentifier Service { get; private set; }

        public abstract string Type { get; }
    }
}
