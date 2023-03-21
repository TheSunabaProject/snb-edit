using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Modification;
using SNBEdit.BspEditor.Modification.Operations;
using SNBEdit.BspEditor.Primitives.MapData;
using SNBEdit.BspEditor.Tools.Properties;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Context;
using SNBEdit.Common.Shell.Hotkeys;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Tools.Grid
{
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Grid:ToggleSnapToGrid")]
    [DefaultHotkey("Shift+W")]
    [MenuItem("Map", "", "Grid", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SnapToGrid))]
    [AutoTranslate]
    public class ToggleSnapToGrid : ICommand
    {
        public string Name { get; set; } = "Snap to Grid";
        public string Details { get; set; } = "Toggle grid snapping";
        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                var activeGrid = doc.Map.Data.GetOne<GridData>();
                if (activeGrid != null)
                {
                    var operation = new TrivialOperation(x => activeGrid.SnapToGrid = !activeGrid.SnapToGrid, x => x.Update(activeGrid));
                    await MapDocumentOperation.Perform(doc, operation);
                }
            }
        }
    }
}