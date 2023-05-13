using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TDP.Database;
using static TDP.pg.explat;
using Page = System.Windows.Controls.Page;
using Point = System.Windows.Point;
using Word = Microsoft.Office.Interop.Word;

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
            YearsAdd();
            All.SelectedIndex = 0;
            Month.SelectedIndex = 0;
            cbsort.SelectedIndex = 0;
            updateDetails();

            DataContext = this;
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
        public class en
        {
            public int ENId { get; set; }
            public DateTime ENDate { get; set; }
            public string ENName { get; set; }
            public string ENSize { get; set; }
            public int ENCount { get; set; }
            public double ENPMass { get; set; }
            public double ENKMass { get; set; }
            public double ENKMassBrutto { get; set; }
        }
        public static ObservableCollection<en> ens { get; set; }
        public void updateDetails()
        {
            exportnikb = new ObservableCollection<ExportNik>();
            exportnikb1 = new ObservableCollection<ExportNik>();
            ens = new ObservableCollection<en>();
            conn.GetModel().ExportNik.ToList().ForEach(detail => exportnikb.Add(detail));
            foreach (var item in exportnikb)
            {
                switch (All.SelectedIndex)
                {
                    case 0:
                        //exportnikb1.Add(item);
                        ens.Add(new en() { ENId = item.ENId, ENName = item.ENName, ENSize = item.ENSize, ENCount = item.ENCount, ENDate = item.ENDate, ENKMass = Math.Round(item.ENKMass, 1), ENPMass = Math.Round(item.ENPMass, 1), ENKMassBrutto = Math.Round(item.ENKMassBrutto, 1) });
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
                                        //exportnikb1.Add(item);
                                        ens.Add(new en() { ENId = item.ENId, ENName = item.ENName, ENSize = item.ENSize, ENCount = item.ENCount, ENDate = item.ENDate, ENKMass = Math.Round(item.ENKMass, 1), ENPMass = Math.Round(item.ENPMass, 1), ENKMassBrutto = Math.Round(item.ENKMassBrutto, 1) });
                                    }
                                }
                                else
                                {
                                    var amd = Years.Where(q => q.Number == Year.SelectedIndex).FirstOrDefault();
                                    if (item.ENDate.Year == amd.DisplayName)
                                    {
                                        //exportnikb1.Add(item);
                                        ens.Add(new en() { ENId = item.ENId, ENName = item.ENName, ENSize = item.ENSize, ENCount = item.ENCount, ENDate = item.ENDate, ENKMass = Math.Round(item.ENKMass, 1), ENPMass = Math.Round(item.ENPMass, 1), ENKMassBrutto = Math.Round(item.ENKMassBrutto, 1) });
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
                                //exportnikb1.Add(item); 
                                ens.Add(new en() { ENId = item.ENId, ENName = item.ENName, ENSize = item.ENSize, ENCount = item.ENCount, ENDate = item.ENDate, ENKMass = Math.Round(item.ENKMass, 1), ENPMass = Math.Round(item.ENPMass, 1), ENKMassBrutto = Math.Round(item.ENKMassBrutto, 1) });
                            }


                        }
                        break;
                }
            }
            allstring.Content = "Записей: " + ens.Count.ToString();

            zerg.ItemsSource = ens;
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
        public EditDelWord eod;
        public error err;
        private void sel(object sender, MouseButtonEventArgs e)
        {
            var selected = zerg.SelectedItem as en;
            if (selected != null)
            {
                ExportNik selectedDetail = new ExportNik();
                selectedDetail.ENDate = selected.ENDate;
                selectedDetail.ENId = selected.ENId;
                selectedDetail.ENName = selected.ENName;
                selectedDetail.ENKMass = selected.ENKMass;
                selectedDetail.ENKMassBrutto = selected.ENKMassBrutto;
                selectedDetail.ENPMass = selected.ENPMass;
                selectedDetail.ENSize = selected.ENSize;
                selectedDetail.ENCount = selected.ENCount;
                eod = new EditDelWord();

                var amd = conn.GetModel().Detail.Where(q => q.DName == selectedDetail.ENName).FirstOrDefault();
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
                            var SK = conn.GetModel().ExportNik.Where(q => q.ENId == selectedDetail.ENId).FirstOrDefault();
                            if (SK != null)
                            {
                                conn.GetModel().ExportNik.Remove(SK);
                                conn.GetModel().SaveChanges();
                            }
                        }

                        catch { conn.DBConnection = null; err = new error(2); err.ShowDialog(); return; }
                        break;
                    case 3:
                        try
                        {
                            Word.Application app = new Word.Application();
                            Word.Document doc = app.Documents.Add();
                            Word.Paragraph paragraph = doc.Paragraphs.Add();
                            Word.Range range = paragraph.Range;
                            Word.Table main = doc.Tables.Add(range, 7, 2);
                            Word.Range kerrigan;
                            
                            kerrigan = main.Cell(1, 1).Range;
                            kerrigan.Text = "Наименование";
                            kerrigan = main.Cell(2, 1).Range;
                            kerrigan.Text = "ДУ";
                            kerrigan = main.Cell(3, 1).Range;
                            kerrigan.Text = "Количество коробок, шт";
                            kerrigan = main.Cell(4, 1).Range;
                            kerrigan.Text = "Вес поддона, кг";
                            kerrigan = main.Cell(5, 1).Range;
                            kerrigan.Text = "Вес гофротары, кг";
                            kerrigan = main.Cell(6, 1).Range;
                            kerrigan.Text = "Вес НЕТТО, кг";
                            kerrigan = main.Cell(7, 1).Range;
                            kerrigan.Text = "Вес БРУТТО, кг";
                            kerrigan = main.Cell(1, 2).Range;
                            kerrigan.Text = amd.DDDName;
                            kerrigan = main.Cell(2, 2).Range;
                            kerrigan.Text = amd.DDDSize;
                            kerrigan = main.Cell(3, 2).Range;
                            kerrigan.Text = selectedDetail.ENCount.ToString();
                            kerrigan = main.Cell(4, 2).Range;
                            kerrigan.Text = selectedDetail.ENPMass.ToString();
                            kerrigan = main.Cell(5, 2).Range;
                            kerrigan.Text = selectedDetail.ENKMass.ToString();
                            kerrigan = main.Cell(6, 2).Range;
                            kerrigan.Text = (selectedDetail.ENKMassBrutto - selectedDetail.ENPMass - selectedDetail.ENKMass).ToString();
                            kerrigan = main.Cell(7, 2).Range;
                            kerrigan.Text = selectedDetail.ENKMassBrutto.ToString();
                            main.Borders.InsideLineStyle = main.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                            main.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            main.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            main.Rows[2].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            main.Rows[3].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            main.Rows[4].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            main.Rows[5].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            main.Rows[6].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            main.Rows[7].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            main.Rows[1].Range.Font.Size = 16;
                            main.Rows[2].Range.Font.Size = 16;
                            main.Rows[3].Range.Font.Size = 16;
                            main.Rows[4].Range.Font.Size = 16;
                            main.Rows[5].Range.Font.Size = 16;
                            main.Rows[6].Range.Font.Size = 16;
                            main.Rows[7].Range.Font.Size = 16;
                            main.Columns[1].SetWidth(200, WdRulerStyle.wdAdjustSameWidth);
                            main.Columns[2].SetWidth(300, WdRulerStyle.wdAdjustSameWidth);
                            main.Rows.SetHeight(50, WdRowHeightRule.wdRowHeightAuto);
                            main.Cell(1, 2).Range.Italic = 1;
                            main.Cell(2, 2).Range.Italic = 1;
                            main.Cell(3, 2).Range.Italic = 1;
                            main.Cell(4, 2).Range.Italic = 1;
                            main.Cell(5, 2).Range.Italic = 1;
                            main.Cell(6, 2).Range.Italic = 1;
                            main.Cell(7, 2).Range.Italic = 1;
                            main.Cell(1, 2).Range.Bold = 1;
                            main.Cell(2, 2).Range.Bold = 1;
                            main.Cell(3, 2).Range.Bold = 1;
                            main.Cell(4, 2).Range.Bold = 1;
                            main.Cell(5, 2).Range.Bold = 1;
                            main.Cell(6, 2).Range.Bold = 1;
                            main.Cell(7, 2).Range.Bold = 1;
                            
                            app.Visible = true;
                            
                            dynamic dialog = app.Dialogs[WdWordDialog.wdDialogFileSummaryInfo];
                            dialog.Title = (amd.DDDName + DateTime.Now).ToString();
                            dialog.Execute();
                            doc.Save();
                        }
                        catch { return; }
                        break;
                }
                updateDetails();
            }
        }
    }
}