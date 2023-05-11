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
    public partial class NSharping : Page
    {
        public static ObservableCollection<Database.DetailType> detailtypes { get; set; }
        public static ObservableCollection<Database.Detail> detailsizes { get; set; }
        public NSharping(Sharping detail)
        {
            InitializeComponent();
            detailtypes = new ObservableCollection<DetailType>();
            conn.GetModel().DetailType.ToList().ForEach(detailtype => detailtypes.Add(detailtype));
            CBDN.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = detailtypes });
            DataContext = detail;
            
            if (detail != null) { Badd.Content = "Изменить"; bgh = detail.SId; CBDN.IsEnabled = false; CBDS.Items.Add(detail); CBDS.DisplayMemberPath = "SSize"; CBDS.IsEnabled = false; }
        }
        public int bgh;
        public Database.Sharping detail { get; set; }
        public string NameDet;
        public string SizeDet;
        public DateTime DateDet;
        public float MassDet;
        public string MassDet1; 
        private void Edit()
        {
            if (Date.SelectedDate == null) { Date.SelectedDate = DateTime.Now; }
            DateDet = Date.SelectedDate.Value;
            MassDet1 = TMass.Text.Trim();
            if (MassDet1.Length != 0)
            {
                var SK = conn.GetModel().Sharping.Where(x => x.SId==bgh).FirstOrDefault();
                if (SK != null)
                {
                    try
                    {
                        MassDet = float.Parse(MassDet1);
                    }
                    catch { LMessage.Content = "Неверный формат ввода"; LMessage.Foreground = new SolidColorBrush(Colors.Red); return; }
                    SK.SMass = MassDet;
                    SK.SDate = DateDet;

                    conn.GetModel().Sharping.AddOrUpdate(SK);
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
            MassDet1 = TMass.Text.Trim();

            if (CBDN.SelectedIndex > -1 && CBDS.SelectedIndex > -1 && MassDet1.Length != 0)
            {

                NameDet = CBDN.Text.ToString();
                SizeDet = CBDS.Text.ToString();
                try
                {
                    MassDet = float.Parse(MassDet1);
                }
                catch { LMessage.Content = "Неверный формат ввода"; LMessage.Foreground = new SolidColorBrush(Colors.Red); return; }
                detail = new Database.Sharping();
                detail.SName = NameDet;
                detail.SSize = SizeDet;
                detail.SDate = DateDet;
                detail.SMass = MassDet;
                conn.GetModel().Sharping.Add(detail);
                conn.GetModel().SaveChanges();
                LMessage.Content = "Данные сохранены"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                CBDN.SelectedIndex = -1; CBDS.SelectedIndex = -1; TMass.Text = ""; detail = null;
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
    }
}