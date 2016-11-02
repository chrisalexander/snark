using Snark.Client;

namespace Snark.Events.System
{
    public class Disconnect : ISystemEvent
    {
        public Disconnect(ServiceIdentifier serviceIdentifier)
        {
            this.Service = serviceIdentifier;
        }

        public string Type => "Disconnect";

        public ServiceIdentifier Service { get; }
    }
}
