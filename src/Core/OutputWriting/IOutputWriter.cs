using System.Threading.Tasks;

namespace RW7.DotNetSecurityTools.Core.OutputWriting
{
    public interface IOutputWriter<T>
    {
         Task WriteAsync(T output);
    }
}