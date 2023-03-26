﻿using SunabaSDK.BspEditor.Primitives;
using SunabaSDK.BspEditor.Primitives.MapObjectData;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.Common.Transport;
using SunabaSDK.DataStructures.Geometric;
using SunabaSDK.Rendering.Interfaces;
using System.ComponentModel.Composition;
using System.Numerics;
using System.Runtime.Serialization;

namespace SunabaSDK.BspEditor.Rendering.ChangeHandlers
{
    public class EntityModel : IMapObjectData, IContentsReplaced, IBoundingBoxProvider
    {
        public string Name { get; }
        public IModelRenderable Renderable { get; }

        public bool ContentsReplaced => Renderable != null;

        public EntityModel(string name, IModelRenderable renderable)
        {
            Name = name;
            Renderable = renderable;
        }

        public EntityModel(SerialisedObject obj)
        {
            Name = obj.Get<string>("Name");
        }

        [Export(typeof(IMapElementFormatter))]
        public class ActiveTextureFormatter : StandardMapElementFormatter<EntityModel> { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
        }

        public Box GetBoundingBox(IMapObject obj)
        {
            if (Renderable == null) return null;

            var model = Renderable.Model;
            var origin = obj.Data.GetOne<Origin>()?.Location ?? Vector3.Zero;
            var (min, max) = Renderable.GetBoundingBox();
            return new Box(min, max);
            //return new Box(model.Mins + origin, model.Maxs + origin);
        }

        public IMapElement Copy(UniqueNumberGenerator numberGenerator)
        {
            return Clone();
        }

        public IMapElement Clone()
        {
            return new EntityModel(Name, null);
        }

        public SerialisedObject ToSerialisedObject()
        {
            var so = new SerialisedObject(nameof(EntityModel));
            so.Set(nameof(Name), Name);
            return so;
        }
    }
}