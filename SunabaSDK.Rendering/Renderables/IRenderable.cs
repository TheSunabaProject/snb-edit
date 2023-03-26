using SunabaSDK.Rendering.Engine;
using SunabaSDK.Rendering.Pipelines;
using SunabaSDK.Rendering.Viewports;
using System;
using System.Collections.Generic;
using System.Numerics;
using Veldrid;

namespace SunabaSDK.Rendering.Renderables
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
