using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.Common.Transport;

namespace SNBEdit.BspEditor.Primitives
{
    public interface IMapElementFormatter
    {
        bool IsSupported(IMapElement obj);
        SerialisedObject Serialise(IMapElement elem);

        bool IsSupported(SerialisedObject elem);
        IMapElement Deserialise(SerialisedObject obj);
    }
}
