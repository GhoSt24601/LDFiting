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
    /// Логика взаимодействия для VForging.xaml
    /// </summary>
    public partial class VForging : Page
    {
        public VForging()
        {
            InitializeComponent();
            DataContext = this;
            updateDetails();
            YearsAdd();
            All.SelectedIndex = 0;
            Month.SelectedIndex = 0;

        }
        public class view
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public double MaxMass { get; set; }
            public double MinMass { get; set; }
            public double Raznost { get; set; }
            public double MedMass { get; set; }
        }
        public class ds
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public DateTime Date { get; set; }
            public double Mass { get; set; }
        }
        public double MaxMass1;
        public double MinMass1 = 99999999;
        public double MedMass1;
        public int q;
        public static ObservableCollection<view> views { get; set; }
        public static ObservableCollection<ds> dlss { get; set; }
        public void updateDetails()
        {
            typesb = new ObservableCollection<Forging>();
            conn.GetModel().Forging.ToList().ForEach(detail => typesb.Add(detail));
            views = new ObservableCollection<view>();
            dlss = new ObservableCollection<ds>();
            detai = new ObservableCollection<Detail>();
            conn.GetModel().Detail.ToList().ForEach(det => detai.Add(det));

            foreach (var item in detai)
            {
                foreach (var it2 in typesb)
                {
                    switch (All.SelectedIndex)
                    {
                        case 0:
                            if (item.DName == it2.FName && item.DSize == it2.FSize)
                            {
                                dlss.Add(new ds() { Name = it2.FName, Size = it2.FSize, Date = it2.FDate, Mass = it2.FMass });
                            }
                            break;
                        case 1:
                            {
                                if (Year.Visibility == Visibility.Visible)
                                {
                                    if (item.DName == it2.FName && item.DSize == it2.FSize)
                                    {
                                        if (Month.SelectedIndex != 0)
                                        {
                                            var amd = Years.Where(q => q.Number == Year.SelectedIndex).FirstOrDefault();
                                            if (it2.FDate.Year == amd.DisplayName && it2.FDate.Month == Month.SelectedIndex)
                                            {
                                                dlss.Add(new ds() { Name = it2.FName, Size = it2.FSize, Date = it2.FDate, Mass = it2.FMass });
                                            }
                                        }
                                        else
                                        {
                                            var amd = Years.Where(q => q.Number == Year.SelectedIndex).FirstOrDefault();
                                            if (it2.FDate.Year == amd.DisplayName)
                                            {
                                                dlss.Add(new ds() { Name = it2.FName, Size = it2.FSize, Date = it2.FDate, Mass = it2.FMass });
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case 2:
                            if (Date1.Visibility == Visibility.Visible)
                            {
                                if (item.DName == it2.FName && item.DSize == it2.FSize)
                                {
                                    if (Date1.SelectedDate!=null && Date2.SelectedDate != null)
                                    {
                                        if (it2.FDate > Date1.SelectedDate && it2.FDate < Date2.SelectedDate)
                                        {
                                            dlss.Add(new ds() { Name = it2.FName, Size = it2.FSize, Date = it2.FDate, Mass = it2.FMass });
                                        }
                                    }
                                }
                            }
                            break;
                    }

                }
                foreach (var it3 in dlss)
                {
                    if (MaxMass1 < it3.Mass)
                    {
                        MaxMass1 = it3.Mass;
                    }
                    if (MinMass1 > it3.Mass)
                    {
                        MinMass1 = it3.Mass;
                    }
                    MedMass1 = MedMass1 + it3.Mass;
                    q++;
                }
                if (MinMass1 == 99999999) { MinMass1 = 0; }
                views.Add(new view() { Name = item.DName, Size = item.DSize, MaxMass = MaxMass1, MinMass = MinMass1, Raznost = MaxMass1 - MinMass1, MedMass = MedMass1 / q });
                dlss.Clear();
                q = 0;
                MaxMass1 = 0;
                MinMass1 = 99999999;
                MedMass1 = 0;
            }
            zerg.ItemsSource = views;
        }
        public static ObservableCollection<Forging> typesb { get; set; }
        public static ObservableCollection<Detail> detai { get; set; }
        private void newdetail_Click(object sender, RoutedEventArgs e)
        {
            if (f4.Visibility == Visibility.Hidden || f4.NavigationService.Content == null)
            {
                f4.Visibility = Visibility.Visible;
                f4.Navigate(new pg.NDT(null));
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

        private void sel(object sender, MouseButtonEventArgs e)
        {
            var selectedDetail = zerg.SelectedItem as DetailType;
            f4.Visibility = Visibility.Visible;
            f4.Navigate(new pg.NDT(selectedDetail));
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
        private void Year_Changed(object sender, SelectionChangedEventArgs e)
        {
            updateDetails();
        }
        private void Month_Changed(object sender, SelectionChangedEventArgs e)
        {
            updateDetails();
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
    }
}
