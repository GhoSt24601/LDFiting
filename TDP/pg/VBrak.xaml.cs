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
    /// Логика взаимодействия для VDefect.xaml
    /// </summary>
    public partial class VBrak : Page
    {
        public VBrak()
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
            public int raspil { get; set; }
            public int naladka { get; set; }
            public int nedoof { get; set; }
            public int sht { get; set; }
            public int rassl { get; set; }
            public int nagrev { get; set; }
            public int neobrab { get; set; }
            public int acnaladka { get; set; }
            public int drobl { get; set; }
            public int sledinstr { get; set; }
            public int zausenec { get; set; }
            public int mo { get; set; }
            public int nedopokrit { get; set; }
            public int neodnor { get; set; }
            public int otsloenie { get; set; }
            public int meh { get; set; }
            public int rzhav { get; set; }
            public int itogosht { get; set; }
            public double itogoper { get; set; }
        }
        public class ds
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public DateTime Date { get; set; }
            public int Count { get; set; }
            public string Type { get; set; }
            public string Category { get; set; }
        }
        public int raspil;
        public int naladka;
        public int nedoof;
        public int sht;
        public int rassl;
        public int nagrev;
        public int neobrab;
        public int acnaladka;
        public int drobl;
        public int sledinstr;
        public int zausenec;
        public int mo;
        public int nedopokrit;
        public int neodnor;
        public int otsloenie;
        public int meh;
        public int rzhav;
        public static ObservableCollection<view> views { get; set; }
        public static ObservableCollection<ds> dlss { get; set; }
        public void updateDetails()
        {
            typesb = new ObservableCollection<Defect>();
            conn.GetModel().Defect.ToList().ForEach(detail => typesb.Add(detail));
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
                            if (item.DName == it2.DFName && item.DSize == it2.DFSize)
                            {
                                dlss.Add(new ds() { Name = item.DName, Size = item.DSize, Date = it2.DFDate, Count = it2.DFCount, Type = it2.DFTName, Category = it2.DFPlace });
                            }
                            break;
                        case 1:
                            {
                                if (Year.Visibility == Visibility.Visible)
                                {
                                    if (item.DName == it2.DFName && item.DSize == it2.DFSize)
                                    {
                                        if (Month.SelectedIndex != 0)
                                        {
                                            var amd = Years.Where(q => q.Number == Year.SelectedIndex).FirstOrDefault();
                                            if (it2.DFDate.Year == amd.DisplayName && it2.DFDate.Month == Month.SelectedIndex)
                                            {
                                                dlss.Add(new ds() { Name = item.DName, Size = item.DSize, Date = it2.DFDate, Count = it2.DFCount, Type = it2.DFTName, Category = it2.DFPlace });
                                            }
                                        }
                                        else
                                        {
                                            var amd = Years.Where(q => q.Number == Year.SelectedIndex).FirstOrDefault();
                                            if (it2.DFDate.Year == amd.DisplayName)
                                            {
                                                dlss.Add(new ds() { Name = item.DName, Size = item.DSize, Date = it2.DFDate, Count = it2.DFCount, Type = it2.DFTName, Category = it2.DFPlace });
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case 2:
                            if (Date1.Visibility == Visibility.Visible)
                            {
                                if (item.DName == it2.DFName && item.DSize == it2.DFSize)
                                {
                                    if (it2.DFDate > Date1.SelectedDate && it2.DFDate < Date2.SelectedDate)
                                    {
                                        dlss.Add(new ds() { Name = item.DName, Size = item.DSize, Date = it2.DFDate, Count = it2.DFCount, Type = it2.DFTName, Category = it2.DFPlace });
                                    }

                                }
                            }
                            break;
                    }

                }
                foreach (var it3 in dlss)
                {
                    switch (it3.Type)
                    {
                        case "р-р распил": raspil = raspil + it3.Count; break;
                        case "наладка":
                            if (it3.Category == "ГШО")
                            {
                                naladka = naladka + it3.Count;
                            }
                            else
                            {
                                acnaladka = acnaladka + it3.Count;
                            }
                            break;
                        case "недооф": nedoof = nedoof + it3.Count; break;
                        case "р-р ШТ": sht = sht + it3.Count; break;
                        case "рассл": rassl = rassl + it3.Count; break;
                        case "повт нагрев": nagrev = nagrev + it3.Count; break;
                        case "необраб уч": neobrab = neobrab + it3.Count; break;
                        case "дробл": drobl = drobl + it3.Count; break;
                        case "след инстр": sledinstr = sledinstr + it3.Count; break;
                        case "заусенец": zausenec = zausenec + it3.Count; break;
                        case "р-р МО": mo = mo + it3.Count; break;
                        case "недопокрыт": nedopokrit = nedopokrit + it3.Count; break;
                        case "неоднор. цвет": neodnor = neodnor + it3.Count; break;
                        case "отслоение": otsloenie = otsloenie + it3.Count; break;
                        case "мех повр": meh = meh + it3.Count; break;
                        case "ржавчина": rzhav = rzhav + it3.Count; break;

                    }
                }
                views.Add(new view()
                {
                    Name = item.DName,
                    Size = item.DSize,
                    raspil = raspil,
                    naladka = naladka,
                    nedoof = nedoof,
                    sht = sht,
                    rassl = rassl,
                    nagrev = nagrev,
                    neobrab = neobrab,
                    acnaladka = acnaladka,
                    drobl = drobl,
                    sledinstr = sledinstr,
                    zausenec = zausenec,
                    mo = mo,
                    nedopokrit = nedopokrit,
                    neodnor = neodnor,
                    otsloenie = otsloenie,
                    meh = meh,
                    rzhav = rzhav,
                    itogosht = raspil +
                naladka +
                nedoof +
                sht +
                rassl +
                nagrev +
                neobrab +
                acnaladka +
                drobl +
                sledinstr +
                zausenec +
                mo +
                nedopokrit +
                neodnor +
                otsloenie +
                meh +
                rzhav,

                });
                dlss.Clear();
                raspil = 0;
                naladka = 0;
                nedoof = 0;
                sht = 0;
                rassl = 0;
                nagrev = 0;
                neobrab = 0;
                acnaladka = 0;
                drobl = 0;
                sledinstr = 0;
                zausenec = 0;
                mo = 0;
                nedopokrit = 0;
                neodnor = 0;
                otsloenie = 0;
                meh = 0;
                rzhav = 0;
            }
            zerg.ItemsSource = views;
        }
        public static ObservableCollection<Defect> typesb { get; set; }
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
