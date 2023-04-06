using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using TDP.Database;

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для PSharping.xaml
    /// </summary>
    public partial class explat : Page
    {
        Database.Entities connection = new Database.Entities();
        public explat()
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
                new ItemSort(){DisplayName="По типу", PropertyName="ELName", Ascending=true},
                new ItemSort(){DisplayName="По размеру", PropertyName="ELSize", Ascending=true},
                new ItemSort(){DisplayName="По дате ↑", PropertyName="ELDate", Ascending=true},
                new ItemSort(){DisplayName="По дате ↓", PropertyName="ELDate", Ascending=false},
                new ItemSort(){DisplayName="По массе брутто ↑", PropertyName="ELKMassBrutto", Ascending=true},
                new ItemSort(){DisplayName="По массе брутто ↓", PropertyName="ELKMassBrutto", Ascending=false}
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
            exportlatb = new ObservableCollection<ExportLat>();
            connection.ExportLat.ToList().ForEach(detail => exportlatb.Add(detail));
            allstring.Content = "Записей: " + exportlatb.Count.ToString();
            zerg.ItemsSource = exportlatb;
        }
        public static ObservableCollection<ExportLat> exportlatb { get; set; }
        pg.nexplat pgs = new pg.nexplat();
        private void newdetail_Click(object sender, RoutedEventArgs e)
        {

            if (f4.Visibility == Visibility.Hidden || f4.NavigationService.Content == null)
            {
                f4.Visibility = Visibility.Visible;
                    pgs = new pg.nexplat();
                    f4.Navigate(pgs);
            }
            else
            {
                f4.Visibility = Visibility.Hidden;
                pgs = null;
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
                        pgs = null;
                        updateDetails();
                        GC.Collect();
                    }
                }
            }
        }

        private void sel(object sender, RoutedEventArgs e)
        {
            var k = (zerg.SelectedItem as ExportLat);
            var s = conn.GetModel().ExportLat.Where(q=> q.ELId==k.ELId).FirstOrDefault();
            if (s != null)
            {

            }
        }
    }
}   