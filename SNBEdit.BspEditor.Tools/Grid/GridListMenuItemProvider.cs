﻿using SNBEdit.BspEditor.Documents;
using SNBEdit.BspEditor.Grid;
using SNBEdit.BspEditor.Modification;
using SNBEdit.BspEditor.Modification.Operations;
using SNBEdit.BspEditor.Primitives.MapData;
using SNBEdit.Common.Shell.Context;
using SNBEdit.Common.Shell.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Threading.Tasks;

namespace SNBEdit.BspEditor.Tools.Grid
{
    [Export(typeof(IMenuItemProvider))]
    public class GridListMenuItemProvider : IMenuItemProvider
    {
        [ImportMany] private IEnumerable<Lazy<IGridFactory>> _grids;

        public event EventHandler MenuItemsChanged;

        public IEnumerable<IMenuItem> GetMenuItems()
        {
            foreach (var grid in _grids)
            {
                yield return new GridMenuItem(grid.Value);
            }
        }

        private class GridMenuItem : IMenuItem
        {
            public string ID => "SNBEdit.BspEditor.Tools.Grid.GridMenuItem." + GridFactory.GetType().Name;
            public string Name => GridFactory.Name;
            public string Description => GridFactory.Details;
            public Image Icon => GridFactory.Icon;
            public bool AllowedInToolbar => false;
            public string Section => "Map";
            public string Path => "";
            public string Group => "GridTypes";
            public string OrderHint => Group.GetType().Name;
            public string ShortcutText => "";
            public bool IsToggle => false;

            public IGridFactory GridFactory { get; set; }

            public GridMenuItem(IGridFactory gridFactory)
            {
                GridFactory = gridFactory;
            }

            public bool IsInContext(IContext context)
            {
                return context.TryGet("ActiveDocument", out MapDocument _);
            }

            public async Task Invoke(IContext context)
            {
                if (context.TryGet("ActiveDocument", out MapDocument doc))
                {
                    var grid = await GridFactory.Create(doc.Environment);

                    var gd = new GridData(grid);
                    var operation = new TrivialOperation(x => doc.Map.Data.Replace(gd), x => x.Update(gd));

                    await MapDocumentOperation.Perform(doc, operation);

                }
            }

            public bool GetToggleState(IContext context)
            {
                return false;
            }
        }
    }
}
