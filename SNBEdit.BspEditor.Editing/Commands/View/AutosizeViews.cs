using LogicAndTrick.Oy;
using SNBEdit.BspEditor.Commands;
using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Editing.Properties;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Editing.Commands.View
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:View:AutosizeViews")]
    [MenuItem("View", "", "SplitView", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_AutosizeViews))]
    public class AutosizeViews : BaseCommand
    {
        public override string Name { get; set; } = "Autosize views";
        public override string Details { get; set; } = "Automatically resize the split views to be the same size.";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("BspEditor:SplitView:Autosize");
        }
    }
}