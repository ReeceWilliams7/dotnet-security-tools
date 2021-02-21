using System.Threading.Tasks;

namespace RW7.DotNetSecurityTools.Core.OutputWriting
{
    public interface IOutputWriter<in T>
    {
        string OutputType { get; }

        bool CanWrite(string outputType);

        Task WriteAsync(T output);
    }
}