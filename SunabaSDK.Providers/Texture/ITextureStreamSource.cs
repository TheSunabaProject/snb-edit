using System;
using System.Drawing;
using System.Threading.Tasks;

namespace SunabaSDK.Providers.Texture
{
    public interface ITextureStreamSource : IDisposable
    {
        bool HasImage(string item);
        Task<Bitmap> GetImage(string item, int maxWidth, int maxHeight);
    }
}