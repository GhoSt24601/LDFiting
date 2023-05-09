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
    /// Логика взаимодействия для fview.xaml
    /// </summary>
    public partial class fview : Page
    {
        public fview()
        {
            InitializeComponent();
        }

        private void RBP_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(new pg.VForging());
        }

        private void RBR_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(new pg.VSharping());
        }

        private void RBLat_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(new pg.VLat());
        }

        private void RBNik_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(new pg.VNik());
        }

        private void RBB_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(new pg.VBrak());
        }
    }
}
