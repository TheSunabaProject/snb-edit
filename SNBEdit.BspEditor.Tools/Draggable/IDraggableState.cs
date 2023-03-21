using System.Collections.Generic;

namespace SNBEdit.BspEditor.Tools.Draggable
{
    public interface IDraggableState : IDraggable
    {
        IEnumerable<IDraggable> GetDraggables();
    }
}