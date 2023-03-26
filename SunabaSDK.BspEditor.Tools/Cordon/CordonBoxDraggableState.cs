using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Primitives.MapData;
using SunabaSDK.BspEditor.Rendering.Viewport;
using SunabaSDK.BspEditor.Tools.Draggable;
using SunabaSDK.Rendering.Cameras;
using System.Numerics;

namespace SunabaSDK.BspEditor.Tools.Cordon
{
    public class CordonBoxDraggableState : BoxDraggableState
    {
        public CordonBoxDraggableState(BaseDraggableTool tool) : base(tool)
        {
        }

        public void Update()
        {
            var document = Tool.GetDocument();
            if (document == null)
            {
                State.Action = BoxAction.Idle;
            }
            else
            {
                var cordon = document.Map.Data.GetOne<CordonBounds>() ?? new CordonBounds { Enabled = false };
                State.Start = cordon.Box.Start;
                State.End = cordon.Box.End;
                State.Action = BoxAction.Drawn;
            }
        }

        public override void Click(MapDocument document, MapViewport viewport, OrthographicCamera camera,
            ViewportEvent e, Vector3 position)
        {
            //
        }

        public override bool CanDrag(MapDocument document, MapViewport viewport, OrthographicCamera camera,
            ViewportEvent e, Vector3 position)
        {
            return false;
        }
    }
}
