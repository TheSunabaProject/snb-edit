using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Rendering.Viewport;
using SunabaSDK.Rendering.Cameras;
using SunabaSDK.Rendering.Overlay;
using SunabaSDK.Rendering.Resources;
using System;
using System.Numerics;

namespace SunabaSDK.BspEditor.Tools.Draggable
{
    public interface IDraggable : IOverlayRenderable
    {
        Vector3 Origin { get; }
        Vector3 ZIndex { get; }
        event EventHandler DragStarted;
        event EventHandler DragMoved;
        event EventHandler DragEnded;
        void MouseDown(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position);
        void MouseUp(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position);
        void Click(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position);
        bool CanDrag(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position);
        void Highlight(MapDocument document, MapViewport viewport);
        void Unhighlight(MapDocument document, MapViewport viewport);
        void StartDrag(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position);
        void Drag(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 lastPosition, Vector3 position);
        void EndDrag(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position);
        void Render(MapDocument document, BufferBuilder builder);
    }
}