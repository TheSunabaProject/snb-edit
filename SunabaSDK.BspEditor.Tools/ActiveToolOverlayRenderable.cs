using LogicAndTrick.Oy;
using SunabaSDK.BspEditor.Rendering.Dynamic;
using SunabaSDK.BspEditor.Rendering.Resources;
using SunabaSDK.Common.Shell.Components;
using SunabaSDK.Common.Shell.Hooks;
using SunabaSDK.Rendering.Cameras;
using SunabaSDK.Rendering.Overlay;
using SunabaSDK.Rendering.Resources;
using SunabaSDK.Rendering.Viewports;
using System;
using System.ComponentModel.Composition;
using System.Numerics;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Tools
{
    [Export(typeof(IOverlayRenderable))]
    [Export(typeof(IDynamicRenderable))]
    [Export(typeof(IStartupHook))]
    public class ActiveToolRenderable : IOverlayRenderable, IDynamicRenderable, IStartupHook
    {
        private readonly WeakReference<BaseTool> _activeTool = new WeakReference<BaseTool>(null);
        private BaseTool ActiveTool => _activeTool.TryGetTarget(out var t) ? t : null;

        public Task OnStartup()
        {
            Oy.Subscribe<ITool>("Tool:Activated", ToolActivated);
            return Task.CompletedTask;
        }

        private Task ToolActivated(ITool tool)
        {
            _activeTool.SetTarget(tool as BaseTool);
            return Task.CompletedTask;
        }

        public void Render(BufferBuilder builder, ResourceCollector resourceCollector)
        {
            ActiveTool?.Render(builder, resourceCollector);
        }

        public void Render(IViewport viewport, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im)
        {
            ActiveTool?.Render(viewport, camera, worldMin, worldMax, im);
        }

        public void Render(IViewport viewport, PerspectiveCamera camera, I2DRenderer im)
        {
            ActiveTool?.Render(viewport, camera, im);
        }
    }
}
