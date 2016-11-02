using Snark.Client;

namespace Snark.Events.System
{
    public class UnmappedEvent : ISystemEvent
    {
        private string serviceMessageType;
        private dynamic data;

        public UnmappedEvent(ServiceIdentifier service, string serviceMessageType, dynamic data)
        {
            this.Service = service;
            this.serviceMessageType = serviceMessageType;
            this.data = data;
        }

        public string Type => "Unmapped_" + this.Service + "_" + this.serviceMessageType;

        public ServiceIdentifier Service { get; }

        public dynamic Data => this.data;

        public override string ToString()
        {
            return this.Type;
        }
    }
}
