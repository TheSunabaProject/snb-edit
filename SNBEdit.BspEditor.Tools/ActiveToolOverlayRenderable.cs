using LogicAndTrick.Oy;
using SNBEdit.BspEditor.Rendering.Dynamic;
using SNBEdit.BspEditor.Rendering.Resources;
using SNBEdit.Common.Shell.Components;
using SNBEdit.Common.Shell.Hooks;
using SNBEdit.Rendering.Cameras;
using SNBEdit.Rendering.Overlay;
using SNBEdit.Rendering.Resources;
using SNBEdit.Rendering.Viewports;
using System;
using System.ComponentModel.Composition;
using System.Numerics;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Tools
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
