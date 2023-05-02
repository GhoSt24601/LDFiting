using MahApps.Metro.IconPacks;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TDP.pg;

namespace TDP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MD(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton==MouseButton.Left)
            {
                DragMove();
            }
        }

        private void BFull_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
            {
                WindowState = WindowState.Maximized;
            }
            else 
            { 
                WindowState = WindowState.Normal; 
            }
        }

        private void BMin_Click(object sender, RoutedEventArgs e)
        {
                WindowState = WindowState.Minimized;
        }
        public bool isWiden;
        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isWiden = true;
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isWiden = false;
            PackIconMaterial rect = (PackIconMaterial)sender;
            rect.ReleaseMouseCapture();
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            PackIconMaterial rect = (PackIconMaterial)sender;
            if (isWiden)
            {
                rect.CaptureMouse();
                double newWidth = e.GetPosition(this).X + 5;
                double newHeight = e.GetPosition(this).Y + 5;
                if (newWidth > 0) this.Width = newWidth;
                if (newHeight > 0) this.Height = newHeight;
            }
        }
       
        private void RBView_Checked(object sender, RoutedEventArgs e)
        {
            f1.Navigate(new pg.fview());
        }
        private void RBNewStroke_Checked(object sender, RoutedEventArgs e)
        {
            f1.Navigate(new pg.EntryView());
        }
        private void RBNewDetail_Checked(object sender, RoutedEventArgs e)
        {
            f1.Navigate(new pg.View());
        }
    }
}
