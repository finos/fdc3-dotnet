/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Windows;
using WpfFdc3.Fdc3;

namespace WpfFdc3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new Workbench(new ViewModels.WorkbenchViewModel(new DesktopAgent())).Show();
        }
    }
}
