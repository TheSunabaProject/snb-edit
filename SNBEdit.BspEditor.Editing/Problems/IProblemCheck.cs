using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Primitives.MapObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Editing.Problems
{
    public interface IProblemCheck
    {
        string Name { get; }
        string Details { get; }
        Uri Url { get; }
        bool CanFix { get; }

        Task<List<Problem>> Check(MapDocument document, Predicate<IMapObject> filter);
        Task Fix(MapDocument document, Problem problem);
    }
}
