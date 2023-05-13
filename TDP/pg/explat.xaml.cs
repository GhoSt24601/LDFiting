using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using Page = System.Windows.Controls.Page;
using Point = System.Windows.Point;
using Word = Microsoft.Office.Interop.Word;

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для PSharping.xaml
    /// </summary>
    public partial class explat : Page
    {
        public explat()
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
        public class Filter
        {
            public string DisplayName { get; set; }
        }
        public class CYear
        {
            public int DisplayName { get; set; }
            public int Number { get; set; }
        }
        public class el
        {
            public int ELId { get; set; }
            public DateTime ELDate { get; set; }
            public string ELName { get; set; }
            public string ELSize { get; set; }
            public int ELCount { get; set; }
            public double ELPMass { get; set; }
            public double ELKMass { get; set; }
            public double ELKMassBrutto { get; set; }
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
        public static ObservableCollection<el> els { get; set; }
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
            exportlatb = new ObservableCollection<ExportLat>();
            exportlatb1 = new ObservableCollection<ExportLat>();
            els = new ObservableCollection<el>();
            conn.GetModel().ExportLat.ToList().ForEach(detail => exportlatb.Add(detail));
            foreach (var item in exportlatb)
            {
                switch (All.SelectedIndex)
                {
                    case 0:
                        //exportlatb1.Add(item);
                        els.Add(new el() { ELId=item.ELId, ELName = item.ELName, ELSize = item.ELSize, ELCount = item.ELCount, ELDate = item.ELDate, ELKMass = Math.Round(item.ELKMass, 1), ELPMass = Math.Round(item.ELPMass, 1), ELKMassBrutto = Math.Round(item.ELKMassBrutto, 1) });
                        break;
                    case 1:
                        {
                            if (Year.Visibility == Visibility.Visible)
                            {
                                if (Month.SelectedIndex != 0)
                                {
                                    var amd = Years.Where(q => q.Number == Year.SelectedIndex).FirstOrDefault();
                                    if (item.ELDate.Year == amd.DisplayName && item.ELDate.Month == Month.SelectedIndex)
                                    {
                                        //exportlatb1.Add(item);
                                        els.Add(new el() { ELName= item.ELName, ELSize=item.ELSize, ELCount=item.ELCount, ELDate=item.ELDate, ELKMass= Math.Round(item.ELKMass,1), ELPMass = Math.Round(item.ELPMass, 1), ELKMassBrutto=Math.Round(item.ELKMassBrutto,1) });
                                    }
                                }
                                else
                                {
                                    var amd = Years.Where(q => q.Number == Year.SelectedIndex).FirstOrDefault();
                                    if (item.ELDate.Year == amd.DisplayName)
                                    {
                                        //exportlatb1.Add(item);
                                        els.Add(new el() { ELId = item.ELId, ELName = item.ELName, ELSize = item.ELSize, ELCount = item.ELCount, ELDate = item.ELDate, ELKMass = Math.Round(item.ELKMass, 1), ELPMass = Math.Round(item.ELPMass, 1), ELKMassBrutto = Math.Round(item.ELKMassBrutto, 1) });
                                    }
                                }
                            }
                        }
                        break;
                    case 2:
                        if (Date1.Visibility == Visibility.Visible)
                        {
                            if (item.ELDate > Date1.SelectedDate && item.ELDate < Date2.SelectedDate)
                            {
                                //exportlatb1.Add(item);
                                els.Add(new el() { ELId = item.ELId, ELName = item.ELName, ELSize = item.ELSize, ELCount = item.ELCount, ELDate = item.ELDate, ELKMass = Math.Round(item.ELKMass, 1), ELPMass = Math.Round(item.ELPMass, 1), ELKMassBrutto = Math.Round(item.ELKMassBrutto, 1) });
                            }


                        }
                        break;
                }
            }
            allstring.Content = "Записей: " + els.Count.ToString();

            zerg.ItemsSource = els;
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
        public static ObservableCollection<ExportLat> exportlatb { get; set; }
        public static ObservableCollection<ExportLat> exportlatb1 { get; set; }
        private void newdetail_Click(object sender, RoutedEventArgs e)
        {
            if (f4.Visibility == Visibility.Hidden || f4.NavigationService.Content == null)
            {
                f4.Visibility = Visibility.Visible;
                f4.Navigate(new pg.nexplat(null));
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

            var selected = zerg.SelectedItem as el;
            
            if (selected != null)
            {
                ExportLat selectedDetail = new ExportLat();
                selectedDetail.ELDate = selected.ELDate;
                selectedDetail.ELId = selected.ELId;
                selectedDetail.ELName = selected.ELName;
                selectedDetail.ELKMass = selected.ELKMass;
                selectedDetail.ELKMassBrutto = selected.ELKMassBrutto;
                selectedDetail.ELPMass = selected.ELPMass;
                selectedDetail.ELSize= selected.ELSize;
                selectedDetail.ELCount = selected.ELCount;
                
                eod = new EditDelWord();

                var amd = conn.GetModel().Detail.Where(q => q.DName == selectedDetail.ELName).FirstOrDefault();
                eod.ShowDialog();
                switch (eod.stg)
                {
                    case 1:
                        f4.Visibility = Visibility.Visible;
                        f4.Navigate(new pg.nexplat(selectedDetail));
                        break;
                    case 2:
                        try
                        {
                            var SK = conn.GetModel().ExportLat.Where(q => q.ELId == selectedDetail.ELId).FirstOrDefault();
                            if (SK != null)
                            {
                                conn.GetModel().ExportLat.Remove(SK);
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
                            kerrigan.Text = amd.DDName;
                            kerrigan = main.Cell(2, 2).Range;
                            kerrigan.Text = amd.DDSize;
                            kerrigan = main.Cell(3, 2).Range;
                            kerrigan.Text = selectedDetail.ELCount.ToString();
                            kerrigan = main.Cell(4, 2).Range;
                            kerrigan.Text = selectedDetail.ELPMass.ToString();
                            kerrigan = main.Cell(5, 2).Range;
                            kerrigan.Text = selectedDetail.ELKMass.ToString();
                            kerrigan = main.Cell(6, 2).Range;
                            kerrigan.Text = (selectedDetail.ELKMassBrutto - selectedDetail.ELPMass - selectedDetail.ELKMass).ToString();
                            kerrigan = main.Cell(7, 2).Range;
                            kerrigan.Text = selectedDetail.ELKMassBrutto.ToString();
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