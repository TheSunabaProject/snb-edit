using LogicAndTrick.Oy;
using SNBEdit.BspEditor.Commands;
using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Editing.Properties;
using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.Common.Shell.Commands;
using SNBEdit.Common.Shell.Menu;
using SNBEdit.Common.Translations;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Map", "", "Properties", "A")]
    [CommandID("BspEditor:Map:RootProperties")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_MapProperties))]
    public class OpenRootProperties : BaseCommand
    {
        public override string Name { get; set; } = "Map properties";
        public override string Details { get; set; } = "Open the map properties window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("BspEditor:ObjectProperties:OpenWithSelection", new List<IMapObject> { document.Map.Root });
        }
    }
}