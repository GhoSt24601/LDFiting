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
using System.Security.AccessControl;

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для details.xaml
    /// </summary>
    public partial class details : Page
    {
        public details()
        {
            InitializeComponent();
            DataContext = this;

            updateDetails();

        }
        public class ItemSort
        {
            public string DisplayName { get; set; }
            public string PropertyName { get; set; }
            public bool Ascending { get; set; }
        }
        public static ObservableCollection<ItemSort> ItemSorts { get; set; } = new ObservableCollection<ItemSort>()
        {
                new ItemSort(){DisplayName="По типу", PropertyName="DName", Ascending=true},
                new ItemSort(){DisplayName="По размеру", PropertyName="DSize", Ascending=true},
                new ItemSort(){DisplayName="По количеству ↑", PropertyName="DCount", Ascending=true},
                new ItemSort(){DisplayName="По количеству ↓", PropertyName="DCount", Ascending=false},
                new ItemSort(){DisplayName="По массе ↑", PropertyName="DMass", Ascending=true},
                new ItemSort(){DisplayName="По массе ↓", PropertyName="DMass", Ascending=false}
        };
        private void cbsorting(object sender, SelectionChangedEventArgs e)
        {
            var item = cbsort.SelectedItem as ItemSort;
            var view = CollectionViewSource.GetDefaultView(zerg.ItemsSource);
            var direction = item.Ascending ?
                ListSortDirection.Ascending :
                ListSortDirection.Descending;
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(item.PropertyName, direction));
        }
        public void updateDetails()
        {
            detailsb = new ObservableCollection<Detail>();
            conn.GetModel().Detail.ToList().ForEach(detail => detailsb.Add(detail));
            allstring.Content = "Записей: " + detailsb.Count.ToString();
            zerg.ItemsSource = detailsb;
        }
        public static ObservableCollection<Detail> detailsb { get; set; }
        pg.ND pgnd = new pg.ND();
        private void newdetail_Click(object sender, RoutedEventArgs e)
        {
            if (f4.Visibility == Visibility.Hidden || f4.NavigationService.Content==null)
            {
                f4.Visibility = Visibility.Visible;
                    pgnd = new pg.ND();
                    f4.Navigate(pgnd);
            }
            else
            {
                f4.Visibility = Visibility.Hidden;
                pgnd = null;
                updateDetails();
                GC.Collect();
            }
        }

        private void unvis(object sender, MouseButtonEventArgs e)
        {
            
            if (f4.Visibility == Visibility.Visible)
            {
                Point pt = e.GetPosition((UIElement)sender);
                HitTestResult result = VisualTreeHelper.HitTest(f4, pt);
                if (result != null)
                {
                    if (e.ChangedButton == MouseButton.Left)
                    {
                        f4.Visibility = Visibility.Hidden;
                        pgnd = null;
                        updateDetails();
                        GC.Collect();
                    }
                }
            }
        }

        private void sel(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
