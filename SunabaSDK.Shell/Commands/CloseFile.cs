using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Context;
using SunabaSDK.Common.Shell.Documents;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using SunabaSDK.Shell.Properties;
using SunabaSDK.Shell.Registers;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SunabaSDK.Shell.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("File:Close")]
    [MenuItem("File", "", "File", "F")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Close))]
    public class CloseFile : ICommand
    {
        private readonly Lazy<DocumentRegister> _documentRegister;

        public string Name { get; set; } = "Close";
        public string Details { get; set; } = "Close";

        [ImportingConstructor]
        public CloseFile(
            [Import] Lazy<DocumentRegister> documentRegister
        )
        {
            _documentRegister = documentRegister;
        }

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out IDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            var doc = context.Get<IDocument>("ActiveDocument");
            if (doc != null)
            {
                await _documentRegister.Value.RequestCloseDocument(doc);
            }
        }
    }
}