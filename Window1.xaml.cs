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
using System.Data.SqlClient;
using System.Data;

namespace _3ISP919_Naliv_LoginReg
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        DB dataBase = new DB();
        public Window1()
        {

            InitializeComponent();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            var loginUser = txbRegLogin.Text;
            var firstName = txbRegName.Text;
            var lastName = txbRegSurname.Text;
            var patronymic = txbRegPatronymic.Text;
            var password = txbRegPassword.Text;
            var password_repeat = txbRegPasswordRepeat.Text;
            
            if (loginUser == "" || firstName == "" || lastName == "" || password == "" || password_repeat == "")
            {
                MessageBox.Show("Ошибка, вы заполнили не все поля =(", "=(");
                return;
            }

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querrystring = $"select id, Login, Password from Client where Login = '{loginUser}'";

            SqlCommand command = new SqlCommand(querrystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show($" Логин {loginUser} уже занят =(", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != password_repeat)
            {
                MessageBox.Show("Ошибка, пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txbRegPassword.Text = "";
                txbRegPasswordRepeat.Text = "";
                return;
            }

            

            querrystring = $"insert into Client VALUES ('{loginUser}','{firstName}','{lastName}','{patronymic}','{password}')";

            command = new SqlCommand(querrystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);


            Close();
            MessageBox.Show("Вы успешно зарегистрировались", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);


        }
    }


}
