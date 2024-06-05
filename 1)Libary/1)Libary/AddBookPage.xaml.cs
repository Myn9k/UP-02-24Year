﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class AddBookPage : Window
    {
        private ApplicationContext db;
        private byte[] images_bytes;

        public AddBookPage()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }
        //Выбор изображения и дальнейший перевод его в список байтов,
        //переводит в локальную переменную images_bytes значения выбраной фотки

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            byte[] images_byte = File.ReadAllBytes(openFileDialog.FileName); //Получаем байты выбранного изображения
            images_bytes = images_byte;
        }
        //Добавляет книгу используя images_bytes
        private void BtnSave_click(object sender, RoutedEventArgs e)
        {
            string title = TitleBox.Text.Trim();
            string author = AuthorBox.Text.Trim();
            string quanty = QuantyBox.Text.Trim();
            byte[] image = images_bytes;


            if (title.Length < 1)
            {
                TitleBox.ToolTip = "Это поле введено не корректно";
                TitleBox.Background = Brushes.DarkRed;
            }
            else if (author.Length < 1)
            {
                AuthorBox.ToolTip = "Это поле введено не корректно";
                AuthorBox.Background = Brushes.DarkRed;
            }

            else if (quanty.Length < 1)
            {
                QuantyBox.ToolTip = "Это поле введено не корректно";
                QuantyBox.Background = Brushes.DarkRed;
            }

            else
            {
                TitleBox.ToolTip = "";
                TitleBox.Background = Brushes.Transparent;
                AuthorBox.ToolTip = "";
                AuthorBox.Background = Brushes.Transparent;
                QuantyBox.ToolTip = "";
                QuantyBox.Background = Brushes.Transparent;

                Book book = new Book(title, author, quanty, image);

                db.Books.Add(book);
                db.SaveChanges();
                MessageBox.Show($"{book.Title} добавлен");
            }
        }

    }
}