using SunabaSDK.BspEditor.Primitives;
using SunabaSDK.BspEditor.Primitives.MapObjectData;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.Common.Transport;
using System.Runtime.Serialization;

namespace SunabaSDK.BspEditor.Tools.Vertex.Selection
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
