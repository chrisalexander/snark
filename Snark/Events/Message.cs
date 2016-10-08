using Snark.Handlers;

namespace Snark.Events
{
    public class Message : IEvent
    {
        public string Type => "Message";
    }
}
