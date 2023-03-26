﻿using SunabaSDK.BspEditor.Documents;
using SunabaSDK.BspEditor.Modification;
using SunabaSDK.BspEditor.Primitives.MapObjects;
using SunabaSDK.Common.Shell.Context;
using SunabaSDK.Common.Translations;
using SunabaSDK.Shell;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunabaSDK.BspEditor.Editing.Components.Properties.Tabs
{
    /// <summary>
    /// The tab that appears when nothing is selected.
    /// </summary>
    [AutoTranslate]
    [Export(typeof(IObjectPropertyEditorTab))]
    public partial class EmptyTab : UserControl, IObjectPropertyEditorTab
    {
        public string OrderHint => "_";
        public Control Control => this;

        public string NothingIsSelected
        {
            get => lblNothing.Text;
            set => this.InvokeLater(() => lblNothing.Text = value);
        }

        public bool HasChanges => false;
        string IObjectPropertyEditorTab.Name => "";

        public event PropertyChangedEventHandler PropertyChanged;

        public EmptyTab()
        {
            InitializeComponent();
            CreateHandle();
        }

        public bool IsInContext(IContext context, List<IMapObject> objects)
        {
            return !context.TryGet("ActiveDocument", out MapDocument _) || !objects.Any();
        }

        public Task SetObjects(MapDocument document, List<IMapObject> objects)
        {
            return Task.FromResult(0);
        }

        public IEnumerable<IOperation> GetChanges(MapDocument document, List<IMapObject> objects)
        {
            yield break;
        }
    }
}
