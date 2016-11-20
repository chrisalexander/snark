using Snark.Client;

namespace Snark.Events.System
{
    public class Disconnect : BaseSystemEvent
    {
        public Disconnect(ServiceIdentifier serviceIdentifier)
            : base(serviceIdentifier) { }

        public override string Type => "Disconnect";
    }
}
