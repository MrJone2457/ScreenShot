using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using ScreenZ.Capture;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ScreenZ
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScreenzPage : Page
    {
        public ScreenzPage()
        {

            this.InitializeComponent();



            ScreenCapture screenCapture = new ScreenCapture();   //为什么不能直接调用类里面的方法呢

            string myPictures_Path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Directory.CreateDirectory(myPictures_Path + @"\ScreenShot");   //创建缓存文件夹

            
            string image_filename = myPictures_Path + @"\ScreenShot\image_temp.Png";   //设置缓存图片
screenCapture.CaptureScreenToFile(image_filename, ImageFormat.Png);

            ScreenImage.Source = new BitmapImage(new System.Uri(image_filename));   //前端显示

            ExitStoryboard.Begin();
        }

        private void Button_ClickAsync(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Text_1.Text= PrimaryScreen.DESKTOP.Height.ToString();
            Text_2.Text = PrimaryScreen.GetScreenSize.Height.ToString();
        }

        private void MyButton_Click_1(object sender, RoutedEventArgs e)
        {
            var _appWindow =  MainWindow.Instance.GetAppWindow();
            if (_appWindow.Presenter.Kind == AppWindowPresenterKind.FullScreen)
            {
                _appWindow.SetPresenter(AppWindowPresenterKind.Default);
                myButton.Content = "Full Screen";
            }
            else
            {
                _appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);
                myButton.Content = "Exit Full Screen";
            }
        }

        private void ScreenshotButton_ClickAsync(object sender, RoutedEventArgs e)
        {

        }

        public void Screen()
        {

        }

    }
}
