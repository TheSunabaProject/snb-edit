using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Primitives.MapObjectData;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.BspEditor.Rendering.Resources;
using SunabaSDK.Rendering.Resources;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Rendering.Converters
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