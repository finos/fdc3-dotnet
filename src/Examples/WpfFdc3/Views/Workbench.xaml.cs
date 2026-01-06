/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Windows;
using WpfFdc3.ViewModels;

namespace WpfFdc3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Workbench : Window
    {
        private readonly WorkbenchViewModel? ViewModel;

        public Workbench()
        {
            InitializeComponent();
        }

        public Workbench(WorkbenchViewModel viewModel) : this()
        {
            this.DataContext = this.ViewModel = viewModel;
        }
    }
}
