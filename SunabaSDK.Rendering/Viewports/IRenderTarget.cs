using System;
using Veldrid;

namespace SunabaSDK.Rendering.Viewports
{
    public interface IRenderTarget : IDisposable
    {
        Swapchain Swapchain { get; }
        bool ShouldRender(long frame);
    }
}