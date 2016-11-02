using Snark.Client;

namespace Snark.Events.System
{
    public class Error : ISystemEvent
    {
        public Error(ServiceIdentifier serviceIdentifier)
        {
            this.Service = serviceIdentifier;
        }

        public string Type => "Error";

        public ServiceIdentifier Service { get; }
    }
}
