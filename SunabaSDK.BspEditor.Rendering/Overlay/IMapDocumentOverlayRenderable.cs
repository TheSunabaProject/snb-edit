using SunabaSDK.BspEditor.Documents;
using SunabaSDK.Rendering.Overlay;

namespace SunabaSDK.BspEditor.Rendering.Overlay
{
    public interface IMapDocumentOverlayRenderable : IOverlayRenderable
    {
        void SetActiveDocument(MapDocument doc);
    }
}