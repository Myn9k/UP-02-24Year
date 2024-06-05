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
    public partial class BibliotekarPage : Page
    {
        ApplicationContext db;
        public BibliotekarPage()
        {
            InitializeComponent();
            db = new ApplicationContext();
            UpdateReader();
        }
        //Обновление списка читателей в XAML файле через БД
        private void UpdateReader()
        {
            List<Reader> readers = db.Readers.ToList();
            readers = readers.Where(p => p.FIO.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            LViewReader.ItemsSource = readers.ToList();
        }
        //Поиск читателей
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateReader();
        }
    }
}
