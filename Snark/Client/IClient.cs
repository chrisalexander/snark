using System;
using System.Threading.Tasks;

namespace Snark.Client
{
    public interface IClient : IDisposable
    {
        Task ConnectAsync(string token);
    }
}
