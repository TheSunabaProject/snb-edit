using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Primitives.MapObjectData;
using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.BspEditor.Rendering.Resources;
using SNBEdit.Rendering.Resources;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Rendering.Converters
{
    /// <summary>
    /// Stops processing for hidden objects to ensure they are actually hidden.
    /// </summary>
    [Export(typeof(IMapObjectSceneConverter))]
    public class HiddenConverter : IMapObjectSceneConverter
    {
        public MapObjectSceneConverterPriority Priority => MapObjectSceneConverterPriority.OverrideLowest;

        public bool ShouldStopProcessing(MapDocument document, IMapObject obj)
        {
            return true;
        }

        public bool Supports(IMapObject obj)
        {
            return obj.Data.OfType<IObjectVisibility>().Any(x => x.IsHidden)
                || obj.Data.OfType<IRenderVisibility>().Any(x => x.IsRenderHidden);
        }

        public Task Convert(BufferBuilder builder, MapDocument document, IMapObject obj, ResourceCollector resourceCollector)
        {
            return Task.FromResult(false);
        }
    }
}