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
    public partial class PSharping : Page
    {
        Database.Entities connection = new Database.Entities();
        public PSharping()
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
                new ItemSort(){DisplayName="По типу", PropertyName="SName", Ascending=true},
                new ItemSort(){DisplayName="По размеру", PropertyName="SSize", Ascending=true},
                new ItemSort(){DisplayName="По дате ↑", PropertyName="SDate", Ascending=true},
                new ItemSort(){DisplayName="По дате ↓", PropertyName="SDate", Ascending=false},
                new ItemSort(){DisplayName="По массе ↑", PropertyName="SMass", Ascending=true},
                new ItemSort(){DisplayName="По массе ↓", PropertyName="SMass", Ascending=false}
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
            sharpingb = new ObservableCollection<Sharping>();
            connection.Sharping.ToList().ForEach(detail => sharpingb.Add(detail));
            allstring.Content = "Записей: " + sharpingb.Count.ToString();
            zerg.ItemsSource = sharpingb;
        }
        public static ObservableCollection<Sharping> sharpingb { get; set; }
        pg.NSharping pgs = new pg.NSharping();
        private void newdetail_Click(object sender, RoutedEventArgs e)
        {

            if (f4.Visibility == Visibility.Hidden || f4.NavigationService.Content == null)
            {
                f4.Visibility = Visibility.Visible;
                    pgs = new pg.NSharping();
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

        }
    }
}