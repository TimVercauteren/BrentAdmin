using System.Threading.Tasks;

namespace DataLayer
{
    public interface ISecretManager
    {
        Task<string> GetSecretAsync(string secretName);
    }
}