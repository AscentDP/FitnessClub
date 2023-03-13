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

namespace _3ISP919_Naliv_LoginReg.Windows
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Window1 registration = new Window1();
            Close();
            registration.Show();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var authUser = ClassHelper.EFClass.context.Client.ToList()
                .Where(i => i.Login == txbLogin.Text && i.Password == txbPassword.Text)
                .FirstOrDefault();

            if (authUser != null)
            {
                HubList hubList = new HubList();
                Close();
                hubList.Show();
            }
            else
            {
                MessageBox.Show("Вы ввели неверные данные. Попробуйте снова", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txbLogin.Text = "";
                txbPassword.Text = "";
            }
        }
    }
}
