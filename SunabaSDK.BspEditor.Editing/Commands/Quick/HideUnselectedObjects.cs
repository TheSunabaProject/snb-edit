using SunabaSDK.BspEditor.Commands;
using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Editing.Properties;
using SunabaSDK.BspEditor.Modification;
using SunabaSDK.BspEditor.Modification.Operations.Data;
using SunabaSDK.BspEditor.Primitives.MapObjectData;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Hotkeys;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Editing.Commands.Quick
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("View", "", "Quick", "D")]
    [CommandID("BspEditor:View:QuickHideUnselected")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_HideUnselected))]
    [DefaultHotkey("Ctrl+H")]
    public class HideUnselectedObjects : BaseCommand
    {
        public override string Name { get; set; } = "Quick hide unselected";
        public override string Details { get; set; } = "Quick hide unselected objects";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var transaction = new Transaction();

            foreach (var mo in document.Map.Root.FindAll().Except(document.Selection).Where(x => !(x is Root)).ToList())
            {
                var ex = mo.Data.GetOne<QuickHidden>();
                if (ex != null) transaction.Add(new RemoveMapObjectData(mo.ID, ex));
                transaction.Add(new AddMapObjectData(mo.ID, new QuickHidden()));
            }

            await MapDocumentOperation.Perform(document, transaction);
        }
    }
}