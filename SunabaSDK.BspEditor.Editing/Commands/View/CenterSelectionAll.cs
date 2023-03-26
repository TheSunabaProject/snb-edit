using LogicAndTrick.Oy;
using SunabaSDK.BspEditor.Commands;
using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Editing.Properties;
using SunabaSDK.Common.Shell.Commands;
using SunabaSDK.Common.Shell.Menu;
using SunabaSDK.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Editing.Commands.View
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:View:CenterSelectionAll")]
    [MenuItem("View", "", "Selection", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_CenterSelectionAll))]
    public class CenterSelectionAll : BaseCommand
    {
        public override string Name { get; set; } = "Center all views on selection";
        public override string Details { get; set; } = "Move the cameras of all views to focus on the selected objects.";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            if (document.Selection.IsEmpty) return;

            var box = document.Selection.GetSelectionBoundingBox();

            await Task.WhenAll(
                Oy.Publish("MapDocument:Viewport:Focus3D", box),
                Oy.Publish("MapDocument:Viewport:Focus2D", box)
            );
        }
    }
}