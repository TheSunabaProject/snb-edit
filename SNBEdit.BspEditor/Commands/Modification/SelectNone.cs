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
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Commands.Modification
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:SelectNone")]
    [DefaultHotkey("Shift+Q")]
    [MenuItem("Edit", "", "Selection", "D")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SelectNone))]
    public class SelectNone : BaseCommand
    {
        public override string Name { get; set; } = "Select None";
        public override string Details { get; set; } = "Clear selection";

        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var op = new Deselect(document.Map.Root.FindAll());
            return MapDocumentOperation.Perform(document, op);
        }
    }
}