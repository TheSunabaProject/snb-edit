using SNBEdit.BspEditor.Tools.Vertex.Selection;
using System.Collections.Generic;

namespace SNBEdit.BspEditor.Tools.Vertex.Errors
{
    public interface IVertexErrorCheck
    {
        IEnumerable<VertexError> GetErrors(VertexSolid solid);
    }
}
