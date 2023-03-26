using SunabaSDK.Rendering.Cameras;
using SunabaSDK.Rendering.Overlay;
using System;
using System.Windows.Forms;

namespace SunabaSDK.Rendering.Viewports
{
    public interface IViewport : IRenderTarget
    {
        int ID { get; }

        int Width { get; }
        int Height { get; }
        Control Control { get; }
        bool IsFocused { get; }

        ICamera Camera { get; set; }
        ViewportOverlay Overlay { get; }

        void Update(long frame);
        event EventHandler<long> OnUpdate;
    }
}