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
using System.Data.Entity.Migrations;

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для NDT.xaml
    /// </summary>
    public partial class NDT : Page
    {
        public NDT(DetailType detail)
        {
            InitializeComponent();
            DataContext = detail;
            if(detail != null ) { Badd.Content = "Изменить"; Name1.IsEnabled = false; }
        }
        public Database.DetailType detail { get; set; }
        public string NameDet1;
        public string NameDet2;
        public string NameDet3;
        private void Edit() 
        {
            NameDet2 = Name2.Text.Trim();
            NameDet3 = Name3.Text.Trim();
            if (NameDet2.Length != 0 && NameDet3.Length != 0)
            {
                var SK = conn.GetModel().DetailType.Where(x => x.DTName == Name1.Text).FirstOrDefault();
                if (SK != null)
                {
                    SK.DTDName = NameDet2;
                    SK.DTNName = NameDet3;

                    conn.GetModel().DetailType.AddOrUpdate(SK);
                    conn.GetModel().SaveChanges();
                    LMessage.Content = "Изменено"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                }
                else { LMessage.Content = "Невозможно изменить"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
                var SK1 = conn.GetModel().Detail.Where(x => x.DName == SK.DTName).FirstOrDefault();
                if (SK1 != null)
                {
                    SK1.DDName = NameDet2;
                    SK1.DDDName = NameDet3;

                    conn.GetModel().Detail.AddOrUpdate(SK1);
                    conn.GetModel().SaveChanges();
                    LMessage.Content = "Изменено"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                }
                else { LMessage.Content = "Невозможно изменить"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
            }
            else { LMessage.Content = "Введите данные"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
        }
        private void New()
        {
            NameDet1 = Name1.Text.Trim();
            NameDet2 = Name2.Text.Trim();
            NameDet3 = Name3.Text.Trim();
            if (NameDet1.Length != 0 && NameDet2.Length != 0 && NameDet3.Length != 0)
            {
                var SK = conn.GetModel().DetailType.Where(x => x.DTName == NameDet1).FirstOrDefault();
                if (SK == null)
                {
                    detail = new Database.DetailType();
                    detail.DTName = NameDet1;
                    detail.DTDName = NameDet2;
                    detail.DTNName = NameDet3;

                    conn.GetModel().DetailType.Add(detail);
                    conn.GetModel().SaveChanges();
                    LMessage.Content = "Данные сохранены"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                    Name1.Text = ""; Name2.Text = ""; Name3.Text = ""; detail = null;
                }
                else { LMessage.Content = "Строка с такими данными уже существует"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
            }
            else { LMessage.Content = "Введите данные"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
        }
        private void Badd_Click(object sender, RoutedEventArgs e)
        {
            if (Badd.Content!="Изменить")
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
