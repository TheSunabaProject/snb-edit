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
using System.Linq;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Tools.Grid
{
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Grid:IncreaseSpacing")]
    [DefaultHotkey("]")]
    [MenuItem("Map", "", "Grid", "H")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_LargerGrid))]
    [AutoTranslate]
    public class IncreaseGrid : ICommand
    {
        public string Name { get; set; } = "Bigger Grid";
        public string Details { get; set; } = "Increase the grid size";

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                var gd = doc.Map.Data.Get<GridData>().FirstOrDefault();
                var grid = gd?.Grid;
                if (grid != null)
                {
                    var operation = new TrivialOperation(x => grid.Spacing++, x => x.Update(gd));
                    await MapDocumentOperation.Perform(doc, operation);
                }
            }
        }
    }
}