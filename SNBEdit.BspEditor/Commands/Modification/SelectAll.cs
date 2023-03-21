using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Modification;
using SNBEdit.BspEditor.Modification.Operations.Selection;
using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.BspEditor.Properties;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Hotkeys;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Commands.Modification
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:SelectAll")]
    [DefaultHotkey("Ctrl+A")]
    [MenuItem("Edit", "", "Selection", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SelectAll))]
    public class SelectAll : BaseCommand
    {
        public override string Name { get; set; } = "Select All";
        public override string Details { get; set; } = "Select all objects";

        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var op = new Select(document.Map.Root.FindAll().Where(x => x.Hierarchy.Parent != null));
            return MapDocumentOperation.Perform(document, op);
        }
    }
}
