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
    public partial class EditBookPage : Window
    {
        private Book _currentBook = new Book();
        private ApplicationContext _db;
        public EditBookPage(Book selectedBook, ApplicationContext db)
        {
            InitializeComponent();

            if (selectedBook != null)
                _currentBook = selectedBook;

            DataContext = _currentBook;
            _db = db;
        }

        private void BtnSave_click(object sender, RoutedEventArgs e)
        {
            try
            {
                _db.SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}