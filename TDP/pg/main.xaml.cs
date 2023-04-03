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
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        public main()
        {
            InitializeComponent();
        }

        private void BNewDetail_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pg.newdetail());
        }

        private void BNewEntry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BView_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
