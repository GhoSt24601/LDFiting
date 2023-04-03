using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для DF.xaml
    /// </summary>
    public partial class DF : Page
    {
        public DF()
        {
            InitializeComponent();
        }
        public Database.DetailSize detail { get; set; }
        public string NameDet1;
        public string NameDet2;
        public string NameDet3;
        private void Badd_Click(object sender, RoutedEventArgs e)
        {
            NameDet1 = DN.Text.Trim();
            NameDet2 = DP.Text.Trim();
            NameDet3 = DPA.Text.Trim();
            if (NameDet1.Length != 0 && NameDet2.Length != 0 && NameDet3.Length != 0)
            {
                var SK = conn.GetModel().DetailSize.Where(x => x.DSName == NameDet1 || x.DSDName == NameDet2 || x.DSNName == NameDet3).FirstOrDefault();
                if (SK == null)
                {
                    detail = new Database.DetailSize();
                    detail.DSName = NameDet1;
                    detail.DSDName = NameDet2;
                    detail.DSNName = NameDet3;

                    conn.GetModel().DetailSize.Add(detail);
                    conn.GetModel().SaveChanges();
                    LMessage.Content = "Данные сохранены"; LMessage.Foreground = new SolidColorBrush(Colors.Black);
                    DN.Text = ""; DP.Text = ""; DPA.Text = ""; detail = null;
                }
                else { LMessage.Content = "Строка с такими данными уже существует"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
            }
            else { LMessage.Content = "Введите данные"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
        }
    }
}
