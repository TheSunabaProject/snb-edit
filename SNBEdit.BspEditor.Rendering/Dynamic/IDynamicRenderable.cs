using SNBEdit.BspEditor.Rendering.Resources;
using SNBEdit.Rendering.Resources;

namespace SNBEdit.BspEditor.Rendering.Dynamic
{
    public interface IDynamicRenderable
    {
        void Render(BufferBuilder builder, ResourceCollector resourceCollector);
    }
}