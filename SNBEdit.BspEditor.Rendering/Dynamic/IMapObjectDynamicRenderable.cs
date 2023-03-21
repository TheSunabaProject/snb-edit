using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Rendering.Resources;
using SNBEdit.Rendering.Resources;

namespace SNBEdit.BspEditor.Rendering.Dynamic
{
    public interface IMapObjectDynamicRenderable
    {
        void Render(MapDocument document, BufferBuilder builder, ResourceCollector resourceCollector);
    }
}