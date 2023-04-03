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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.SqlTypes;
using TDP.Database;

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для View.xaml
    /// </summary>
    public partial class View : Page
    {
        
        public View()
        {
            InitializeComponent();
            DataContext= this;
           
        }
        pg.details pgd = new pg.details(); 
        pg.Types pgt = new pg.Types(); 
        pg.Sizes pgs = new pg.Sizes(); 
        pg.Defects pgdf = new pg.Defects(); 
        pg.DefectPlaces pgdp = new pg.DefectPlaces(); 
        private void RBDetails_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(pgd);
        }

        private void RBTypes_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(pgt);
        }

        private void RBSizes_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(pgs);
        }

        private void RBDefects_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(pgdf);
        }
        private void RBDefectPlaces_Checked(object sender, RoutedEventArgs e)
        {
            f3.Navigate(pgdp);
        }
    }
}
