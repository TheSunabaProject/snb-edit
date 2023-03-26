using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.DataStructures.Geometric;
using SunabaSDK.Rendering.Cameras;
using SunabaSDK.Rendering.Overlay;
using SunabaSDK.Rendering.Viewports;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Numerics;

namespace SunabaSDK.BspEditor.Rendering.Overlay
{
    [Export(typeof(IMapDocumentOverlayRenderable))]
    public class MapObject2DOverlayManager : IMapDocumentOverlayRenderable
    {
        private readonly IEnumerable<Lazy<IMapObject2DOverlay>> _overlays;

        private readonly WeakReference<MapDocument> _document = new WeakReference<MapDocument>(null);

        [ImportingConstructor]
        public MapObject2DOverlayManager(
            [ImportMany] IEnumerable<Lazy<IMapObject2DOverlay>> overlays
        )
        {
            _overlays = overlays;
        }

        public void SetActiveDocument(MapDocument doc)
        {
            _document.SetTarget(doc);
        }

        public void Render(IViewport viewport, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im)
        {
            if (!_overlays.Any()) return;
            if (!_document.TryGetTarget(out var doc)) return;

            // Determine which objects are visible
            var padding = Vector3.One * 100;
            var box = new Box(worldMin - padding, worldMax + padding);
            var objects = doc.Map.Root.Find(x => x.BoundingBox.IntersectsWith(box)).ToList();

            // Render the overlay for each object
            foreach (var overlay in _overlays)
            {
                overlay.Value.Render(viewport, objects, camera, worldMin, worldMax, im);
            }
        }

        public void Render(IViewport viewport, PerspectiveCamera camera, I2DRenderer im)
        {
            // 2D only
        }
    }
}