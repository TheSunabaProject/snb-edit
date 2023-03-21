using LogicAndTrick.Oy;
using SNBEdit.BspEditor.Commands;
using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Editing.Properties;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Context;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Map", "", "Properties", "D")]
    [CommandID("BspEditor:Map:SelectionDetails")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowBrushID))]
    public class OpenSelectionDetails : BaseCommand
    {
        public override string Name { get; set; } = "Selection details";
        public override string Details { get; set; } = "Show details of the current selection";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:SelectionDetails"));
        }
    }
}