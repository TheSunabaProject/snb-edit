using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Modification;
using SNBEdit.BspEditor.Modification.Operations;
using SNBEdit.BspEditor.Primitives.MapData;
using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.BspEditor.Tools.Properties;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Context;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Tools.Cordon
{
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Cordon:ToggleCordon")]
    [MenuItem("Tools", "", "Cordon", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Cordon))]
    [AutoTranslate]
    public class ToggleCordon : ICommand
    {
        public string Name { get; set; } = "Cordon Bounds";
        public string Details { get; set; } = "Toggle cordon bounds";

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                var cordon = doc.Map.Data.GetOne<CordonBounds>() ?? new CordonBounds { Enabled = false };
                cordon.Enabled = !cordon.Enabled;
                await MapDocumentOperation.Perform(doc, new TrivialOperation(x => x.Map.Data.Replace(cordon), x => x.Update(cordon).UpdateRange(doc.Map.Root.FindAll())));
            }
        }
    }
}