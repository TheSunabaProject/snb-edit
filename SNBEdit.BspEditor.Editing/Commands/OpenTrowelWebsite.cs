using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Context;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Help", "", "Links", "D")]
    [CommandID("BspEditor:Links:SledgeWebsite")]
    public class OpenSledgeWebsite : ICommand
    {
        public string Name { get; set; } = "SNBEdit Website";
        public string Details { get; set; } = "Go to the SNBEdit website";

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            await Task.Run(() =>
            {
                var ps = new ProcessStartInfo("https://github.com/mattiascibien/SNBEdit/")
                {
                    UseShellExecute = true,
                    Verb = "open"
                };
                Process.Start(ps);
            });
        }
    }
}