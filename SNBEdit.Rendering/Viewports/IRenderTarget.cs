using System;
using Veldrid;

namespace SNBEdit.Rendering.Viewports
{
    public interface IRenderTarget : IDisposable
    {
        Swapchain Swapchain { get; }
        bool ShouldRender(long frame);
    }
}