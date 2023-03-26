using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.Rendering.Cameras;
using SunabaSDK.Rendering.Overlay;
using SunabaSDK.Rendering.Viewports;
using System.Collections.Generic;
using System.Numerics;

namespace SunabaSDK.BspEditor.Rendering.Overlay
{
    public interface IMapObject2DOverlay
    {
        void Render(IViewport viewport, ICollection<IMapObject> objects, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im);
    }
}