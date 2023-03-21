using LogicAndTrick.Oy;
using SNBEdit.BspEditor.Commands;
using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Editing.Properties;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Context;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Map", "", "Properties", "B")]
    [CommandID("BspEditor:Map:MapInformation")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowInformation))]
    public class OpenMapInformation : BaseCommand
    {
        public override string Name { get; set; } = "Map information";
        public override string Details { get; set; } = "Open the map information window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:MapInformation"));
        }
    }
}