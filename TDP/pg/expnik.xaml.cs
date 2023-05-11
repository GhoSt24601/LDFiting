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
    public partial class expnik : Page
    {
        public expnik()
        {
            InitializeComponent();
            DataContext = this;

            updateDetails();
            YearsAdd();
            All.SelectedIndex = 0;
            Month.SelectedIndex = 0;
            cbsort.SelectedIndex = 0;
        }
        public class ItemSort
        {
            public string DisplayName { get; set; }
            public string PropertyName { get; set; }
            public bool Ascending { get; set; }
        }
        public static ObservableCollection<ItemSort> ItemSorts { get; set; } = new ObservableCollection<ItemSort>()
        {
                new ItemSort(){DisplayName="По типу", PropertyName="ENName", Ascending=true},
                new ItemSort(){DisplayName="По размеру", PropertyName="ENSize", Ascending=true},
                new ItemSort(){DisplayName="По дате ↑", PropertyName="ENDate", Ascending=true},
                new ItemSort(){DisplayName="По дате ↓", PropertyName="ENDate", Ascending=false},
                new ItemSort(){DisplayName="По массе брутто ↑", PropertyName="ENKMassBrutto", Ascending=true},
                new ItemSort(){DisplayName="По массе брутто ↓", PropertyName="ENKMassBrutto", Ascending=false}
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
        public class Filter
        {
            public string DisplayName { get; set; }
        }
        public class CYear
        {
            public int DisplayName { get; set; }
            public int Number { get; set; }
        }
        public class CMonth
        {
            public string DisplayName { get; set; }
            public int Number { get; set; }
        }
        public static ObservableCollection<Filter> Filters { get; set; } = new ObservableCollection<Filter>()
        {
                new Filter(){DisplayName="За все время"},
                new Filter(){DisplayName="За месяц"},
                new Filter(){DisplayName="Свой диапазон"}
        };
        public static ObservableCollection<CMonth> Months { get; set; } = new ObservableCollection<CMonth>()
        {
                new CMonth(){DisplayName="Все месяца", Number=0},
                new CMonth(){DisplayName="Январь", Number=1},
                new CMonth(){DisplayName="Февраль", Number=2},
                new CMonth(){DisplayName="Март", Number=3},
                new CMonth(){DisplayName="Апрель", Number=4},
                new CMonth(){DisplayName="Май", Number=5},
                new CMonth(){DisplayName="Июнь", Number=6},
                new CMonth(){DisplayName="Июль", Number=7},
                new CMonth(){DisplayName="Август", Number=8},
                new CMonth(){DisplayName="Сентябрь", Number=9},
                new CMonth(){DisplayName="Октябрь", Number=10},
                new CMonth(){DisplayName="Ноябрь", Number=11},
                new CMonth(){DisplayName="Декабрь", Number=12}
        };
        public static ObservableCollection<CYear> Years { get; set; }
        public int d = 0;
        public void YearsAdd()
        {
            Years = new ObservableCollection<CYear>();
            for (int i = 2019; i <= DateTime.Today.Year; i++)
            {
                Years.Add(new CYear() { DisplayName = i, Number = d });
                d++;
            }

            Year.SelectedIndex = d - 1;
            d = 0;
        }
        public void updateDetails()
        {
            exportnikb = new ObservableCollection<ExportNik>();
            exportnikb1 = new ObservableCollection<ExportNik>();
            conn.GetModel().ExportNik.ToList().ForEach(detail => exportnikb.Add(detail));
            foreach (var item in exportnikb)
            {
                switch (All.SelectedIndex)
                {
                    case 0:
                        exportnikb1.Add(item);
                        break;
                    case 1:
                        {
                            if (Year.Visibility == Visibility.Visible)
                            {
                                if (Month.SelectedIndex != 0)
                                {
                                    var amd = Years.Where(q => q.Number == Year.SelectedIndex).FirstOrDefault();
                                    if (item.ENDate.Year == amd.DisplayName && item.ENDate.Month == Month.SelectedIndex)
                                    {
                                        exportnikb1.Add(item);
                                    }
                                }
                                else
                                {
                                    var amd = Years.Where(q => q.Number == Year.SelectedIndex).FirstOrDefault();
                                    if (item.ENDate.Year == amd.DisplayName)
                                    {
                                        exportnikb1.Add(item);
                                    }
                                }
                            }
                        }
                        break;
                    case 2:
                        if (Date1.Visibility == Visibility.Visible)
                        {
                            if (item.ENDate > Date1.SelectedDate && item.ENDate < Date2.SelectedDate)
                            {
                                exportnikb1.Add(item);
                            }


                        }
                        break;
                }
            }
            allstring.Content = "Записей: " + exportnikb1.Count.ToString();

            zerg.ItemsSource = exportnikb1;
        }
        private void Filter_Changed(object sender, SelectionChangedEventArgs e)
        {
            switch (All.SelectedIndex)
            {
                case 0: Year.Visibility = Visibility.Hidden; Month.Visibility = Visibility.Hidden; Date1.Visibility = Visibility.Hidden; Date2.Visibility = Visibility.Hidden; s.Visibility = Visibility.Hidden; po.Visibility = Visibility.Hidden; break;
                case 1: Year.Visibility = Visibility.Visible; Month.Visibility = Visibility.Visible; Date1.Visibility = Visibility.Hidden; Date2.Visibility = Visibility.Hidden; s.Visibility = Visibility.Hidden; po.Visibility = Visibility.Hidden; break;
                case 2: Year.Visibility = Visibility.Hidden; Month.Visibility = Visibility.Hidden; Date1.Visibility = Visibility.Visible; Date2.Visibility = Visibility.Visible; s.Visibility = Visibility.Visible; po.Visibility = Visibility.Visible; break;

            }
            updateDetails();
        }
        private void Date1_Changed(object sender, SelectionChangedEventArgs e)
        {
            updateDetails();
        }
        private void Date2_Changed(object sender, SelectionChangedEventArgs e)
        {
            updateDetails();
        }
        private void Year_Changed(object sender, SelectionChangedEventArgs e)
        {
            updateDetails();
        }
        private void Month_Changed(object sender, SelectionChangedEventArgs e)
        {
            updateDetails();
        }
        public static ObservableCollection<ExportNik> exportnikb { get; set; }
        public static ObservableCollection<ExportNik> exportnikb1 { get; set; }
        private void newdetail_Click(object sender, RoutedEventArgs e)
        {
            if (f4.Visibility == Visibility.Hidden || f4.NavigationService.Content == null)
            {
                f4.Visibility = Visibility.Visible;
                f4.Navigate(new pg.nexpnik(null));
            }
            else
            {
                f4.Visibility = Visibility.Hidden;
                updateDetails();
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
                        updateDetails();
                    }
                }
            }
        }
        public editordel eod;
        private void sel(object sender, MouseButtonEventArgs e)
        {
            eod = new editordel();
            var selectedDetail = zerg.SelectedItem as ExportNik;

            eod.ShowDialog();
            switch (eod.stg)
            {
                case 1:
                    f4.Visibility = Visibility.Visible;
                    f4.Navigate(new pg.nexpnik(selectedDetail));
                    break;
                case 2:
                    try
                    {
                        conn.GetModel().ExportNik.Remove(selectedDetail);
                        conn.GetModel().SaveChanges();
                    }

                    catch { conn.DBConnection = null; return; }
                    break;

            }
            updateDetails();
        }
    }
}