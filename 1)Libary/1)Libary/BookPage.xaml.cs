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

namespace _1_Libary
{
    public partial class BookPage : Page
    {
        ApplicationContext db;
        public BookPage()
        {
            InitializeComponent();
            db = new ApplicationContext();
            List<Book> book = db.Books.ToList();
            UpdateBook();
        }
        private void UpdateBook()
        {
            List<Book> book = db.Books.ToList();


            book = book.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            LViewBook.ItemsSource = book.ToList();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateBook();
        }
    }
}