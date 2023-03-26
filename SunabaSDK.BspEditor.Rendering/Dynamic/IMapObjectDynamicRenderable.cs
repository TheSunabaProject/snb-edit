using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Rendering.Resources;
using SunabaSDK.Rendering.Resources;

namespace SunabaSDK.BspEditor.Rendering.Dynamic
{
    public interface IMapObjectDynamicRenderable
    {
        void Render(MapDocument document, BufferBuilder builder, ResourceCollector resourceCollector);
    }
}