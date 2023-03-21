using System.Numerics;

namespace SNBEdit.Providers.Model.Mdl10.Format
{
    public struct MeshVertex
    {
        public int VertexBone;
        public int NormalBone;
        public Vector3 Vertex;
        public Vector3 Normal;
        public Vector2 Texture;
    }
}