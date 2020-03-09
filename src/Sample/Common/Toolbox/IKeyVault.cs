using System.Threading.Tasks;

namespace Sample.Common.Toolbox
{
    public interface IKeyVault
    {
        Task<string> GetSecret(string value);
    }
}