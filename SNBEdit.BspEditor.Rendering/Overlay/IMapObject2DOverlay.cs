using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.Rendering.Cameras;
using SNBEdit.Rendering.Overlay;
using SNBEdit.Rendering.Viewports;
using System.Collections.Generic;
using System.Numerics;

namespace SNBEdit.BspEditor.Rendering.Overlay
{
    public interface IMapObject2DOverlay
    {
        void Render(IViewport viewport, ICollection<IMapObject> objects, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im);
    }
}