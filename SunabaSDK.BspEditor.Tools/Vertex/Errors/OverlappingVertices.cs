﻿using SunabaSDK.BspEditor.Tools.Vertex.Selection;
using SunabaSDK.DataStructures.Geometric;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace SunabaSDK.BspEditor.Tools.Vertex.Errors
{
    [Export(typeof(IVertexErrorCheck))]
    public class OverlappingVertices : IVertexErrorCheck
    {
        private const string Key = "SunabaSDK.BspEditor.Tools.Vertex.Errors.OverlappingVertices";

        public IEnumerable<VertexError> GetErrors(VertexSolid solid)
        {
            foreach (var face in solid.Copy.Faces)
            {
                var overlapping = face.Vertices.GroupBy(x => x.Position.Round(2)).Where(x => x.Count() > 1).ToList();
                foreach (var ol in overlapping)
                {
                    yield return new VertexError(Key, solid).Add(face).Add(ol);
                }
            }
        }
    }
}