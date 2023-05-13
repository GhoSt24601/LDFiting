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
    /// Логика взаимодействия для EntryView.xaml
    /// </summary>
    public partial class EntryView : Page
    {
        public EntryView()
        {
            InitializeComponent();
            DataContext = this;

        }
        private void RBForging_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(new pg.PForging());
        }

        private void RBSharping_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(new pg.PSharping());
        }

        private void RBLat_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(new pg.explat());
        }

        private void RBNik_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(new pg.expnik());
        }
        private void RBDef_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(new pg.pdefect());
        }
    }
}
