using SNBEdit.Common.Translations;
using System;
using System.Windows.Forms;

namespace SNBEdit.BspEditor.Environment
{
    public interface IEnvironmentEditor : IManualTranslate
    {
        event EventHandler EnvironmentChanged;
        Control Control { get; }
        IEnvironment Environment { get; set; }
    }
}