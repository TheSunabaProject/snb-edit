using SunabaSDK.BspEditor.Primitives;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.BspEditor.Tools.Brush.Brushes.Controls;
using SunabaSDK.DataStructures.Geometric;
using System.Collections.Generic;

namespace SunabaSDK.BspEditor.Tools.Brush
{
    public interface IBrush
    {
        string Name { get; }
        bool CanRound { get; }
        IEnumerable<BrushControl> GetControls();
        IEnumerable<IMapObject> Create(UniqueNumberGenerator idGenerator, Box box, string texture, int roundDecimals);
    }
}
