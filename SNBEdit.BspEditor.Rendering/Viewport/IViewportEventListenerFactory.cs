using System.Collections.Generic;

namespace SNBEdit.BspEditor.Rendering.Viewport
{
    public interface IViewportEventListenerFactory
    {
        IEnumerable<IViewportEventListener> Create(MapViewport viewport);
    }
}