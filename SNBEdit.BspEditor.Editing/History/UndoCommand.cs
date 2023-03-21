using SNBEdit.BspEditor.Commands;
using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Editing.Properties;
using SNBEdit.BspEditor.Modification;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Hotkeys;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Editing.History
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:Undo")]
    [DefaultHotkey("Ctrl+Z")]
    [MenuItem("Edit", "", "History", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Undo))]
    public class UndoCommand : BaseCommand
    {
        public override string Name { get; set; } = "Undo";
        public override string Details { get; set; } = "Undo the last operation";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var stack = document.Map.Data.GetOne<HistoryStack>();
            if (stack == null) return;
            if (stack.CanUndo()) await MapDocumentOperation.Reverse(document, stack.UndoOperation());
        }
    }
}