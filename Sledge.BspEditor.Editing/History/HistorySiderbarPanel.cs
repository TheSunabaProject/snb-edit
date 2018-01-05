﻿using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicAndTrick.Oy;
using Sledge.BspEditor.Documents;
using Sledge.Common.Shell.Components;
using Sledge.Common.Shell.Context;
using Sledge.Common.Shell.Documents;
using Sledge.Common.Translations;
using Sledge.Shell;

namespace Sledge.BspEditor.Editing.History
{
    [Export(typeof(ISidebarComponent))]
    [AutoTranslate]
    public partial class HistorySiderbarPanel : UserControl, ISidebarComponent
    {
        public string Title { get; set; } = "History";
        public object Control => this;

        private WeakReference<MapDocument> _activeDocument;

        public HistorySiderbarPanel()
        {
            InitializeComponent();

            Oy.Subscribe<IDocument>("Document:Activated", DocumentActivated);
            Oy.Subscribe<MapDocument>("MapDocument:HistoryChanged", HistoryChanged);
        }

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        private async Task HistoryChanged(MapDocument doc)
        {
            if (_activeDocument != null && _activeDocument.TryGetTarget(out MapDocument d) && d == doc)
            {
                await this.InvokeAsync(Rebuild);
            }
        }

        private async Task DocumentActivated(IDocument document)
        {
            var doc = document as MapDocument;
            _activeDocument = new WeakReference<MapDocument>(doc);
            await this.InvokeAsync(Rebuild);
        }

        private void Rebuild()
        {
            TreeNode lastNode = null;
            HistoryView.BeginUpdate();

            HistoryView.Nodes.Clear();
            if (_activeDocument.TryGetTarget(out MapDocument md))
            {
                var nodes = HistoryView.Nodes;
                var stack = md.Map.Data.GetOne<HistoryStack>();
                if (stack != null)
                {
                    foreach (var item in stack.GetOperations())
                    {
                        lastNode = nodes.Add(item.GetType().Name);
                    }
                }
            }

            HistoryView.EndUpdate();
            lastNode?.EnsureVisible();
        }
    }
}
