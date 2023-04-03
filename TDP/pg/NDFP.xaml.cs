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
using System.Xml.Linq;

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для NDFP.xaml
    /// </summary>
    public partial class NDFP : Page
    {
        public NDFP()
        {
            InitializeComponent();
            DataContext = this;
        }

        public Database.DefectPlace detail { get; set; }
        public string NameDet1;
        private void Badd_Click(object sender, RoutedEventArgs e)
        {
            NameDet1 = Name1.Text.Trim();
            if (NameDet1.Length != 0)
            {
                var SK = conn.GetModel().DefectPlace.Where(x => x.DFPName == NameDet1).FirstOrDefault();
                if (SK == null)
                {
                    detail = new Database.DefectPlace();
                    detail.DFPName = NameDet1;

                    conn.GetModel().DefectPlace.Add(detail);
                    conn.GetModel().SaveChanges();
                    LMessage.Content = "Данные сохранены"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                    Name1.Text = ""; detail = null;
                }
                else { LMessage.Content = "Строка с такими данными уже существует"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
            }
            else { LMessage.Content = "Введите данные"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
        }
    }
}
