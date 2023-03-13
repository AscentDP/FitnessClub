using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
    public partial class ServiceManagement : Window
    {
        public ServiceManagement()
        {
            InitializeComponent();
            cmbTypeSearch.SelectedIndex = 0;
            cmbTypeSort.SelectedIndex = 0;
            GetServiceList();
        }

        private void GetServiceList()
        {
            List<Service> serviceList = new List<Service>();

            serviceList = ClassHelper.EFClass.context.Service.ToList();

            switch (cmbTypeSearch.SelectedIndex)
            {
                case 0:
                    {
                        serviceList = serviceList.Where(i => i.NameService.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
                        break;
                    }
                case 1:
                    {
                        serviceList = serviceList.Where(i => i.Description.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
                        break;
                    }
                case 2:
                    {
                        serviceList = serviceList.Where(i => i.Cost.ToString().Contains(TbSearch.Text.ToLower())).ToList();
                        break;
                    }
                default:
                    {
                        serviceList = serviceList.Where(i => i.NameService.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
                        break;
                    }
            }

            switch(cmbTypeSort.SelectedIndex)
            {
                case 0:
                {
                    serviceList = serviceList.OrderBy(i => i.ID).ToList();
                    break;
                }
                case 1:
                {
                    serviceList = serviceList.OrderBy(i => i.NameService).ToList();
                    break;
                }
                case 2:
                {
                    serviceList = serviceList.OrderByDescending(i => i.NameService).ToList();
                    break;
                }
                case 3:
                {
                    serviceList = serviceList.OrderBy(i => i.Cost).ToList();
                    break;
                }
                case 4:
                {
                    serviceList = serviceList.OrderByDescending(i => i.Cost).ToList();
                    break;
                }
            }

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

        private void BtnDeleteroduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var service = button.DataContext as Service;

            MessageBoxResult result = MessageBox.Show($"Вы действительно хотите удалить услугу '{service.NameService}' ?", "Удаление услуги",
            MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                ClassHelper.EFClass.context.Service.Remove(service);
                ClassHelper.EFClass.context.SaveChanges();

            }

            var serviceList = ClassHelper.EFClass.context.Service.ToList();
            lvService.ItemsSource = serviceList;

        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetServiceList();
        }

        private void cmbTypeSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetServiceList();
        }

        private void cmbTypeSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetServiceList();
        }
    }
}