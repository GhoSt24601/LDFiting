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
using TDP.Database;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Configuration;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для ND.xaml
    /// </summary>
    public partial class ND : Page
    {
        public static ObservableCollection<Database.DetailType> detailtypes { get; set; }
        public static ObservableCollection<Database.DetailSize> detailsizes { get; set; }
        public ND()
        {
            InitializeComponent();
            detailtypes = new ObservableCollection<DetailType>();
            detailsizes = new ObservableCollection<DetailSize>();
            conn.GetModel().DetailType.ToList().ForEach(detailtype => detailtypes.Add(detailtype));
            conn.GetModel().DetailSize.ToList().ForEach(detailsize => detailsizes.Add(detailsize));
            CBDN.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = detailtypes });
            CBDS.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = detailsizes });
            DataContext = this;
        }

        public Database.Detail detail { get; set; }
        public string NameDet;
        public string SizeDet;
        public int CountDet;
        public string CountDet1;
        public float MassDet;
        public string MassDet1;
        private void Badd_Click(object sender, RoutedEventArgs e)
        {
            CountDet1 = TCount.Text.Trim();
            MassDet1 = TMass.Text.Trim();

            if (CBDN.SelectedIndex > -1 && CBDS.SelectedIndex > -1 && CountDet1.Length != 0 && MassDet1.Length != 0)
            {

                NameDet = CBDN.Text.ToString();
                SizeDet = CBDS.Text.ToString();
                try
                {
                    CountDet = int.Parse(CountDet1);
                    MassDet = float.Parse(MassDet1);
                }
                catch { LMessage.Content = "Неверный формат ввода"; LMessage.Foreground = new SolidColorBrush(Colors.Red); return; }

                var SK = conn.GetModel().Detail.Where(x => x.DName == NameDet && x.DSize == SizeDet).FirstOrDefault();
                if (SK == null)
                {
                    detail = new Database.Detail();
                    detail.DName = NameDet;
                    detail.DSize = SizeDet;
                    detail.DCount = CountDet;
                    detail.DMass = MassDet;
                    var qwe = conn.GetModel().DetailType.Where(q => q.DTName == NameDet).FirstOrDefault();
                    if (qwe != null)
                    {
                        detail.DDName = qwe.DTDName;
                        detail.DDDName = qwe.DTNName;
                    }
                    var asd = conn.GetModel().DetailSize.Where(w => w.DSName == SizeDet).FirstOrDefault();
                    if (asd != null)
                    {
                        detail.DDSize = asd.DSDName;
                        detail.DDDSize = asd.DSNName;
                    }
                    conn.GetModel().Detail.Add(detail);
                    conn.GetModel().SaveChanges();
                    LMessage.Content = "Данные сохранены"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                    CBDN.SelectedIndex = -1; CBDS.SelectedIndex = -1; TMass.Text = ""; TCount.Text = ""; detail = null;
                }
                else { LMessage.Content = "Строка с такими данными уже существует"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
            }
            else { LMessage.Content = "Введите данные"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
        }
    }
}
