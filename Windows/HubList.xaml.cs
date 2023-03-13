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

namespace _3ISP919_Naliv_LoginReg.Windows
{
    /// <summary>
    /// Логика взаимодействия для HubList.xaml
    /// </summary>
    public partial class HubList : Window
    {
        public HubList()
        {
            InitializeComponent();
        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {
            ServiceManagement serviceManagement = new ServiceManagement();
            Close();
            serviceManagement.Show();
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            UserManagament userManagament = new UserManagament();
            Close();
            userManagament.Show();
        }
    }
}
