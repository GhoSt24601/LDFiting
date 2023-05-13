using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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

namespace TDP
{
    /// <summary>
    /// Логика взаимодействия для editordel.xaml
    /// </summary>
    public partial class EditDelWord : Window
    {
        public EditDelWord()
        {
            InitializeComponent();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;


            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;
        }


        public int stg = 0;

        private void RBEdit_Checked(object sender, RoutedEventArgs e)
        {
            this.Close();
            stg = 1;
        }

        private void RBDel_Checked(object sender, RoutedEventArgs e)
        {
            this.Close();
            stg = 2;
        }
        public int Stag()
        {
            return stg;
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MD(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void RBWord_Checked(object sender, RoutedEventArgs e)
        {
            this.Close();
            stg = 3;
        }
    }
}
