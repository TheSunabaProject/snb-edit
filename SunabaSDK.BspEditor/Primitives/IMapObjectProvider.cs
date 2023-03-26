using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.Common.Transport;

namespace SunabaSDK.BspEditor.Primitives
{
    public interface IMapElementFormatter
    {
        bool IsSupported(IMapElement obj);
        SerialisedObject Serialise(IMapElement elem);

        bool IsSupported(SerialisedObject elem);
        IMapElement Deserialise(SerialisedObject obj);
    }
}
