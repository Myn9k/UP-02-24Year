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

    public partial class BookAdminPage : Page
    {
        ApplicationContext db;
        public BookAdminPage()
        {
            InitializeComponent();
            db = new ApplicationContext();
            AllBooks.ItemsSource = db.Books.ToList();
            
        }

        private void BtnAdd(object sender, RoutedEventArgs e)
        {
            AddBookPage addPage = new AddBookPage();
            addPage.ShowDialog();
        }


        private void Books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            db.SaveChanges();
        }
    }
}
