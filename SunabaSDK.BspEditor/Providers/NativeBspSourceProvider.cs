﻿using SunabaSDK.BspEditor.Environment;
using SunabaSDK.BspEditor.Primitives;
using SunabaSDK.BspEditor.Primitives.MapData;
using SunabaSDK.BspEditor.Primitives.MapObjectData;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.Common.Shell.Documents;
using SunabaSDK.Common.Transport;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SunabaSDK.BspEditor.Providers
{
    [Export(typeof(IBspSourceProvider))]
    public class NativeBspSourceProvider : IBspSourceProvider
    {
        private readonly SerialisedObjectFormatter _formatter;
        private readonly MapElementFactory _factory;

        private static readonly IEnumerable<Type> SupportedTypes = new List<Type>
        {
            // Just everything
            typeof(IMapObject),
            typeof(IMapObjectData),
            typeof(IMapData),
        };

        public IEnumerable<Type> SupportedDataTypes => SupportedTypes;

        [ImportingConstructor]
        public NativeBspSourceProvider([Import] Lazy<SerialisedObjectFormatter> formatter, [Import] Lazy<MapElementFactory> factory)
        {
            _formatter = formatter.Value;
            _factory = factory.Value;
        }

        public IEnumerable<FileExtensionInfo> SupportedFileExtensions { get; } = new[]
        {
            new FileExtensionInfo("Sledge map format", ".smf"),
        };

        public async Task<BspFileLoadResult> Load(Stream stream, IEnvironment environment)
        {
            return await Task.Factory.StartNew(() =>
            {
                var result = new BspFileLoadResult();

                var map = new Map();
                var so = _formatter.Deserialize(stream);
                foreach (var o in so)
                {
                    if (o.Name == nameof(Root))
                    {
                        map.Root.Unclone((Root)_factory.Deserialise(o));
                    }
                    else
                    {
                        map.Data.Add((IMapData)_factory.Deserialise(o));
                    }
                }
                map.Root.DescendantsChanged();

                result.Map = map;
                return result;
            });
        }

        public Task Save(Stream stream, Map map)
        {
            return Task.Factory.StartNew(() =>
            {
                var list = new List<SerialisedObject>
                {
                    _factory.Serialise(map.Root)
                };
                list.AddRange(map.Data.Select(_factory.Serialise).Where(x => x != null));
                _formatter.Serialize(stream, list);
            });
        }
    }
}