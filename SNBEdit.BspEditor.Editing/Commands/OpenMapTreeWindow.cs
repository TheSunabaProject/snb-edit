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
    [MenuItem("Map", "", "Properties", "E")]
    [CommandID("BspEditor:Map:LogicalTree")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowLogicalTree))]
    public class OpenMapTreeWindow : BaseCommand
    {
        public override string Name { get; set; } = "Show logical tree";
        public override string Details { get; set; } = "Show the logical tree of the current document.";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:MapTree"));
        }
    }
}