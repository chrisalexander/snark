using System.Collections.Generic;
using Snark.Chat;

namespace Snark.Client
{
    public interface ISession
    {
        IReadOnlyCollection<User> Users { get; }

        IReadOnlyCollection<Channel> Channels { get; }
    }
}
