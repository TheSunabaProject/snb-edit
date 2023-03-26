using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Editing.Components.Compile.Specification
{
    public interface ICompileSpecificationProvider
    {
        Task<IEnumerable<CompileSpecification>> GetSpecifications();
    }
}