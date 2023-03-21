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
    [CommandID("BspEditor:Grid:DecreaseSpacing")]
    [DefaultHotkey("[")]
    [MenuItem("Map", "", "Grid", "G")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SmallerGrid))]
    [AutoTranslate]
    public class DecreaseGrid : ICommand
    {
        public string Name { get; set; } = "Smaller Grid";
        public string Details { get; set; } = "Decrease the grid size";

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                var activeGrid = doc.Map.Data.GetOne<GridData>();
                var grid = activeGrid?.Grid;
                if (grid != null)
                {
                    var operation = new TrivialOperation(x => grid.Spacing--, x => x.Update(activeGrid));
                    await MapDocumentOperation.Perform(doc, operation);
                }
            }
        }
    }
}