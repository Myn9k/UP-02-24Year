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
        public int Root_id { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            Root_id = 1;
            Main main = new Main()
            {
                Root_ID = Root_id,
            };
            main.GetRootIdUser(Root_id);
            main.Show();
            this.Close();
        }

        private void Button1_Auth_Click(object sender, RoutedEventArgs e)
        {
            Root_id = 2;
            Main main = new Main()
            {
                Root_ID = Root_id,
            };
            main.GetRootIdUser(Root_id);
            main.Show();
            this.Close();
        }
    

        private void Button2_Auth_Click(object sender, RoutedEventArgs e)
        {
            Root_id = 3;
            Main main = new Main()
            {
                Root_ID = Root_id,
            };
            main.GetRootIdUser(Root_id);
            main.Show();
            this.Close();
        }
    }
}