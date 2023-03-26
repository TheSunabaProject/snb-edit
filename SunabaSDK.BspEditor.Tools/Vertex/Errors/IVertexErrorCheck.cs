using SunabaSDK.BspEditor.Tools.Vertex.Selection;
using System.Collections.Generic;

namespace SunabaSDK.BspEditor.Tools.Vertex.Errors
{
    public interface IVertexErrorCheck
    {
        IEnumerable<VertexError> GetErrors(VertexSolid solid);
    }
}
