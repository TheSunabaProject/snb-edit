using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Modification;
using SNBEdit.BspEditor.Modification.Operations.Data;
using SNBEdit.BspEditor.Primitives.MapObjectData;
using SNBEdit.BspEditor.Primitives.MapObjects;
using SNBEdit.Common.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Editing.Problems
{
    [Export(typeof(IProblemCheck))]
    [AutoTranslate]
    public class DuplicateKeyValues : IProblemCheck
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Uri Url => null;
        public bool CanFix => true;

        public Task<List<Problem>> Check(MapDocument document, Predicate<IMapObject> filter)
        {
            var entities = document.Map.Root.FindAll()
                .Where(x => filter(x))
                .Select(x => new { Object = x, EntityData = x.Data.GetOne<EntityData>() })
                .Where(x => x.EntityData != null && HasDuplicateKeyValues(x.EntityData))
                .Select(x => new Problem().Add(x.Object).Add(x.EntityData))
                .ToList();

            return Task.FromResult(entities);
        }

        private bool HasDuplicateKeyValues(EntityData data)
        {
            return data.Properties.GroupBy(x => x.Key.ToLowerInvariant()).Any(x => x.Count() > 1);
        }

        public Task Fix(MapDocument document, Problem problem)
        {
            // This error should only come from external sources (map loading, etc) as the EditEntityDataProperties
            // simply doesn't allow adding duplicate keys at all.

            var transaction = new Transaction();

            foreach (var obj in problem.Objects)
            {
                var data = obj.Data.GetOne<EntityData>();
                if (data == null) continue;

                var vals = new Dictionary<string, string>();

                // Set the key to the first found value
                var groups = data.Properties.GroupBy(x => x.Key.ToLowerInvariant()).Where(x => x.Count() > 1);
                foreach (var g in groups)
                {
                    vals[g.Key] = g.First().Value;
                }

                transaction.Add(new EditEntityDataProperties(obj.ID, vals));
            }

            return MapDocumentOperation.Perform(document, transaction);
        }
    }
}