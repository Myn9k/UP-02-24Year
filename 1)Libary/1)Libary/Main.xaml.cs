using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    public partial class Main : Window
    {
        ApplicationContext db;
        public int Root_ID { get; set; }
        public int User_ID { get; set; }
        public Main()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            db = new ApplicationContext();
            DataContext = this;

        }
        //Получение айди пользователя и вывод его логина по id
        public void GetIdUser(int id)
        {
            Reader reader = db.Readers.Where(u => u.id == id).FirstOrDefault();
            LoginName.Text = reader.FIO;
        }
        //Права пользователя, кнопки видны по Root_id
        public void GetRootIdUser(int Root_id)
        {
            if (Root_id == 3)
            {
                AdminPanel.Visibility = Visibility.Visible;
                AdminBookPanel.Visibility = Visibility.Visible;
                BibliotekarPanel.Visibility = Visibility.Visible;
                AddReader.Visibility = Visibility.Visible;
            }
            else if (Root_id == 2)
            {
                BibliotekarPanel.Visibility = Visibility.Visible;
            }
            else
            {
                AdminPanel.Visibility = Visibility.Hidden;
                AdminBookPanel.Visibility = Visibility.Hidden;
                BibliotekarPanel.Visibility = Visibility.Hidden;
                AddReader.Visibility = Visibility.Hidden;
            }
        }
        //Открываем страницу книг
        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BookPage());
        }
        //Открываем страницу регистрации взятия книг
        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminPage());
        }
        //Вернутся назад на прошлую страницу(с Аунтификацией не работает)
        private void BtnBack_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
        //Видимость кнопки назад
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }
        //Открываем страницу просмотра читателей
        private void BibliotekarPanel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BibliotekarPage());
        }
        //Открываем страницу редактирования и добавления книг
        private void AdminBookPanel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BookAdminPage());
        }
        //Окно добавления пользователя
        private void AddReader_Click(object sender, RoutedEventArgs e)
        {
            AddReader addReader = new AddReader();
            addReader.ShowDialog();
        }
    }
}