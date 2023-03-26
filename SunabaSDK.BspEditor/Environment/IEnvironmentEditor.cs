using SunabaSDK.Common.Translations;
using System;
using System.Windows.Forms;

namespace SunabaSDK.BspEditor.Environment
{
    public interface IEnvironmentEditor : IManualTranslate
    {
        event EventHandler EnvironmentChanged;
        Control Control { get; }
        IEnvironment Environment { get; set; }
    }
}