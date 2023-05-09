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
    /// Логика взаимодействия для VExportNik.xaml
    /// </summary>
    public partial class VNik : Page
    {
        public VNik()
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
            public int CountKor { get; set; }
            public int CountDet { get; set; }
            public int CountPod { get; set; }
            public double MassNetMed { get; set; }
            public double MassNet { get; set; }
            public int CountInKor { get; set; }
            public double MedMass { get; set; }
            public double MassTara { get; set; }
            public double MassPod { get; set; }
            public double MassBrutto { get; set; }
        }
        public class ds
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public DateTime Date { get; set; }
            public int Count { get; set; }
            public double MassPod { get; set; }
            public double MassGofro { get; set; }
            public double MassBrutto { get; set; }
        }
        public double brutt;
        public double nett;
        public double goftara;
        public double mpod;
        public int kor;
        public int pod;
        public static ObservableCollection<view> views { get; set; }
        public static ObservableCollection<ds> dlss { get; set; }
        public void updateDetails()
        {
            typesb = new ObservableCollection<ExportNik>();
            conn.GetModel().ExportNik.ToList().ForEach(detail => typesb.Add(detail));
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
                            if (item.DName == it2.ENName && item.DSize == it2.ENSize)
                            {
                                dlss.Add(new ds() { Name = item.DName, Size = item.DSize, Date = it2.ENDate, Count = it2.ENCount, MassPod = it2.ENPMass, MassGofro = it2.ENKMass, MassBrutto = it2.ENKMassBrutto });
                            }
                            break;
                        case 1:
                            {
                                if (Year.Visibility == Visibility.Visible)
                                {
                                    if (item.DName == it2.ENName && item.DSize == it2.ENSize)
                                    {
                                        if (Month.SelectedIndex != 0)
                                        {
                                            var amd = Years.Where(q => q.Number == Year.SelectedIndex).FirstOrDefault();
                                            if (it2.ENDate.Year == amd.DisplayName && it2.ENDate.Month == Month.SelectedIndex)
                                            {
                                                dlss.Add(new ds() { Name = item.DName, Size = item.DSize, Date = it2.ENDate, Count = it2.ENCount, MassPod = it2.ENPMass, MassGofro = it2.ENKMass, MassBrutto = it2.ENKMassBrutto });
                                            }
                                        }
                                        else
                                        {
                                            var amd = Years.Where(q => q.Number == Year.SelectedIndex).FirstOrDefault();
                                            if (it2.ENDate.Year == amd.DisplayName)
                                            {
                                                dlss.Add(new ds() { Name = item.DName, Size = item.DSize, Date = it2.ENDate, Count = it2.ENCount, MassPod = it2.ENPMass, MassGofro = it2.ENKMass, MassBrutto = it2.ENKMassBrutto });
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case 2:
                            if (Date1.Visibility == Visibility.Visible)
                            {
                                if (item.DName == it2.ENName && item.DSize == it2.ENSize)
                                {
                                    if (it2.ENDate > Date1.SelectedDate && it2.ENDate < Date2.SelectedDate)
                                    {
                                        dlss.Add(new ds() { Name = item.DName, Size = item.DSize, Date = it2.ENDate, Count = it2.ENCount, MassPod = it2.ENPMass, MassGofro = it2.ENKMass, MassBrutto = it2.ENKMassBrutto });
                                    }

                                }
                            }
                            break;
                    }

                }
                foreach (var it3 in dlss)
                {
                    kor = kor + it3.Count;
                    pod++;
                    mpod = mpod + it3.MassPod;
                    goftara = goftara + it3.MassGofro;
                    nett = nett + (it3.MassBrutto - it3.MassPod - it3.MassGofro);
                    brutt = brutt + it3.MassBrutto;
                }
                views.Add(new view() { Name = item.DName, Size = item.DSize, CountKor = kor, CountDet = kor * item.DCount, CountPod = pod, MassNetMed = Math.Round((kor * (item.DCount * item.DMass)) / 1000, 2), MassNet = Math.Round(nett, 2), CountInKor = item.DCount, MedMass = Math.Round(item.DMass, 3), MassTara = goftara, MassPod = Math.Round(mpod, 2), MassBrutto = Math.Round(brutt, 2) });
                dlss.Clear();
                brutt = 0;
                nett = 0;
                goftara = 0;
                mpod = 0;
                kor = 0;
                pod = 0;
            }
            zerg.ItemsSource = views;
        }
        public static ObservableCollection<ExportNik> typesb { get; set; }
        public static ObservableCollection<Detail> detai { get; set; }


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
        private void Date1_Changed(object sender, SelectionChangedEventArgs e)
        {
            updateDetails();
        }
        private void Date2_Changed(object sender, SelectionChangedEventArgs e)
        {
            updateDetails();
        }
    }
}
