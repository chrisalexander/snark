using Snark.Chat;

namespace Snark.Slack.Model
{
    class User : IUser
    {
        public UserId Id { get; set; }

        public TeamId TeamId { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string RealName { get; set; }

        public bool IsBot { get; set; }

        public UserPresence Presence { get; set; }

        public string NiceName => !string.IsNullOrWhiteSpace(this.RealName) ? this.RealName : this.Name;

        public override string ToString()
        {
            return this.NiceName + (this.IsBot ? " {{Bot}}" : string.Empty) + " (" + this.Presence + ")";
        }
    }
}
