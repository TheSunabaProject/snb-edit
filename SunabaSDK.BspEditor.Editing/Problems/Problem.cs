using SunabaSDK.BspEditor.Primitives.MapObjectData;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using System.Collections.Generic;

namespace SunabaSDK.BspEditor.Editing.Problems
{
    public class Problem
    {
        public string Text { get; set; }
        public List<IMapObject> Objects { get; set; }
        public List<IMapObjectData> ObjectData { get; set; }

        public Problem()
        {
            Objects = new List<IMapObject>();
            ObjectData = new List<IMapObjectData>();
        }

        public Problem Add(IMapObject o)
        {
            Objects.Add(o);
            return this;
        }

        public Problem Add(IEnumerable<IMapObject> objs)
        {
            Objects.AddRange(objs);
            return this;
        }

        public Problem Add(IMapObjectData o)
        {
            ObjectData.Add(o);
            return this;
        }

        public Problem Add(IEnumerable<IMapObjectData> objs)
        {
            ObjectData.AddRange(objs);
            return this;
        }
    }
}