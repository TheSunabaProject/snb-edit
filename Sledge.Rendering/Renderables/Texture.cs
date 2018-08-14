﻿using Sledge.Rendering.Engine;
using Sledge.Rendering.Interfaces;
using Veldrid;

namespace Sledge.Rendering.Renderables
{
    internal class Texture
    {
        internal int RefCount { get; set; }

        private readonly Veldrid.Texture _texture;
        private readonly TextureView _view;
        private readonly ResourceSet _set;

        private bool _mipsGenerated;

        public Texture(RenderContext context, ITextureDataSource source)
        {
            uint w = (uint) source.Width, h = (uint) source.Height;

            var device = context.Device;
            _texture = device.ResourceFactory.CreateTexture(TextureDescription.Texture2D(
                w, h, 4, 1,
                PixelFormat.B8_G8_R8_A8_UNorm,
                TextureUsage.Sampled | TextureUsage.GenerateMipmaps
            ));
            
            device.UpdateTexture(_texture, source.GetData(), 0, 0, 0, w, h, _texture.Depth, 0, 0);
            _mipsGenerated = false;

            _view = device.ResourceFactory.CreateTextureView(_texture);
            _set = device.ResourceFactory.CreateResourceSet(new ResourceSetDescription(
                context.ResourceLoader.TextureLayout, _view, context.ResourceLoader.TextureSampler
            ));
        }

        public void BindTo(CommandList cl, uint slot)
        {
            if (!_mipsGenerated)
            {
                cl.GenerateMipmaps(_texture);
                _mipsGenerated = true;
            }

            cl.SetGraphicsResourceSet(slot, _set);
        }

        public void Inc() => RefCount++;
        public void Dec() => RefCount--;

        public void Dispose()
        {
            _set.Dispose();
            _view.Dispose();
            _texture.Dispose();
        }
    }
}