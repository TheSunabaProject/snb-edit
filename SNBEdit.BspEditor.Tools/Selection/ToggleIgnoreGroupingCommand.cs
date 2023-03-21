using SNBEdit.BspEditor.Commands;
using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Modification;
using SNBEdit.BspEditor.Modification.Operations;
using SNBEdit.BspEditor.Primitives.MapData;
using SNBEdit.BspEditor.Tools.Properties;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Hotkeys;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Tools.Selection
{
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Map:ToggleIgnoreGrouping")]
    [DefaultHotkey("Ctrl+W")]
    [MenuItem("Map", "", "Grouping", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_IgnoreGrouping))]
    [AutoTranslate]
    public class ToggleIgnoreGroupingCommand : BaseCommand
    {
        public override string Name { get; set; } = "Ignore grouping";
        public override string Details { get; set; } = "Toggle ignore grouping on and off";
        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var opt = document.Map.Data.GetOne<SelectionOptions>() ?? new SelectionOptions();
            opt.IgnoreGrouping = !opt.IgnoreGrouping;
            MapDocumentOperation.Perform(document, new TrivialOperation(x => x.Map.Data.Replace(opt), x => x.Update(opt)));
            return Task.CompletedTask;
        }
    }
}