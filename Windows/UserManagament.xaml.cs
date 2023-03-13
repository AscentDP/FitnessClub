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
    public partial class UserManagament : Window
    {
        public UserManagament()
        {
            InitializeComponent();
            cmbTypeSearch.SelectedIndex = 0;
            cmbTypeSort.SelectedIndex = 0;
            GetServiceList();
        }

        private void GetServiceList()
        {
            List<Client> clientList = new List<Client>();

            clientList = ClassHelper.EFClass.context.Client.ToList();

            switch (cmbTypeSearch.SelectedIndex)
            {
                case 0:
                    {
                        clientList = clientList.Where(i => i.Name.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
                        break;
                    }
                case 1:
                    {
                        clientList = clientList.Where(i => i.Surname.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
                        break;
                    }
                case 2:
                    {
                        clientList = clientList.Where(i => i.Patronymic.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
                        break;
                    }
            }

            switch (cmbTypeSort.SelectedIndex)
            {
                case 0:
                    {
                        clientList = clientList.OrderBy(i => i.ID).ToList();
                        break;
                    }
                case 1:
                    {
                        clientList = clientList.OrderBy(i => i.Name).ToList();
                        break;
                    }
                case 2:
                    {
                        clientList = clientList.OrderBy(i => i.Surname).ToList();
                        break;
                    }
                case 3:
                    {
                        clientList = clientList.OrderBy(i => i.Patronymic).ToList();
                        break;
                    }
            }

            lvService.ItemsSource = clientList;
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