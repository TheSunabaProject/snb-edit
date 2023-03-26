using SunabaSDK.Rendering.Engine;
using SunabaSDK.Rendering.Renderables;
using SunabaSDK.Rendering.Viewports;
using System;
using System.Collections.Generic;
using Veldrid;

namespace SunabaSDK.Rendering.Pipelines
{
    public interface IPipeline : IDisposable
    {
        PipelineType Type { get; }
        PipelineGroup Group { get; }
        float Order { get; }

        void Create(RenderContext context);
        void SetupFrame(RenderContext context, IViewport target);
        void Render(RenderContext context, IViewport target, CommandList cl, IEnumerable<IRenderable> renderables);
        void Render(RenderContext context, IViewport target, CommandList cl, IRenderable renderable, ILocation locationObject);
        void Bind(RenderContext context, CommandList cl, string binding);
    }
}
