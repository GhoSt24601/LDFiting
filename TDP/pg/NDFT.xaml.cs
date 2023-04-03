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
    /// Логика взаимодействия для NDFT.xaml
    /// </summary>
    public partial class NDFT : Page
    {
        public static ObservableCollection<Database.DefectPlace> defectTypePlaces { get; set; }
        public NDFT()
        {
            InitializeComponent();
            defectTypePlaces = new ObservableCollection<DefectPlace>();
            conn.GetModel().DefectPlace.ToList().ForEach(detailtype => defectTypePlaces.Add(detailtype));
            CBDA.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = defectTypePlaces });
            DataContext = this;

        }

        public Database.DefectType detail { get; set; }
        public string NameDet;
        public string DefectCode;
        public string DefectName;
        private void Badd_Click(object sender, RoutedEventArgs e)
        {
            DefectCode = defectCode.Text.Trim();
            DefectName = defectName.Text.Trim();

            if (CBDA.SelectedIndex > -1 && DefectCode.Length != 0 && DefectName.Length != 0)
            {

                NameDet = CBDA.Text.ToString();
                

                var SK = conn.GetModel().DefectType.Where(x => x.DFTName == DefectCode).FirstOrDefault();
                if (SK == null)
                {
                    detail = new Database.DefectType();
                    detail.DFTName = DefectCode;
                    detail.DFTPlace = DefectName;
                    detail.FDTPlaceAll = NameDet;
                    conn.GetModel().DefectType.Add(detail);
                    conn.GetModel().SaveChanges();
                    LMessage.Content = "Данные сохранены"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                    CBDA.SelectedIndex = -1; defectName.Text = ""; defectCode.Text = ""; detail = null;
                }
                else { LMessage.Content = "Строка с такими данными уже существует"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
            }
            else { LMessage.Content = "Введите данные"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
        }
    }
}
