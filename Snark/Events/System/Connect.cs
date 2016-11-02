using Snark.Client;

namespace Snark.Events.System
{
    public class Connect : ISystemEvent
    {
        public Connect(ServiceIdentifier serviceIdentifier)
        {
            this.Service = serviceIdentifier;
        }

        public string Type => "Connect";

        public ServiceIdentifier Service { get; }
    }
}
