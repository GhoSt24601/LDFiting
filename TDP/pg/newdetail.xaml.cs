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

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для newdetail.xaml
    /// </summary>
    public partial class newdetail : Page
    {
        public newdetail()
        {
            InitializeComponent();
        }
        
        private void BNewDetail_Click(object sender, RoutedEventArgs e)
        {
            f2.Navigate(new pg.ND());
        }
        private void BNewDetailType_Click(object sender, RoutedEventArgs e)
        {
            f2.Navigate(new pg.NDT());
        }
        private void BNewDetailSize_Click(object sender, RoutedEventArgs e)
        {
            f2.Navigate(new pg.NDS());
        }
        private void BNewDefect_Click(object sender, RoutedEventArgs e)
        {
            f2.Navigate(new pg.DF());
        }
        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pg.main());
        }

    }
}
