﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sledge.Rendering.Interfaces;
using Veldrid;

namespace Sledge.Rendering.Engine
{
    public class RenderContext : IUpdateable
    {
        public ResourceLoader ResourceLoader { get; }
        public GraphicsDevice Device { get; }

        public RenderContext(GraphicsDevice device)
        {
            Device = device;
            ResourceLoader = new ResourceLoader(this);
        }

        private long _lastFrame;
        public void Update(long frame)
        {
            if (frame < _lastFrame + 10000) return;
            _lastFrame = frame;

            ResourceLoader.DeleteUnreferencedTextures();
        }
    }
}
