using SNBEdit.BspEditor.Commands;
using SNBEdit.BspEditor.Components;
using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Properties;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Controls.Layout
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Window:CreateWindow")]
    [MenuItem("Window", "", "Layout", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_NewWindow))]
    [AllowToolbar(false)]
    public class CreateLayoutWindow : BaseCommand
    {
        private readonly Lazy<MapDocumentControlHost> _host;

        [ImportingConstructor]
        public CreateLayoutWindow(
            [Import] Lazy<MapDocumentControlHost> host
        )
        {
            _host = host;
        }

        public override string Name { get; set; } = "New layout window";
        public override string Details { get; set; } = "Create a new layout window";

        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            _host.Value.CreateNewWindow();
            return Task.CompletedTask;
        }
    }
}