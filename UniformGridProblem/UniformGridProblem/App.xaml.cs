using Microsoft.UI.Xaml;
using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using WinRT;
using Windows.ApplicationModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UniformGridProblem
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public static IntPtr WindowHandle { get; set; }

        public static ServiceContainer Services { get; set; } = new ServiceContainer();

        public static void SetWindowSize(IntPtr hwnd, double x, double y, double width, double height)
        {
            //var dpi = PInvoke.User32.GetDpiForWindow(hwnd);
            //float scalingFactor = (float)dpi / 96;
            ////x = (int)(x * scalingFactor);
            ////y = (int)(y * scalingFactor);
            //width = (int)(width * scalingFactor);
            //height = (int)(height * scalingFactor);

            //PInvoke.User32.SetWindowPos(
            //    hwnd, 
            //    PInvoke.User32.SpecialWindowHandles.HWND_TOP,
            //    (int)x,
            //    (int)y,
            //    (int)width,
            //    (int)height,
            //    PInvoke.User32.SetWindowPosFlags.SWP_NOMOVE
            //);

            PInvoke.User32.SetWindowPos(hwnd, PInvoke.User32.SpecialWindowHandles.HWND_TOP, (int)x, (int)y, (int)width, (int)height, PInvoke.User32.SetWindowPosFlags.SWP_SHOWWINDOW);



        }

        public static void GetWindowSize(IntPtr hwnd, out (int X, int Y, int Width, int Height) bounds)
        {
            PInvoke.User32.GetWindowRect(hwnd, out PInvoke.RECT rect);
            bounds = (X: rect.left, Y: rect.top, Width: rect.right - rect.left, Height: rect.bottom - rect.top);
        }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            // TODO: Implement a switcher https://docs.microsoft.com/en-us/windows/winui/api/microsoft.ui.xaml.application.requestedtheme?view=winui-3.0
            App.Current.RequestedTheme = ApplicationTheme.Dark;

            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();

            var windowNative = m_window.As<IWindowNative>();
            WindowHandle = windowNative.WindowHandle;

            m_window.Activate();
        }

        private Window m_window;

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("EECDBF0E-BAE9-4CB6-A68E-9598E1CB57BB")]
        internal interface IWindowNative
        {
            IntPtr WindowHandle { get; }
        }
    }
}
