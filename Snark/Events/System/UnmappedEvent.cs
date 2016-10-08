using Snark.Client;

namespace Snark.Events.System
{
    public class UnmappedEvent : ISystemEvent
    {
        private ServiceIdentifier service;
        private string serviceMessageType;
        private dynamic data;

        public UnmappedEvent(ServiceIdentifier service, string serviceMessageType, dynamic data)
        {
            this.service = service;
            this.serviceMessageType = serviceMessageType;
            this.data = data;
        }

        public string Type => "Unmapped_" + this.service + "_" + this.serviceMessageType;

        public dynamic Data => this.data;
    }
}
