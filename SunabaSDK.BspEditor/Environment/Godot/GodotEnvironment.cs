using SunabaSDK.BspEditor.Compile;
using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Primitives.MapData;
using SunabaSDK.DataStructures.GameData;
using SunabaSDK.FileSystem;
using SunabaSDK.Providers.Texture;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Environment.Godot
{
    public class GodotEnvironment : IEnvironment
    {
        public string Engine => "Godot";
        public string ID => "Godot";
        public string Name => "Godot";
        public IFile Root => null;
        public IEnumerable<string> Directories => new string[0];

        public async Task<TextureCollection> GetTextureCollection()
        {
            return new GodotTextureCollection(new TexturePackage[0]);
        }

        public async Task<GameData> GetGameData()
        {
            return new GameData();
        }

        public Task UpdateDocumentData(MapDocument document)
        {
            return Task.FromResult(0);
        }

        public void AddData(IEnvironmentData data)
        {

        }

        public IEnumerable<T> GetData<T>() where T : IEnvironmentData
        {
            return null;
        }

        public Task<Batch> CreateBatch(IEnumerable<BatchArgument> arguments, BatchOptions options)
        {
            return Task.FromResult<Batch>(null);
        }

        public IEnumerable<AutomaticVisgroup> GetAutomaticVisgroups()
        {
            yield break;
        }

        public bool IsNullTexture(string name)
        {
            return false;
        }

        public string DefaultBrushEntity => "";
        public string DefaultPointEntity => "";
        public decimal DefaultTextureScale => 1;
    }
}
