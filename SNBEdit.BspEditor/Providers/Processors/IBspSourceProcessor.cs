using SNBEdit.BspEditor.Documents;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Providers.Processors
{
    public interface IBspSourceProcessor
    {
        string OrderHint { get; }
        Task AfterLoad(MapDocument document);
        Task BeforeSave(MapDocument document);
    }
}
