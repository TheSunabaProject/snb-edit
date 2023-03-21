using SNBEdit.BspEditor.Primitives.MapObjects;
using System.Runtime.Serialization;

namespace SNBEdit.BspEditor.Primitives.MapObjectData
{
    /// <summary>
    /// Base interface for generic map object metadata
    /// </summary>
    public interface IMapObjectData : ISerializable, IMapElement
    {

    }
}