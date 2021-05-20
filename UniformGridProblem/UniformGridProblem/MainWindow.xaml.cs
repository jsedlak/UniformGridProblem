using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UniformGridProblem.Pods;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UniformGridProblem
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private bool _hasActivated = false;

        public MainWindow()
        {
            this.InitializeComponent();

            this.Activated += (s, e) => {
                if (_hasActivated) { return; }
                _hasActivated = true;
                App.SetWindowSize(App.WindowHandle, 200, 200, 200, 200);

                Pods.Add(new TestPod());
                Pods.Add(new TestPod());
                Pods.Add(new TestPod());
                Pods.Add(new TestPod());
                Pods.Add(new TestPod());
                Pods.Add(new TestPod());
            };
        }

        public ObservableCollection<object> Pods = new();
    }
}
