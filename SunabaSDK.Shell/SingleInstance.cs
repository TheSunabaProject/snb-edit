﻿using LogicAndTrick.Oy;
using Microsoft.VisualBasic.ApplicationServices;
using System.Linq;
using System.Windows.Forms;

namespace SunabaSDK.Shell
{
    public class SingleInstance : WindowsFormsApplicationBase
    {
        public SingleInstance(Form form)
        {
            IsSingleInstance = true;
            MainForm = form;
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs e)
        {
            e.BringToForeground = true;
            base.OnStartupNextInstance(e);
            Oy.Publish("Shell:InstanceOpened", e.CommandLine.ToList());
        }
    }
}
