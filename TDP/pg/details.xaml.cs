﻿using System;
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
    /// Логика взаимодействия для details.xaml
    /// </summary>
    public partial class details : Page
    {
        public details()
        {
            InitializeComponent();

            cbsort.SelectedIndex = 0;
            updateDetails();
            DataContext = this;
        }
        public class ItemSort
        {
            public string DisplayName { get; set; }
            public string PropertyName { get; set; }
            public bool Ascending { get; set; }
        }
        public static ObservableCollection<ItemSort> ItemSorts { get; set; } = new ObservableCollection<ItemSort>()
        {
                new ItemSort(){DisplayName="По типу", PropertyName="DName", Ascending=true},
                new ItemSort(){DisplayName="По размеру", PropertyName="DSize", Ascending=true},
                new ItemSort(){DisplayName="По количеству ↑", PropertyName="DCount", Ascending=true},
                new ItemSort(){DisplayName="По количеству ↓", PropertyName="DCount", Ascending=false},
                new ItemSort(){DisplayName="По массе ↑", PropertyName="DMass", Ascending=true},
                new ItemSort(){DisplayName="По массе ↓", PropertyName="DMass", Ascending=false}
        };
        private void cbsorting(object sender, SelectionChangedEventArgs e)
        {
            var item = cbsort.SelectedItem as ItemSort;
            var view = CollectionViewSource.GetDefaultView(zerg.ItemsSource);
            var direction = item.Ascending ?
                ListSortDirection.Ascending :
                ListSortDirection.Descending;
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(item.PropertyName, direction));
        }
        public void updateDetails()
        {
            detailsb = new ObservableCollection<Detail>();
            conn.GetModel().Detail.ToList().ForEach(detail => detailsb.Add(detail));
            allstring.Content = "Записей: " + detailsb.Count.ToString();
            zerg.ItemsSource = detailsb;
        }
        public static ObservableCollection<Detail> detailsb { get; set; }
        private void newdetail_Click(object sender, RoutedEventArgs e)
        {
            if (f4.Visibility == Visibility.Hidden || f4.NavigationService.Content == null)
            {
                f4.Visibility = Visibility.Visible;
                f4.Navigate(new pg.ND(null));
            }
            else
            {
                f4.Visibility = Visibility.Hidden;
                updateDetails();
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
                        updateDetails();
                    }
                }
            }
        }
        public editordel eod;
        public error err;
        private void sel(object sender, MouseButtonEventArgs e)
        {
            eod = new editordel();
            var selectedDetail = zerg.SelectedItem as Detail;

            eod.ShowDialog();
            switch (eod.stg)
            {
                case 1:
                    f4.Visibility = Visibility.Visible;
                    f4.Navigate(new pg.ND(selectedDetail));
                    break;
                case 2:
                    try
                    {
                        conn.GetModel().Detail.Remove(selectedDetail);
                        conn.GetModel().SaveChanges();
                    }

                    catch { conn.DBConnection = null; err = new error(2); err.ShowDialog(); return; }
                    break;

            }
            updateDetails();
        }
    }
}
