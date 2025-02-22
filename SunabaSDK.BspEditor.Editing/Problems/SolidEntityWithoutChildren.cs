using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Modification;
using SunabaSDK.BspEditor.Modification.Operations.Tree;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.Common.Translations;
using SunabaSDK.DataStructures.GameData;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Editing.Problems
{
    [Export(typeof(IProblemCheck))]
    [AutoTranslate]
    public class SolidEntityWithoutChildren : IProblemCheck
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Uri Url => null;
        public bool CanFix => true;

        public async Task<List<Problem>> Check(MapDocument document, Predicate<IMapObject> filter)
        {
            var gamedata = await document.Environment.GetGameData();
            return document.Map.Root.FindAll()
                .OfType<Entity>()
                .Where(x => !x.Hierarchy.HasChildren)
                .Where(x => filter(x))
                .Select(x => new { Object = x, x.EntityData })
                .Where(x => x.EntityData != null)
                .Select(x => new { x.Object, x.EntityData, GameData = gamedata.GetClass(x.EntityData.Name) })
                .Where(x => x.GameData != null && x.GameData.ClassType == ClassType.Solid)
                .Select(x => new Problem().Add(x.Object))
                .ToList();
        }

        public Task Fix(MapDocument document, Problem problem)
        {
            var transaction = new Transaction();

            foreach (var obj in problem.Objects)
            {
                transaction.Add(new Detatch(obj.Hierarchy.Parent.ID, obj));
            }

            return MapDocumentOperation.Perform(document, transaction);
        }
    }
}