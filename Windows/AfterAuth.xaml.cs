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

using _3ISP919_Naliv_LoginReg.DB;
using _3ISP919_Naliv_LoginReg.Windows;

namespace _3ISP919_Naliv_LoginReg
{
    public partial class AfterAuth : Window
    {
        public AfterAuth()
        {
            InitializeComponent();
            GetServiceList();

        }

        private void GetServiceList()
        {
            List<Service> serviceList = new List<Service>();

            serviceList = ClassHelper.EFClass.context.Service.ToList();

            lvService.ItemsSource = serviceList;
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow();
            addEditServiceWindow.ShowDialog();

            GetServiceList();
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var service = button.DataContext as Service;


            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow(service);
            addEditServiceWindow.ShowDialog();

            GetServiceList();
        }
    }
}