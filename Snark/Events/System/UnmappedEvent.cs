using Snark.Client;

namespace Snark.Events.System
{
    public class UnmappedEvent : BaseSystemEvent
    {
        private string serviceMessageType;
        private dynamic data;

        public UnmappedEvent(ServiceIdentifier service, string serviceMessageType, dynamic data)
            : base(service)
        {
            this.serviceMessageType = serviceMessageType;
            this.data = data;
        }

        public override string Type => "Unmapped_" + this.Service + "_" + this.serviceMessageType;
        
        public dynamic Data => this.data;

        public override string ToString()
        {
            return this.Type;
        }
    }
}
