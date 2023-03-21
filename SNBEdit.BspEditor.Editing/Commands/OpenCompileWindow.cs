using SNBEdit.BspEditor.Commands;
using SNBEdit.BspEditor.Compile;
using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Editing.Components.Compile;
using SNBEdit.BspEditor.Editing.Components.Compile.Profiles;
using SNBEdit.BspEditor.Editing.Components.Compile.Specification;
using SNBEdit.BspEditor.Editing.Properties;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Hotkeys;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using SNBEdit.Shell;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNBEdit.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("File", "", "Build", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Run))]
    [CommandID("BspEditor:File:Compile")]
    [DefaultHotkey("F9")]
    public class OpenCompileWindow : BaseCommand
    {
        private readonly Lazy<CompileSpecificationRegister> _compileSpecificationRegister;
        private readonly Lazy<BuildProfileRegister> _buildProfileRegister;

        [ImportingConstructor]
        public OpenCompileWindow(
            [Import] Lazy<CompileSpecificationRegister> compileSpecificationRegister,
            [Import] Lazy<BuildProfileRegister> buildProfileRegister
        )
        {
            _compileSpecificationRegister = compileSpecificationRegister;
            _buildProfileRegister = buildProfileRegister;
        }

        public override string Name { get; set; } = "Run...";
        public override string Details { get; set; } = "Open the compile dialog";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var spec = _compileSpecificationRegister.Value.GetCompileSpecificationsForEngine(document.Environment.Engine).FirstOrDefault();
            if (spec == null) return;

            using (var cd = new CompileDialog(spec, _buildProfileRegister.Value))
            {
                if (await cd.ShowDialogAsync() == DialogResult.OK)
                {
                    var arguments = cd.SelectedBatchArguments;
                    var batch = await document.Environment.CreateBatch(arguments, new BatchOptions());
                    if (batch == null) return;

                    await batch.Run(document);
                }
            }
        }
    }
}