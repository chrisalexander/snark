namespace Snark.Slack
{
    public class SlackApiClient
    {
        public SlackRpcClient Rpc { get; }

        public SlackRealtimeClient Realtime { get; }
    }
}
