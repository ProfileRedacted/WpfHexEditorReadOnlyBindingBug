﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfHexEditor.ReadOnlyBinding {

    public partial class App : Application {

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            MainWindow window = new MainWindow();    
            MainWindowViewModel viewModel = new MainWindowViewModel();    
            window.DataContext = viewModel;
            MainWindow = window;
            window.Show();    
        }

    }

}
