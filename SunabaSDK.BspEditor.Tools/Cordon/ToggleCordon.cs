using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Modification;
using SunabaSDK.BspEditor.Modification.Operations;
using SunabaSDK.BspEditor.Primitives.MapData;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.BspEditor.Tools.Properties;
using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Context;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Tools.Cordon
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