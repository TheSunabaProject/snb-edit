using SunabaSDK.BspEditor.Components;
using SunabaSDK.BspEditor.Documents;
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
    [CommandID("BspEditor:Edit:Copy")]
    [DefaultHotkey("Ctrl+C")]
    [MenuItem("Edit", "", "Clipboard", "D")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Copy))]
    public class Copy : BaseCommand
    {
        private readonly Lazy<ClipboardManager> _clipboard;

        public override string Name { get; set; } = "Copy";
        public override string Details { get; set; } = "Copy the current selection";

        [ImportingConstructor]
        public Copy([Import] Lazy<ClipboardManager> clipboard)
        {
            _clipboard = clipboard;
        }

        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var sel = document.Selection.GetSelectedParents().ToList();
            if (sel.Any()) _clipboard.Value.Push(sel);
            return Task.CompletedTask;
        }
    }
}