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
using System.Data.SqlClient;
using System.Data;

namespace _3ISP919_Naliv_LoginReg
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DB dataBase = new DB();
        int popitka = 3;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Window1 registration = new Window1();
            registration.Show();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            AfterAuth bliN = new AfterAuth();
  

            var loginUser = txbLogin.Text;
            var passwordUser = txbPassword.Text;
        

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querrystring = $"select id, Login, Password from Client where Login = '{loginUser}' and Password = '{passwordUser}'";

            SqlCommand command = new SqlCommand(querrystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            

            if (loginUser == "" || passwordUser == "")
            {

                MessageBox.Show($"Вы не заполнили все поля =(", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            
            if (table.Rows.Count == 1)
            {
                Close();

                MessageBox.Show($"{loginUser}, Вы успешно вошли в аккаунт!", "Успех!!!!");
              
                bliN.Show();
            }

            else
            {

                popitka--;

                if (popitka == 0)
                {
                    MessageBox.Show($"У вас закончились попытки\nПопробуйте позднее...", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Error);
                    Close();
                    return;
                }
                

                
                MessageBox.Show($"Ошибка, введенные данные неверные =(\nУ вас осталось {popitka} попытка", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
