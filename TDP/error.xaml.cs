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
using System.Windows.Shapes;
using TDP.pg;

namespace TDP
{
    /// <summary>
    /// Логика взаимодействия для error.xaml
    /// </summary>
    public partial class error : Window
    {
        public error(int q)
        {
            InitializeComponent();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;


            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;
            switch (q)
            {
                case 0: break;
                case 1: tb.Text = "Подключение к серверу отсутствует. Перезапустите компьютер. Если проблема не ушла, звоните Димону."; break;
                case 2: tb.Text = "Эту строку невозможно удалить, так как ее данные используются в других таблицах. Удалите зависящие строки и повторите попытку."; break;
                case 3: break;
            }
        }

        private void Ok_Checked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MD(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton==MouseButton.Left)
            {
                DragMove();
            }
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
