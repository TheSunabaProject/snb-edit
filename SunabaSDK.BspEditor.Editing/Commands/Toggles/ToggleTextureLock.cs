using SunabaSDK.BspEditor.Commands;
using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Editing.Properties;
using SunabaSDK.BspEditor.Modification;
using SunabaSDK.BspEditor.Modification.Operations;
using SunabaSDK.BspEditor.Primitives.MapData;
using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Context;
using SunabaSDK.Common.Shell.Hotkeys;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Editing.Commands.Toggles
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Map:ToggleTextureLock")]
    [DefaultHotkey("Shift+L")]
    [MenuItem("Map", "", "Texture", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_TextureLock))]
    public class ToggleTextureLock : BaseCommand, IMenuItemExtendedProperties
    {
        public override string Name { get; set; } = "Texture Lock";
        public override string Details { get; set; } = "Toggle texture locking.";
        public bool IsToggle => true;

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var tl = document.Map.Data.GetOne<TransformationFlags>() ?? new TransformationFlags();
            tl.TextureLock = !tl.TextureLock;

            await MapDocumentOperation.Perform(document, new TrivialOperation(x => x.Map.Data.Replace(tl), x => x.Update(tl)));
        }

        public bool GetToggleState(IContext context)
        {
            if (!context.TryGet("ActiveDocument", out MapDocument doc)) return false;
            var tf = doc.Map.Data.GetOne<TransformationFlags>() ?? new TransformationFlags();
            return tf.TextureLock;
        }
    }
}