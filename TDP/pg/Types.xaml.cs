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
using System.Runtime.CompilerServices;

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для Types.xaml
    /// </summary>
    public partial class Types : Page
    {
        Database.Entities connection = new Database.Entities();
       
        public Types()
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
                new ItemSort(){DisplayName="По названию", PropertyName="DTName", Ascending=true},
                new ItemSort(){DisplayName="По названию в отправке", PropertyName="DTDName", Ascending=true},
                new ItemSort(){DisplayName="По названию в отправке никеля", PropertyName="DTNName", Ascending=true}
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
        public DetailType updateDetails()
        {
            typesb = new ObservableCollection<DetailType>();
            connection.DetailType.ToList().ForEach(detail => typesb.Add(detail));
            allstring.Content = "Записей: " + typesb.Count.ToString();
            zerg.ItemsSource = typesb;
            return typesb.Last();
        }
        public static ObservableCollection<DetailType> typesb { get; set; }
        pg.NDT pgndt = new pg.NDT();
        private void newdetail_Click(object sender, RoutedEventArgs e)
        {
            if (f4.Visibility == Visibility.Hidden || f4.NavigationService.Content == null)
            {
                f4.Visibility = Visibility.Visible;
                    pgndt = new pg.NDT();
                    f4.Navigate(pgndt);
            }
            else
            {
                f4.Visibility = Visibility.Hidden;
                pgndt = null;
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
                        pgndt = null;
                        updateDetails();
                        GC.Collect();
                    }
                }
            }
        }

    }
}
