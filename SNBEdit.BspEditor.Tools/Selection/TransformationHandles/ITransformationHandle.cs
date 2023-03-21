using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Rendering.Viewport;
using SNBEdit.BspEditor.Tools.Draggable;
using SNBEdit.Rendering.Cameras;
using System.Numerics;

namespace SNBEdit.BspEditor.Tools.Selection.TransformationHandles
{
    public interface ITransformationHandle : IDraggable
    {
        string Name { get; }
        Matrix4x4? GetTransformationMatrix(MapViewport viewport, OrthographicCamera camera, BoxState state, MapDocument doc);
        TextureTransformationType GetTextureTransformationType(MapDocument doc);
    }
}
