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
    public partial class Main : Window
    {
        ApplicationContext db;
        public int Root_ID { get; set; }
        public Main()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            db = new ApplicationContext();
            DataContext = this;

        }
        public void GetRootIdUser(int Root_id)
        {
            if (Root_id == 3)
            {
                AdminPanel.Visibility = Visibility.Visible;
                AdminBookPanel.Visibility = Visibility.Visible;
                BibliotekarPanel.Visibility = Visibility.Visible;
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
            }
        }

        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BookPage());
        }

        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminPage());
        }

        private void BtnBack_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

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

        private void BibliotekarPanel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BibliotekarPage());
        }

        private void AdminBookPanel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BookAdminPage());
        }
    }
}