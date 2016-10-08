using System.Collections.Generic;
using Snark.Chat;

namespace Snark.Client
{
    public interface ISession<User, Channel>
        where User : IUser
        where Channel : IChannel
    {
        IReadOnlyCollection<User> Users { get; }

        IReadOnlyCollection<Channel> Channels { get; }
    }
}
