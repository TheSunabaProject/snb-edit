using SunabaSDK.BspEditor.Components;
using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Modification;
using SunabaSDK.BspEditor.Modification.Operations.Tree;
using SunabaSDK.BspEditor.Properties;
using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Hotkeys;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Commands.Clipboard
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:Cut")]
    [DefaultHotkey("Ctrl+X")]
    [MenuItem("Edit", "", "Clipboard", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Cut))]
    public class Cut : BaseCommand
    {
        private readonly Lazy<ClipboardManager> _clipboard;

        public override string Name { get; set; } = "Cut";
        public override string Details { get; set; } = "Copy the current selection and remove it";

        [ImportingConstructor]
        public Cut([Import] Lazy<ClipboardManager> clipboard)
        {
            _clipboard = clipboard;
        }

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var sel = document.Selection.GetSelectedParents().ToList();
            if (sel.Any())
            {
                _clipboard.Value.Push(sel);
                var t = new Transaction(sel.GroupBy(x => x.Hierarchy.Parent.ID).Select(x => new Detatch(x.Key, x)));
                await MapDocumentOperation.Perform(document, t);
            }
        }
    }
}