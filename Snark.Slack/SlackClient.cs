namespace Snark.Slack
{
    public class SlackClient
    {
        public SlackRpcClient Rpc { get; }

        public SlackRealtimeClient Realtime { get; }
    }
}
