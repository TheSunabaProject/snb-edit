using SunabaSDK.Rendering.Cameras;
using SunabaSDK.Rendering.Viewports;
using System.Numerics;

namespace SunabaSDK.Rendering.Overlay
{
    public interface IOverlayRenderable
    {
        void Render(IViewport viewport, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im);
        void Render(IViewport viewport, PerspectiveCamera camera, I2DRenderer im);
    }
}