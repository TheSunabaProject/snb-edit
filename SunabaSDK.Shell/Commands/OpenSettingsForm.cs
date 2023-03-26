using LogicAndTrick.Oy;
using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Context;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using SunabaSDK.Shell.Properties;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SunabaSDK.Shell.Commands
{
    /// <summary>
    /// Opens the settings window
    /// </summary>
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("Tools:Settings")]
    [MenuItem("Tools", "", "Settings", "D")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Options))]
    public class OpenSettingsForm : ICommand
    {
        public string Name { get; set; } = "Settings";
        public string Details { get; set; } = "Open the settings form";

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("SettingsForm"));
        }
    }
}
