using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RaceManagerHub.View
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _normalWidth;
        private double _normalHeight;
        private double _normalLeft;
        private double _normalTop;
        public MainWindow()
        {
            InitializeComponent();
        }

//        private void Close_Handler(object sender, RoutedEventArgs e)
//        {
//            Application.Current.Shutdown();
//            this.Loaded += MainWindow_Loaded;
//        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            var screenHeight = SystemParameters.PrimaryScreenHeight;

            var taskBarHeight = screenHeight - SystemParameters.WorkArea.Height;

            this.Left = 0;
            this.Top = 0;
            this.Width = screenWidth;
            this.Height = screenHeight - taskBarHeight;
        }


        private void DragMove_Handler(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {

                if (e.ClickCount == 2)
                {
                    e.Handled = true;
                    ToggleWindowState();
                }
                else
                {
                    this.DragMove();
                    var screenHeight = SystemParameters.PrimaryScreenHeight;
                    var taskBarHeight = screenHeight - SystemParameters.WorkArea.Height;

                    if (this.Top <= 0)
                    {
                        _normalWidth = this.Width;
                        _normalHeight = this.Height;
                        _normalLeft = this.Left;
                        _normalTop = this.Top;

                        this.Left = 0;
                        this.Top = 0;
                        this.Width = SystemParameters.PrimaryScreenWidth;
                        this.Height = screenHeight - taskBarHeight;
                    }
                }
            }
        }

        private void ToggleWindowState()
        {
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            var screenHeight = SystemParameters.PrimaryScreenHeight;
            var taskBarHeight = screenHeight - SystemParameters.WorkArea.Height;

            if (this.Width != screenWidth || this.Height != screenHeight - taskBarHeight)
            {

                _normalWidth = this.Width;
                _normalHeight = this.Height;
                _normalLeft = this.Left;
                _normalTop = this.Top;


                this.Left = 0;
                this.Top = 0;
                this.Width = screenWidth;
                this.Height = screenHeight - taskBarHeight;
            }
            else
            {
                this.Width = _normalWidth;
                this.Height = _normalHeight;
                this.Left = _normalLeft;
                this.Top = _normalTop;
            }
        }

        private void CloseWindowCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CloseWindowExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void RestoreWindowExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            var screenHeight = SystemParameters.PrimaryScreenHeight;
            var taskBarHeight = screenHeight - SystemParameters.WorkArea.Height;

            if (WindowState != WindowState.Maximized)
            {
                _normalWidth = this.Width;
                _normalHeight = this.Height;
                _normalLeft = this.Left;
                _normalTop = this.Top;

                this.Left = 0;
                this.Top = 0;
                this.Width = screenWidth;
                this.Height = screenHeight - taskBarHeight;
            }
            else
            {
                this.Width = _normalWidth;
                this.Height = _normalHeight;
                this.Left = _normalLeft;
                this.Top = _normalTop;
            }
        }

        private void RestoreindowCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute= true;
        }

        private void MinimizeWindowExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MinimizeWindowCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


    }
}
