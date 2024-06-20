using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public class Report
        {
            public int id { get; set; }
            public string Content { get; set; }
        }

        public ObservableCollection<Report> reports;

        public ReportWindow()
        {
            InitializeComponent();
            reports = new ObservableCollection<Report>();
            DgData.ItemsSource = reports; 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtId.Text.Length > 0)
                {
                    var report = reports.FirstOrDefault(r => r.id == int.Parse(txtId.Text));
                    if (report != null)
                    {
                        reports.Remove(report);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_click3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (reports.IsNullOrEmpty())
                {
                    int ID = 1;
                }
                else
                {
                    int ID = reports.Max(r => r.id) + 1;
                }

                Report report = new Report
                {
                    id = reports.Count > 0 ? reports.Max(r => r.id) + 1 : 1,
                    Content = txtContent.Text
                };
                reports.Add(report);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgData.SelectedItem is Report report)
            {
                txtId.Text = report.id.ToString();
                txtContent.Text = report.Content;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtId.Text.Length > 0)
                {
                    var report = reports.FirstOrDefault(r => r.id == int.Parse(txtId.Text));
                    if (report != null)
                    {
                        report.Content = txtContent.Text;
                        DgData.Items.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
