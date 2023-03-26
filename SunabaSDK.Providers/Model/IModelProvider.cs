using SunabaSDK.FileSystem;
using SunabaSDK.Rendering.Interfaces;
using System.Threading.Tasks;

namespace SunabaSDK.Providers.Model
{
    public interface IModelProvider
    {
        bool CanLoadModel(IFile file);
        Task<IModel> LoadModel(IFile file);

        bool IsProvider(IModel model);
        IModelRenderable CreateRenderable(IModel model);
    }
}
