using LogicAndTrick.Oy;
using SNBEdit.BspEditor.Commands;
using SNBEdit.BspEditor.Documents;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Hotkeys;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Editing.Commands.View
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:View:FocusCurrent")]
    [MenuItem("View", "", "SplitView", "B")]
    [DefaultHotkey("Shift+Z")]
    public class FocusOnCurrentView : BaseCommand
    {
        public override string Name { get; set; } = "Focus on current view";
        public override string Details { get; set; } = "Maximise the current view in the viewport grid";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("BspEditor:SplitView:FocusCurrent");
        }
    }
}