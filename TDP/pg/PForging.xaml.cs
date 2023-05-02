using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TDP.Database;

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для Forging.xaml
    /// </summary>
    public partial class PForging : Page
    {
        public PForging()
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
                new ItemSort(){DisplayName="По типу", PropertyName="FName", Ascending=true},
                new ItemSort(){DisplayName="По размеру", PropertyName="FSize", Ascending=true},
                new ItemSort(){DisplayName="По дате ↑", PropertyName="FDate", Ascending=true},
                new ItemSort(){DisplayName="По дате ↓", PropertyName="FDate", Ascending=false},
                new ItemSort(){DisplayName="По массе ↑", PropertyName="FMass", Ascending=true},
                new ItemSort(){DisplayName="По массе ↓", PropertyName="FMass", Ascending=false}
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
            forgingb = new ObservableCollection<Forging>();
            conn.GetModel().Forging.ToList().ForEach(detail => forgingb.Add(detail));
            allstring.Content = "Записей: " + forgingb.Count.ToString();
            zerg.ItemsSource = forgingb;
        }
        public static ObservableCollection<Forging> forgingb { get; set; }
        pg.NForging pgf = new pg.NForging();
        private void newdetail_Click(object sender, RoutedEventArgs e)
        {

            if (f4.Visibility == Visibility.Hidden || f4.NavigationService.Content == null)
            {
                f4.Visibility = Visibility.Visible;
                    pgf = new pg.NForging();
                    f4.Navigate(pgf);
            }
            else
            {
                f4.Visibility = Visibility.Hidden;
                pgf = null;
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
                        pgf = null;
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