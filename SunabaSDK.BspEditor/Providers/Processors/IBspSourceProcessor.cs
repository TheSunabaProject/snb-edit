using SunabaSDK.BspEditor.Documents;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Providers.Processors
{
    public interface IBspSourceProcessor
    {
        string OrderHint { get; }
        Task AfterLoad(MapDocument document);
        Task BeforeSave(MapDocument document);
    }
}
