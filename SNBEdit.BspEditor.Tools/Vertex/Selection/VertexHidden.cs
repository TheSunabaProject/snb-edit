using SNBEdit.BspEditor.Primitives;
using SNBEdit.BspEditor.Primitives.MapObjectData;
using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.Common.Transport;
using System.Runtime.Serialization;

namespace SNBEdit.BspEditor.Tools.Vertex.Selection
{
    public class VertexHidden : IMapObjectData, IRenderVisibility
    {
        public bool IsRenderHidden => true;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Not serialisable
        }

        public SerialisedObject ToSerialisedObject()
        {
            // Not serialisable
            return null;
        }

        public IMapElement Copy(UniqueNumberGenerator numberGenerator)
        {
            return Clone();
        }

        public IMapElement Clone()
        {
            return new VertexHidden();
        }

    }
}
