using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Modification;
using SunabaSDK.BspEditor.Modification.Operations.Selection;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.BspEditor.Properties;
using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Hotkeys;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Commands.Modification
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
