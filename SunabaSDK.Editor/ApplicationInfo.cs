﻿using SunabaSDK.Common.Shell;
using System;
using System.ComponentModel.Composition;
using System.IO;

namespace SunabaSDK.Editor
{
    [Export(typeof(IApplicationInfo))]
    public class ApplicationInfo : IApplicationInfo
    {
        private string Name => "SunabaSDK";

        public string GetApplicationSettingsFolder(string subfolder)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Name);
            if (String.IsNullOrWhiteSpace(subfolder)) return path;
            return Path.Combine(path, subfolder);
        }
    }
}
