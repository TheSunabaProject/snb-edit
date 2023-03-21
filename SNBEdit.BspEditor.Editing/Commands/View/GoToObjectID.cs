using LogicAndTrick.Oy;
using SNBEdit.BspEditor.Commands;
using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Editing.Properties;
using SNBEdit.BspEditor.Modification;
using SNBEdit.BspEditor.Modification.Operations.Selection;
using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using SNBEdit.QuickForms;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNBEdit.BspEditor.Editing.Commands.View
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:View:GoToObjectID")]
    [MenuItem("View", "", "GoTo", "D")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_GoToBrushID))]
    public class GoToObjectID : BaseCommand
    {
        public override string Name { get; set; } = "Go to object ID";
        public override string Details { get; set; } = "Select and center views on a specific object ID.";

        public string Title { get; set; }
        public string ObjectID { get; set; }
        public string OK { get; set; }
        public string Cancel { get; set; }

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            using (var qf = new QuickForm(Title) { UseShortcutKeys = true }.TextBox("ObjectID", ObjectID).OkCancel(OK, Cancel))
            {
                qf.ClientSize = new Size(230, qf.ClientSize.Height);

                if (await qf.ShowDialogAsync() != DialogResult.OK) return;

                if (!long.TryParse(qf.String("ObjectID"), out var id)) return;

                var obj = document.Map.Root.FindByID(id);
                if (obj == null) return;

                var tran = new Transaction(
                    new Deselect(document.Selection),
                    new Select(obj)
                );

                await MapDocumentOperation.Perform(document, tran);

                var box = obj.BoundingBox;

                await Task.WhenAll(
                    Oy.Publish("MapDocument:Viewport:Focus3D", box),
                    Oy.Publish("MapDocument:Viewport:Focus2D", box)
                );
            }
        }
    }
}