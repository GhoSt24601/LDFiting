using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для NSharping.xaml
    /// </summary>
    public partial class NDefect : Page
    {
        public static ObservableCollection<Database.DetailType> detailtypes { get; set; }
        public static ObservableCollection<Database.Detail> detailsizes { get; set; }
        public static ObservableCollection<Database.DefectType> defectTypes { get; set; }
        public static ObservableCollection<DefectPlace> defectPlaces { get; set; }
        public NDefect(Defect detail)
        {
            InitializeComponent();
            detailtypes = new ObservableCollection<DetailType>();
            conn.GetModel().DetailType.ToList().ForEach(detailtype => detailtypes.Add(detailtype));
            CBDN.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = detailtypes });
            defectPlaces = new ObservableCollection<DefectPlace>();
            conn.GetModel().DefectPlace.ToList().ForEach(dp => defectPlaces.Add(dp));
            CBCat.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = defectPlaces });
            DataContext = detail;

            if (detail != null) { Badd.Content = "Изменить";
                bgh = detail.DFId;
                CBDN.IsEnabled = false;
                CBDS.Items.Add(detail);
                CBDS.DisplayMemberPath = "DFSize";
                CBDF.Items.Add(detail);
                CBDF.DisplayMemberPath = "DFTName";
                CBDS.IsEnabled = false;
                CBCat.IsEnabled = false;
                CBDF.IsEnabled = false; }
        }
        public int bgh;

        public Database.Defect detail { get; set; }
        public string NameDet;
        public string SizeDet;
        public string DefType;
        public string Cat;
        public DateTime DateDet;
        public int Count;
        public string Count1;
        private void Edit()
        {
            if (Date.SelectedDate == null) { Date.SelectedDate = DateTime.Now; }
            DateDet = Date.SelectedDate.Value;
            Count1 = PMass.Text.Trim();

            if (CBCat.SelectedIndex >-1 && CBDN.SelectedIndex > -1 && CBDS.SelectedIndex > -1 && CBDF.SelectedIndex > -1 && Count1.Length != 0)
            {

                NameDet = CBDN.Text.ToString();
                SizeDet = CBDS.Text.ToString();
                DefType = CBDF.Text.ToString(); 
                Cat = CBCat.Text.ToString();
                try
                {
                    Count = int.Parse(Count1);
                }
                catch { LMessage.Content = "Неверный формат ввода"; LMessage.Foreground = new SolidColorBrush(Colors.Red); return; }

                var SK = conn.GetModel().Defect.Where(x => x.DFId == bgh).FirstOrDefault();
                if (SK != null)
                {

                    SK.DFName = NameDet;
                    SK.DFSize = SizeDet;
                    SK.DFDate = DateDet;
                    SK.DFCount = Count;
                    SK.DFPlace = Cat;
                    SK.DFTName = DefType;
                    conn.GetModel().Defect.AddOrUpdate(SK);
                    conn.GetModel().SaveChanges();
                    LMessage.Content = "Изменено"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                }
                else { LMessage.Content = "Невозможно изменить"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
            }
            else { LMessage.Content = "Введите данные"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
        }
        private void New()
        {
            if (Date.SelectedDate == null) { Date.SelectedDate = DateTime.Now; }
            DateDet = Date.SelectedDate.Value;
            Count1 = PMass.Text.Trim();

            if (CBCat.SelectedIndex > -1 && CBDN.SelectedIndex > -1 && CBDS.SelectedIndex > -1 && CBDF.SelectedIndex > -1 && Count1.Length != 0)
            {

                NameDet = CBDN.Text.ToString();
                SizeDet = CBDS.Text.ToString();
                DefType = CBDF.Text.ToString();
                Cat = CBCat.Text.ToString();
                try
                {
                    Count = int.Parse(Count1);
                }
                catch { LMessage.Content = "Неверный формат ввода"; LMessage.Foreground = new SolidColorBrush(Colors.Red); return; }
                detail = new Database.Defect();
                detail.DFName = NameDet;
                detail.DFSize = SizeDet;
                detail.DFDate = DateDet;
                detail.DFCount = Count;
                detail.DFPlace = Cat;
                detail.DFTName = DefType;
                conn.GetModel().Defect.Add(detail);
                conn.GetModel().SaveChanges();
                LMessage.Content = "Данные сохранены"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                CBDN.SelectedIndex = -1; CBDS.SelectedIndex = -1; CBDF.SelectedIndex = -1; CBCat.SelectedIndex = -1; PMass.Text = ""; detail = null;
            }
            else { LMessage.Content = "Введите данные"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
        }

        private void CBDN_SelectionChanged(object sender, EventArgs e)
        {
            detailsizes = new ObservableCollection<Detail>();
            conn.GetModel().Detail.Where(q => q.DName == CBDN.Text).ToList().ForEach(detailsize => detailsizes.Add(detailsize));
            CBDS.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = detailsizes });

        }
        private void Badd_Click(object sender, RoutedEventArgs e)
        {
            if (Badd.Content != "Изменить")
            {
                New();
            }
            else
            {
                Edit();
            }
        }

        private void CBCat_SelectionChanged(object sender, EventArgs e)
        {
            defectTypes = new ObservableCollection<DefectType>();
            conn.GetModel().DefectType.Where(q => q.FDTPlaceAll == CBCat.Text).ToList().ForEach(defectType => defectTypes.Add(defectType));
            CBDF.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = defectTypes });
        }
    }
}