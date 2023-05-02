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
    public partial class pdefect : Page
    {
        public pdefect()
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
                new ItemSort(){DisplayName="По типу", PropertyName="DFName", Ascending=true},
                new ItemSort(){DisplayName="По размеру", PropertyName="DFSize", Ascending=true},
                new ItemSort(){DisplayName="По дате ↑", PropertyName="DFDate", Ascending=true},
                new ItemSort(){DisplayName="По дате ↓", PropertyName="DFDate", Ascending=false},
                new ItemSort(){DisplayName="По дефекту ↑", PropertyName="DFTName", Ascending=true},
                new ItemSort(){DisplayName="По дефекту ↓", PropertyName="DFTName", Ascending=false},
                new ItemSort(){DisplayName="По количеству ↑", PropertyName="DFCount", Ascending=true},
                new ItemSort(){DisplayName="По количеству ↓", PropertyName="DFCount", Ascending=false}
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
            defectb = new ObservableCollection<Defect>();
            conn.GetModel().Defect.ToList().ForEach(detail => defectb.Add(detail));
            allstring.Content = "Записей: " + defectb.Count.ToString();
            zerg.ItemsSource = defectb;
        }
        public static ObservableCollection<Defect> defectb { get; set; }
        pg.NDefect pgs = new pg.NDefect();
        private void newdetail_Click(object sender, RoutedEventArgs e)
        {

            if (f4.Visibility == Visibility.Hidden || f4.NavigationService.Content == null)
            {
                f4.Visibility = Visibility.Visible;
                    pgs = new pg.NDefect();
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
            var s = conn.GetModel().ExportLat.Where(q => q.ELId == k.ELId).FirstOrDefault();
            if (s != null)
            {

            }
        }
    }
}