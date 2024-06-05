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

namespace _1_Libary
{
    public partial class AddReader : Window
    {
        private ApplicationContext db;
        public AddReader()
        {
            InitializeComponent();
            db = new ApplicationContext();
            //Выводит наименование прав пользователя, но при выборе отправляет id 
            List<Root> roots = db.Roots.ToList();
            RootIdBox.ItemsSource = roots;
            RootIdBox.DisplayMemberPath = "Name";
            RootIdBox.SelectedValuePath = "id";
            RootIdBox.SelectedIndex = 0;
        }
        //Сохранение пользователя
        private void BtnSave_click(object sender, RoutedEventArgs e)
        {
            //первое переделывает "id" -> id   ТО есть строкове значение в интовое(целочисленное)
            int selectedRootId = (int)RootIdBox.SelectedValue;
            string fio = FIOBox.Text.Trim();
            string adress = AdressBox.Text.Trim();
            string phone = PhoneBox.Text.Trim();
            string login = LoginBox.Text.Trim();
            string pass = PassBox.Text.Trim();


            if (fio.Length < 1 && !fio.Contains(" "))
            {
                FIOBox.ToolTip = "Это поле введено не корректно";
                FIOBox.Background = Brushes.DarkRed;
            }
            else if (adress.Length < 1)
            {
                AdressBox.ToolTip = "Это поле введено не корректно";
                AdressBox.Background = Brushes.DarkRed;
            }
            else if (login.Length < 1)
            {
                LoginBox.ToolTip = "Это поле введено не корректно";
                LoginBox.Background = Brushes.DarkRed;
            }

            else if (pass.Length < 1)
            {
                PassBox.ToolTip = "Это поле введено не корректно";
                PassBox.Background = Brushes.DarkRed;
            }

            else
            {
                FIOBox.ToolTip = "";
                FIOBox.Background = Brushes.Transparent;
                AdressBox.ToolTip = "";
                AdressBox.Background = Brushes.Transparent;
                PhoneBox.ToolTip = "";
                PhoneBox.Background = Brushes.Transparent;
                LoginBox.ToolTip = "";
                LoginBox.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;


                Reader reader = new Reader(fio, adress, phone, selectedRootId, login, pass);

                db.Readers.Add(reader);
                db.SaveChanges();
                MessageBox.Show($"{reader.FIO} добавлен");
            }
        }

    }
}