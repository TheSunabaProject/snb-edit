using LogicAndTrick.Oy;
using SunabaSDK.BspEditor.Commands;
using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Editing.Properties;
using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Context;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Editing.Commands
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