using System.Threading.Tasks;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp
{
    public interface IJsonWebKeyCreationProcessor
    {
        Task ProcessAsync(Options options);
    }
}