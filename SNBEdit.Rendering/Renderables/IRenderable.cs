using SNBEdit.Rendering.Engine;
using SNBEdit.Rendering.Pipelines;
using SNBEdit.Rendering.Viewports;
using System;
using System.Collections.Generic;
using System.Numerics;
using Veldrid;

namespace SNBEdit.Rendering.Renderables
{
    public interface IRenderable : IDisposable
    {
        IEnumerable<ILocation> GetLocationObjects(IPipeline pipeline, IViewport viewport);
        bool ShouldRender(IPipeline pipeline, IViewport viewport);
        void Render(RenderContext context, IPipeline pipeline, IViewport viewport, CommandList cl);
        void Render(RenderContext context, IPipeline pipeline, IViewport viewport, CommandList cl, ILocation locationObject);
    }

    public interface ILocation
    {
        Vector3 Location { get; }
    }
}
