using SunabaSDK.BspEditor.Rendering.Resources;
using SunabaSDK.Rendering.Resources;

namespace SunabaSDK.BspEditor.Rendering.Dynamic
{
    public interface IDynamicRenderable
    {
        void Render(BufferBuilder builder, ResourceCollector resourceCollector);
    }
}