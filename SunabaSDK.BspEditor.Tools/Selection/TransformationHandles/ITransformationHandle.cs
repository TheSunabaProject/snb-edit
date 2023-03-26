using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Rendering.Viewport;
using SunabaSDK.BspEditor.Tools.Draggable;
using SunabaSDK.Rendering.Cameras;
using System.Numerics;

namespace SunabaSDK.BspEditor.Tools.Selection.TransformationHandles
{
    public interface ITransformationHandle : IDraggable
    {
        string Name { get; }
        Matrix4x4? GetTransformationMatrix(MapViewport viewport, OrthographicCamera camera, BoxState state, MapDocument doc);
        TextureTransformationType GetTextureTransformationType(MapDocument doc);
    }
}
