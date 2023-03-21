using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.DataStructures.Geometric;

namespace SNBEdit.BspEditor.Primitives.MapObjectData
{
    public interface IBoundingBoxProvider : IMapObjectData
    {
        Box GetBoundingBox(IMapObject obj);
    }
}
