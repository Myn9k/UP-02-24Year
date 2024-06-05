using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _1_Libary
{
    public partial class AdminPage : Page
    {
        private ApplicationContext db;

        public AdminPage()
        {
            InitializeComponent();
            db = new ApplicationContext();
            //Выводит ФИО пользователя, но при выборе отправляет id 
            List<Reader> readers = db.Readers.ToList();
            ReadIdBox.ItemsSource = readers;
            ReadIdBox.DisplayMemberPath = "FIO";
            ReadIdBox.SelectedValuePath = "id";
            ReadIdBox.SelectedIndex = 0;

            //Выводит название Книги, но при выборе отправляет id 
            List<Book> books = db.Books.ToList();
            InventoryidBox.ItemsSource = books;
            InventoryidBox.DisplayMemberPath = "Title";
            InventoryidBox.SelectedValuePath = "id";
            InventoryidBox.SelectedIndex = 0;
        }

        //При клике добавляется событие взятия книги(её id) пользователем(его id)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Первые 2 парсят текстовое значение "id" -> id
            int selectedReaderId = (int)ReadIdBox.SelectedValue;
            int selectedBookId = (int)InventoryidBox.SelectedValue;
            string datevidachi = datevidachiBox.Text.Trim();
            string planedatevidachi = planedatevidachiBox.Text.Trim();
            string realdatevidachi = realdatevidachiBbox.Text.Trim();

            if (datevidachi.Length < 1 || !datevidachi.Contains("."))
            {
                datevidachiBox.ToolTip = "Это поле введено не корректно";
                datevidachiBox.Background = Brushes.DarkRed;
            }
            else if (planedatevidachi.Length < 1 || !planedatevidachi.Contains("."))
            {
                planedatevidachiBox.ToolTip = "Это поле введено не корректно";
                planedatevidachiBox.Background = Brushes.DarkRed;
            }
            else if (realdatevidachi.Length < 1 || !realdatevidachi.Contains("."))
            {
                realdatevidachiBbox.ToolTip = "Это поле введено не корректно";
                realdatevidachiBbox.Background = Brushes.DarkRed;
            }
            else
            {
                datevidachiBox.ToolTip = "";
                datevidachiBox.Background = Brushes.Transparent;
                planedatevidachiBox.ToolTip = "";
                planedatevidachiBox.Background = Brushes.Transparent;
                realdatevidachiBbox.ToolTip = "";
                realdatevidachiBbox.Background = Brushes.Transparent;

                Register register = new Register
                {
                    Inventoryid = selectedBookId,
                    Readerid = selectedReaderId,
                    Datevidachi = datevidachi,
                    Planedatevidachi = planedatevidachi,
                    Realdatevidachi = realdatevidachi
                };

                db.Registers.Add(register);
                db.SaveChanges();
                MessageBox.Show($"Событие добавлено");
            }
        }
    }
}
