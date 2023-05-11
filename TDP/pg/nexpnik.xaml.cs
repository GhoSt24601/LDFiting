﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace TDP.pg
{
    /// <summary>
    /// Логика взаимодействия для NSharping.xaml
    /// </summary>
    public partial class nexpnik : Page
    {
        public static ObservableCollection<Database.DetailType> detailtypes { get; set; }
        public static ObservableCollection<Database.Detail> detailsizes { get; set; }
        public nexpnik(ExportNik detail)
        {
            InitializeComponent();
            detailtypes = new ObservableCollection<DetailType>();
            conn.GetModel().DetailType.ToList().ForEach(detailtype => detailtypes.Add(detailtype));
            CBDN.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = detailtypes });
            DataContext = detail;

            if (detail != null) { Badd.Content = "Изменить"; bgh = detail.ENId; CBDN.IsEnabled = false; CBDS.Items.Add(detail); CBDS.DisplayMemberPath = "ENSize"; CBDS.IsEnabled = false; }
        }
        public int bgh;

        public Database.ExportNik detail { get; set; }
        public string NameDet;
        public string SizeDet;
        public DateTime DateDet;
        public float MassDet;
        public string MassDet1;
        public int Count;
        public string Count1;
        public double detm;
        private void Edit()
        {
            if (Date.SelectedDate == null) { Date.SelectedDate = DateTime.Now; }
            DateDet = Date.SelectedDate.Value;
            MassDet1 = PMass.Text.Trim();
            Count1 = TCount.Text.Trim();

            if (MassDet1.Length != 0 && Count1.Length != 0)
            {
                NameDet = CBDN.Text.ToString();
                SizeDet = CBDS.Text.ToString();
                try
                {
                    MassDet = float.Parse(MassDet1);
                    Count = int.Parse(Count1);
                }
                catch { LMessage.Content = "Неверный формат ввода"; LMessage.Foreground = new SolidColorBrush(Colors.Red); return; }

                var SK = conn.GetModel().ExportNik.Where(x => x.ENId == bgh).FirstOrDefault();
                if (SK != null)
                {
                    var Kerrigan = conn.GetModel().Detail.Where(q => q.DName == NameDet && q.DSize == SizeDet).FirstOrDefault();
                    if (Kerrigan != null)
                    {
                        detm = ((double)Kerrigan.DMass * 0.001) * Kerrigan.DCount;

                    }
                    SK.ENDate = DateDet;
                    SK.ENPMass = MassDet;
                    SK.ENKMass = 0.078 * Count;
                    SK.ENKMassBrutto = 0.078 * Count + MassDet + detm * Count;
                    SK.ENCount = Count;

                    conn.GetModel().ExportNik.AddOrUpdate(SK);
                    conn.GetModel().SaveChanges();
                    LMessage.Content = "Изменено"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                }
                else { LMessage.Content = "Невозможно изменить"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
            }
            else { LMessage.Content = "Введите данные"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
        }
        private void New()
        {
            if (Date.SelectedDate == null) { Date.SelectedDate = DateTime.Now; }
            DateDet = Date.SelectedDate.Value;
            MassDet1 = PMass.Text.Trim();
            Count1 = TCount.Text.Trim();

            if (CBDN.SelectedIndex > -1 && CBDS.SelectedIndex > -1 && MassDet1.Length != 0 && Count1.Length != 0)
            {

                NameDet = CBDN.Text.ToString();
                SizeDet = CBDS.Text.ToString();
                try
                {
                    MassDet = float.Parse(MassDet1);
                    Count = int.Parse(Count1);
                }
                catch { LMessage.Content = "Неверный формат ввода"; LMessage.Foreground = new SolidColorBrush(Colors.Red); return; }
                var Kerrigan = conn.GetModel().Detail.Where(q => q.DName == NameDet && q.DSize == SizeDet).FirstOrDefault();
                if (Kerrigan != null)
                {
                    detm = ((double)Kerrigan.DMass * 0.001) * Kerrigan.DCount;

                }
                detail = new Database.ExportNik();
                detail.ENName = NameDet;
                detail.ENSize = SizeDet;
                detail.ENDate = DateDet;
                detail.ENPMass = MassDet;
                detail.ENKMass = 0.078 * Count;
                detail.ENKMassBrutto = 0.078 * Count + MassDet + detm * Count;
                detail.ENCount = Count;
                conn.GetModel().ExportNik.Add(detail);
                conn.GetModel().SaveChanges();
                LMessage.Content = "Данные сохранены"; LMessage.Foreground = new SolidColorBrush(Colors.White);
                CBDN.SelectedIndex = -1; CBDS.SelectedIndex = -1; TCount.Text = ""; PMass.Text = ""; detail = null; Kerrigan = null;
            }
            else { LMessage.Content = "Введите данные"; LMessage.Foreground = new SolidColorBrush(Colors.Red); }
        }

        private void CBDN_SelectionChanged(object sender, EventArgs e)
        {
            detailsizes = new ObservableCollection<Detail>();
            conn.GetModel().Detail.Where(q => q.DName == CBDN.Text).ToList().ForEach(detailsize => detailsizes.Add(detailsize));
            CBDS.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = detailsizes });

        }
        private void Badd_Click(object sender, RoutedEventArgs e)
        {
            if (Badd.Content != "Изменить")
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