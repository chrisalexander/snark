using System;
using System.Threading.Tasks;

namespace Snark.Client
{
    public interface IClient<T> : IDisposable
        where T : ICredentials
    {
        Task ConnectAsync(T credentials);
    }
}
