using SNBEdit.Rendering.Renderables;
using SNBEdit.Rendering.Resources;
using System.Numerics;

namespace SNBEdit.Rendering.Interfaces
{
    public interface IModelRenderable : IRenderable, IUpdateable, IResource
    {
        IModel Model { get; }
        Vector3 Origin { get; set; }
        Vector3 Angles { get; set; }
        int Sequence { get; set; }

        Matrix4x4 GetModelTransformation();
        (Vector3, Vector3) GetBoundingBox();
    }
}