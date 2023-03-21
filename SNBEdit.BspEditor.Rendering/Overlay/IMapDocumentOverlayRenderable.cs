using SNBEdit.BspEditor.Documents;
using SNBEdit.Rendering.Overlay;

namespace SNBEdit.BspEditor.Rendering.Overlay
{
    public interface IMapDocumentOverlayRenderable : IOverlayRenderable
    {
        void SetActiveDocument(MapDocument doc);
    }
}