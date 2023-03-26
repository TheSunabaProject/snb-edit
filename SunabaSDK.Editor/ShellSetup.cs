using SunabaSDK.Common.Shell.Hooks;
using SunabaSDK.Common.Translations;
using SunabaSDK.Editor.Properties;
using SunabaSDK.Shell;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunabaSDK.Editor
{
    [Export(typeof(IInitialiseHook))]
    [AutoTranslate]
    public class ShellSetup : IInitialiseHook
    {
        private readonly Form _shell;

        public string Title { get; set; }

        [ImportingConstructor]
        public ShellSetup([Import("Shell")] Form shell)
        {
            _shell = shell;
        }

        public Task OnInitialise()
        {
            _shell.InvokeLater(() =>
            {
                _shell.Icon = Resources.Sledge;
                _shell.Text = Title;

                var prop = _shell.GetType().GetProperty("Title");
                if (prop != null)
                {
                    prop.SetValue(_shell, Title);
                }
            });

            return Task.CompletedTask;
        }
    }
}
