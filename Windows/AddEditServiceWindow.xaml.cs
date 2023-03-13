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
using Microsoft.Win32;
using System.IO;
using _3ISP919_Naliv_LoginReg.DB;
using _3ISP919_Naliv_LoginReg.Windows;
using _3ISP919_Naliv_LoginReg.ClassHelper;

namespace _3ISP919_Naliv_LoginReg.Windows
{
    public partial class AddEditServiceWindow : Window
    {
        private string pathImage = null;
        private bool isEdit = false;
        private Service editService;

        public AddEditServiceWindow()
        {
            // конструктор для добавления
            InitializeComponent();

            isEdit = false;
        }

        public AddEditServiceWindow(Service service)
        {
            // конструктор для редактирования

            InitializeComponent();


            // Изменения заголовка и текста кнопки
            TblockTitle.Text = "Редактирование услуги";
            BtnAddEditService.Content = "Сохранить изменения";

            // Заполнение текстовых полей 
            TbNameService.Text = service.NameService.ToString();
            TbPriceService.Text = service.Cost.ToString();
            TbTimeService.Text = service.Time.ToString();
            TbDescription.Text = service.Description.ToString();

            // вывод изображения

            if (service.Photo != null)
            {
                ImgService.Source = new BitmapImage(new Uri(service.Photo));
            }


            isEdit = true;
            editService = service;

        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            // выбор фото 

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog.ShowDialog() == true)
            {
                ImgService.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathImage = openFileDialog.FileName;
            }
        }

        private void BtnAddEditService_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            if (isEdit == true)
            {
                // изменение
                editService.NameService = TbNameService.Text;
                editService.Cost = Convert.ToDecimal(TbPriceService.Text);
                editService.Time = Convert.ToInt32(TbTimeService.Text);
                editService.Description = TbDescription.Text;
                if (pathImage != null)
                {
                    editService.Photo = pathImage;
                }
                
                EFClass.context.SaveChanges();
                this.Close();
                MessageBox.Show("Услуга успешно изменена");

            }
            else
            {
                // добавление
                Service service = new Service();
                service.NameService = TbNameService.Text;
                service.Cost = Convert.ToDecimal(TbPriceService.Text);
                service.Time = Convert.ToInt32(TbTimeService.Text);
                service.Description = TbDescription.Text;
                service.Photo = pathImage;

                EFClass.context.Service.Add(service);
                EFClass.context.SaveChanges();
                this.Close();
                MessageBox.Show("Услуга успешно добавлена");
            }
        }
    }
}