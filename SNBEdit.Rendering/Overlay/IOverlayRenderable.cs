using SNBEdit.Rendering.Cameras;
using SNBEdit.Rendering.Viewports;
using System.Numerics;

namespace SNBEdit.Rendering.Overlay
{
    public interface IOverlayRenderable
    {
        void Render(IViewport viewport, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im);
        void Render(IViewport viewport, PerspectiveCamera camera, I2DRenderer im);
    }
}