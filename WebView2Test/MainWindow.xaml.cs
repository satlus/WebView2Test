using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

using System.Windows.Media.Imaging;

namespace WebView2Test
{
    public partial class MainWindow : Window
    {
        private Boolean snapshotEnabled = false;

        public MainWindow()
        {
            InitializeComponent();
            this.SizeChanged += MainWindow_SizeChanged;

            perspective1.DefaultBackgroundColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            perspective2.DefaultBackgroundColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            perspective3.DefaultBackgroundColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            perspective4.DefaultBackgroundColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelectTab1(object sender, RoutedEventArgs e)
        {
            TabControl1.SelectedIndex = 0;
        }

        private void SelectTab2(object sender, RoutedEventArgs e)
        {
            TabControl1.SelectedIndex = 1;
        }

        private void SelectTab3(object sender, RoutedEventArgs e)
        {
            TabControl1.SelectedIndex = 2;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Begin dragging the window
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!snapshotEnabled) { return; }

            if (e.PreviousSize != Size.Empty && e.WidthChanged)
            {
                ShowWebViewSnapshot(perspective1, Snapshot1);
                ShowWebViewSnapshot(perspective2, Snapshot2);
                ShowWebViewSnapshot(perspective3, Snapshot3);
                ShowWebViewSnapshot(perspective4, Snapshot4);

                // Use a dispatcher to delay the hide operation
               /** this.Dispatcher.BeginInvoke(new Action<WebView2, System.Drawing.Image>(HideWebViewSnapshot), DispatcherPriority.ContextIdle, perspective1, Snapshot1);
                this.Dispatcher.BeginInvoke(new Action<WebView2, System.Drawing.Image>(HideWebViewSnapshot), DispatcherPriority.ContextIdle, perspective2, Snapshot2);
                this.Dispatcher.BeginInvoke(new Action<WebView2, System.Drawing.Image>(HideWebViewSnapshot), DispatcherPriority.ContextIdle, perspective3, Snapshot3);
                this.Dispatcher.BeginInvoke(new Action<WebView2, System.Drawing.Image>(HideWebViewSnapshot), DispatcherPriority.ContextIdle, perspective4, Snapshot4);
            **/
                }
        }

        private async void ShowWebViewSnapshot(WebView2 webView, Image snapshotImage)
        {
            if (webView.ActualWidth <= 0 || webView.ActualHeight <= 0 || webView.CoreWebView2 == null)
                return; // Skip capturing if dimensions are not valid or WebView2 hasn't been initialized yet.

            using (var imageStream = new MemoryStream())
            {
                await webView.CoreWebView2.CapturePreviewAsync(CoreWebView2CapturePreviewImageFormat.Png, imageStream);
                imageStream.Seek(0, SeekOrigin.Begin); // Reset stream position

                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = imageStream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                snapshotImage.Source = bitmap;
            }

            snapshotImage.Visibility = Visibility.Visible;
            webView.Visibility = Visibility.Collapsed;
        }

        private void HideWebViewSnapshot(WebView2 webView, System.Drawing.Image snapshotImage)
        {
            /**snapshotImage.Visibility = Visibility.Collapsed;**/
            webView.Visibility = Visibility.Visible;
        }
    }
}
