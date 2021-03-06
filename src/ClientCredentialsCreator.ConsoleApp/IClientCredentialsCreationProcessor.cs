using System.Threading.Tasks;

namespace RW7.DotNetSecurityTools.ClientCredentialsGenerator.ConsoleApp
{
    public interface IClientCredentialsCreationProcessor
    {
        Task ProcessAsync(Options options);
    }
}
