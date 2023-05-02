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

namespace Tema1
{
    /// <summary>
    /// Interaction logic for Delete_User.xaml
    /// </summary>
    public partial class Delete_User : Window
    {
        Dictionary<string, Person> fp= new Dictionary<string, Person>();
        static string user;
        public Delete_User()
        {
            InitializeComponent();
        }
        public Delete_User(Dictionary<string,Person> fp)
        {
            InitializeComponent();
            this.fp = fp;
        }

        private void Sending_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user = DeleteUserBox.Text;
                var mainwindow = Application.Current.MainWindow as MainWindow;
                mainwindow.ExistingAccounts.Remove(user);
                fp.Remove(user);
                MainWindow MainWindow= new MainWindow(fp);
                Close();
                MainWindow.Show();
                
            }
            catch (Exception en)
            {
                MessageBox.Show("The account doesn't exist");
            }
            Close();
        }
    }
}
