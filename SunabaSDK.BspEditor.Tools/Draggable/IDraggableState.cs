using System.Collections.Generic;

namespace SunabaSDK.BspEditor.Tools.Draggable
{
    public interface IDraggableState : IDraggable
    {
        IEnumerable<IDraggable> GetDraggables();
    }
}