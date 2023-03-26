using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.DataStructures.Geometric;

namespace SunabaSDK.BspEditor.Primitives.MapObjectData
{
    public interface IBoundingBoxProvider : IMapObjectData
    {
        Box GetBoundingBox(IMapObject obj);
    }
}
