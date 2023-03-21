using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.Common.Threading;
using SNBEdit.DataStructures.Geometric;
using System.Collections.Generic;
using System.Linq;

namespace SNBEdit.BspEditor.Tools.Vertex.Selection
{
    public class MutableSolid
    {
        public IList<MutableFace> Faces { get; }
        public Box BoundingBox => new Box(Faces.SelectMany(x => x.Vertices.Select(v => v.Position)));

        public MutableSolid(Solid solid)
        {
            Faces = new ThreadSafeList<MutableFace>(solid.Faces.Select(x => new MutableFace(x)));
        }
    }
}