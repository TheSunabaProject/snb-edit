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
    [MenuItem("View", "", "Quick", "F")]
    [CommandID("BspEditor:View:ShowHidden")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowHidden))]
    [DefaultHotkey("U")]
    public class ShowHiddenObjects : BaseCommand
    {
        public override string Name { get; set; } = "Show hidden objects";
        public override string Details { get; set; } = "Show objects hidden with quick hide";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var transaction = new Transaction();

            foreach (var mo in document.Map.Root.Find(x => x.Data.Get<QuickHidden>().Any()))
            {
                transaction.Add(new RemoveMapObjectData(mo.ID, mo.Data.GetOne<QuickHidden>()));
            }

            await MapDocumentOperation.Perform(document, transaction);
        }
    }
}