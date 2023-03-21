using SNBEdit.FileSystem;
using SNBEdit.Rendering.Interfaces;
using System.Threading.Tasks;

namespace SNBEdit.Providers.Model
{
    public interface IModelProvider
    {
        bool CanLoadModel(IFile file);
        Task<IModel> LoadModel(IFile file);

        bool IsProvider(IModel model);
        IModelRenderable CreateRenderable(IModel model);
    }
}
