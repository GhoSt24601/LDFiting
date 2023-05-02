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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.SqlTypes;
using TDP.Database;
using System.Security.AccessControl;

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для DefectPlaces.xaml
    /// </summary>
    public partial class DefectPlaces : Page
    {
        public DefectPlaces()
        {
            InitializeComponent();
            DataContext = this;

            updateDetails();

        }
       
        public void updateDetails()
        {
            defectplacesb = new ObservableCollection<DefectPlace>();
            conn.GetModel().DefectPlace.ToList().ForEach(detail => defectplacesb.Add(detail));
            allstring.Content = "Записей: " + defectplacesb.Count.ToString();
            zerg.ItemsSource= defectplacesb;
        }
        public static ObservableCollection<DefectPlace> defectplacesb { get; set; }
        pg.NDFP pgndfp = new pg.NDFP();
        private void newdetail_Click(object sender, RoutedEventArgs e)
        {
            if (f4.Visibility == Visibility.Hidden || f4.NavigationService.Content == null)
            {
                f4.Visibility = Visibility.Visible;
                pgndfp = new pg.NDFP();
                f4.Navigate(pgndfp);
            }
            else
            {
                f4.Visibility = Visibility.Hidden;
                pgndfp = null;
                updateDetails();
                GC.Collect();
            }

        }

        private void unvis(object sender, MouseButtonEventArgs e)
        {
            
            if (f4.Visibility == Visibility.Visible)
            {
                Point pt = e.GetPosition((UIElement)sender);
                HitTestResult result = VisualTreeHelper.HitTest(f4, pt);
                if (result != null)
                {
                    if (e.ChangedButton == MouseButton.Left)
                    {
                        f4.Visibility = Visibility.Hidden;
                        pgndfp = null;
                        updateDetails();
                        GC.Collect();
                    }
                }
            }
        }

    }
}