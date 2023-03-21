using SNBEdit.BspEditor.Primitives;
using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.BspEditor.Tools.Brush.Brushes.Controls;
using SNBEdit.DataStructures.Geometric;
using System.Collections.Generic;

namespace SNBEdit.BspEditor.Tools.Brush
{
    public interface IBrush
    {
        string Name { get; }
        bool CanRound { get; }
        IEnumerable<BrushControl> GetControls();
        IEnumerable<IMapObject> Create(UniqueNumberGenerator idGenerator, Box box, string texture, int roundDecimals);
    }
}
