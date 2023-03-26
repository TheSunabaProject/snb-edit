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
    [MenuItem("Map", "", "Properties", "E")]
    [CommandID("BspEditor:Map:LogicalTree")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowLogicalTree))]
    public class OpenMapTreeWindow : BaseCommand
    {
        public override string Name { get; set; } = "Show logical tree";
        public override string Details { get; set; } = "Show the logical tree of the current document.";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:MapTree"));
        }
    }
}