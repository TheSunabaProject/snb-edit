using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Modification;
using SunabaSDK.BspEditor.Modification.Operations;
using SunabaSDK.BspEditor.Primitives.MapData;
using SunabaSDK.BspEditor.Tools.Properties;
using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Context;
using SunabaSDK.Common.Shell.Hotkeys;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Tools.Grid
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