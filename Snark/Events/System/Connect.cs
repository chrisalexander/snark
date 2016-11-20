using Snark.Client;

namespace Snark.Events.System
{
    public class Connect : BaseSystemEvent
    {
        public Connect(ServiceIdentifier service)
            : base(service) { }

        public override string Type => "Connect";
    }
}
