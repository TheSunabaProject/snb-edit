using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Context;
using SunabaSDK.Common.Shell.Hotkeys;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SunabaSDK.Shell.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("File:Exit")]
    [DefaultHotkey("Alt+F4")]
    [MenuItem("File", "", "Exit", "M")]
    public class Exit : ICommand
    {
        private readonly Forms.Shell _shell;

        public string Name { get; set; } = "Exit";
        public string Details { get; set; } = "Exit";

        [ImportingConstructor]
        internal Exit([Import] Forms.Shell shell)
        {
            _shell = shell;
        }

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public Task Invoke(IContext context, CommandParameters parameters)
        {
            _shell.Close();
            return Task.CompletedTask;
        }
    }
}