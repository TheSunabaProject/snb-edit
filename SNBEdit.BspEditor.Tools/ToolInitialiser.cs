using LogicAndTrick.Oy;
using SNBEdit.BspEditor.Rendering.Viewport;
using SNBEdit.Common.Shell.Hooks;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Tools
{
    [Export(typeof(IInitialiseHook))]
    public class ToolInitialiser : IInitialiseHook
    {
        public Task OnInitialise()
        {
            Oy.Subscribe<MapViewport>("MapViewport:Created", MapViewportCreated);
            return Task.CompletedTask;
        }

        private Task MapViewportCreated(MapViewport viewport)
        {
            var itl = new ToolViewportListener(viewport);
            viewport.Listeners.Add(itl);
            return Task.CompletedTask;
        }
    }
}
