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
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public int Root_id { get; set; }
        public int User_id { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }
        private void NewMain(int Root_id, int User_id)
        {
            Main main = new Main()
            {
                Root_ID = Root_id,
                User_ID = User_id
            };
            main.GetRootIdUser(Root_id);
            main.GetIdUser(User_id);
            main.Show();
            this.Close();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = passbox.Password.Trim();

            List<Reader> readers = db.Readers.ToList();

            foreach (Reader reader in readers)
            {
                if (login != reader.Login)
                {
                    TextBoxLogin.ToolTip = "Такого Логина не существует";
                    TextBoxLogin.Background = Brushes.DarkRed;
                }
                else if (pass != reader.Pass)
                {
                    passbox.ToolTip = "Такого Пароля не существует";
                    passbox.Background = Brushes.DarkRed;
                }
                else
                {
                    TextBoxLogin.ToolTip = "";
                    TextBoxLogin.Background = Brushes.Transparent;
                    passbox.ToolTip = "";
                    passbox.Background = Brushes.Transparent;

                    Reader authReader = null;
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        authReader = db.Readers.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                    }

                    if (authReader != null)
                    {
                        NewMain(authReader.Rootid, authReader.id);
                    }
                }
            }
        }
    }
}
