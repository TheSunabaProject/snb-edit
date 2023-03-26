using LogicAndTrick.Oy;
using SunabaSDK.BspEditor.Commands;
using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Editing.Properties;
using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Context;
using SunabaSDK.Common.Shell.Hotkeys;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Map", "", "Properties", "D")]
    [CommandID("BspEditor:Map:CheckForProblems")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_CheckForProblems))]
    [DefaultHotkey("Alt+P")]
    public class OpenCheckForProblemsDialog : BaseCommand
    {
        public override string Name { get; set; } = "Check for problems";
        public override string Details { get; set; } = "Open the check for problems window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:CheckForProblems"));
        }
    }
}