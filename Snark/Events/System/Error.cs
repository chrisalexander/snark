using Snark.Client;

namespace Snark.Events.System
{
    public class Error : BaseSystemEvent
    {
        public Error(ServiceIdentifier serviceIdentifier)
            : base(serviceIdentifier) { }

        public override string Type => "Error";
    }
}
