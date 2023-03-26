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
    [MenuItem("Map", "", "Properties", "F")]
    [CommandID("BspEditor:Map:EntityReport")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_EntityReport))]
    public class OpenEntityReport : BaseCommand
    {
        public override string Name { get; set; } = "Entity report";
        public override string Details { get; set; } = "Open the entity report window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:EntityReport"));
        }
    }
}