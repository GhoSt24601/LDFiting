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

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для NDS.xaml
    /// </summary>
    public partial class NDS : Page
    {
        public NDS()
        {
            InitializeComponent();
        }

        public Database.DetailSize detail { get; set; }
        public string NameDet1;
        public string NameDet2;
        public string NameDet3;
        private void Badd_Click(object sender, RoutedEventArgs e)
        {
            NameDet1 = Name1.Text.Trim();
            NameDet2 = Name2.Text.Trim();
            NameDet3 = Name3.Text.Trim();
            if (NameDet1.Length != 0 && NameDet2.Length != 0 && NameDet3.Length != 0)
            {
                var SK = conn.GetModel().DetailSize.Where(x => x.DSName == NameDet1).FirstOrDefault();
                if (SK == null)
                {
                    detail = new Database.DetailSize();
                    detail.DSName = NameDet1;
                    detail.DSDName = NameDet2;
                    detail.DSNName = NameDet3;

                    conn.GetModel().DetailSize.Add(detail);
                    conn.GetModel().SaveChanges();
                    LMessage.Content = "Данные сохранены"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                    Name1.Text = ""; Name2.Text = ""; Name3.Text = ""; detail = null;
                }
                else { LMessage.Content = "Строка с такими данными уже существует"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
            }
            else { LMessage.Content = "Введите данные"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
        }
    }
}
