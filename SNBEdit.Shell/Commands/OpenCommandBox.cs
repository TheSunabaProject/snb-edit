using LogicAndTrick.Oy;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Context;
using SNBEdit.Common.Shell.Hotkeys;
using SNBEdit.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.Shell.Commands
{
    /// <summary>
    /// Opens the command box
    /// </summary>
    [Export(typeof(ICommand))]
    [DefaultHotkey("Ctrl+T")]
    [AutoTranslate]
    public class OpenCommandBox : ICommand
    {
        public string Name { get; set; } = "Open the command box";
        public string Details { get; set; } = "Open the command box";

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            await Oy.Publish<string>("Shell:OpenCommandBox", "");
        }
    }
}
