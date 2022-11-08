using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using System;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ScreenZ
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public AppWindow _appWindow;
        public static MainWindow Instance;

        public MainWindow()
        {
            Instance = this;
            this.InitializeComponent();
            _appWindow = GetAppWindowForCurrentWindow();
            _appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);
        }

        public AppWindow GetAppWindow() {
            return _appWindow;
        }


        /// <summary>
        /// 获取当前窗口的句柄
        /// </summary>
        /// <returns></returns>
        private AppWindow GetAppWindowForCurrentWindow()   
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(myWndId);
        }


    }
}
