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
    public partial class Window1 : Window
    {
        public Window1()
        {

            InitializeComponent();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (txbRegLogin.Text == "" || txbRegName.Text == "" || txbRegName.Text == "" || txbRegPassword.Text == "" || txbRegPasswordRepeat.Text == "" || txbRegPatronymic.Text == "" || txbRegSurname.Text == "")
            {
                MessageBox.Show("Вы заполнили не все поля =(", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txbRegPassword.Text != txbRegPasswordRepeat.Text)
            {
                MessageBox.Show("Введенные пароли не совпадают =(", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txbRegPassword.Text = "";
                txbRegPasswordRepeat.Text = "";
                return;
            }

            if (txbRegPassword.Text.Length < 10)
            {
                MessageBox.Show("Пароль не может быть меньше, чем 10 символов =(", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txbRegPassword.Text = "";
                txbRegPasswordRepeat.Text = "";
                return;
            }

            // Добавление клиента
            Client client = new Client();

            client.Login = txbRegLogin.Text;
            client.Surname = txbRegSurname.Text;
            client.Name = txbRegName.Text;
            client.Patronymic = txbRegPatronymic.Text;
            client.Password = txbRegPassword.Text;


            ClassHelper.EFClass.context.Client.Add(client);

            ClassHelper.EFClass.context.SaveChanges();

            MainWindow auth = new MainWindow();
            Close();
            auth.Show();

            MessageBox.Show($"{txbRegName.Text}, Вы успешно зарегистрировались", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }


    }
}
