using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Primitives.MapObjectData;
using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.BspEditor.Rendering.ChangeHandlers;
using SNBEdit.BspEditor.Rendering.Resources;
using SNBEdit.DataStructures.Geometric;
using SNBEdit.Rendering.Resources;
using System.ComponentModel.Composition;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Rendering.Converters
{
    [Export(typeof(IMapObjectSceneConverter))]
    public class EntityDecalConverter : IMapObjectSceneConverter
    {
        public MapObjectSceneConverterPriority Priority => MapObjectSceneConverterPriority.DefaultLow;

        public bool ShouldStopProcessing(MapDocument document, IMapObject obj)
        {
            return true;
        }

        public bool Supports(IMapObject obj)
        {
            return obj is Entity && obj.Data.OfType<EntityDecal>().Any();
        }

        public async Task Convert(BufferBuilder builder, MapDocument document, IMapObject obj, ResourceCollector resourceCollector)
        {
            var faces = obj.Data.Get<EntityDecal>().SelectMany(x => x.Geometry).ToList();
            await DefaultSolidConverter.ConvertFaces(builder, document, obj, faces, resourceCollector);

            var origin = obj.Data.GetOne<Origin>()?.Location ?? obj.BoundingBox.Center;
            await DefaultEntityConverter.ConvertBox(builder, obj, new Box(origin - Vector3.One * 4, origin + Vector3.One * 4));
        }
    }
}