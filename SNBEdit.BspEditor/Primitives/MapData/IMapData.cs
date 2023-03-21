using SNBEdit.BspEditor.Primitives.MapObjects;
using System.Runtime.Serialization;

namespace SNBEdit.BspEditor.Primitives.MapData
{
    /// <summary>
    /// Base interface for generic map metadata
    /// </summary>
    public interface IMapData : ISerializable, IMapElement
    {
        bool AffectsRendering { get; }
    }
}