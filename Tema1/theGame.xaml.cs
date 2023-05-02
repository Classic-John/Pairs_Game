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
    /// Interaction logic for theGame.xaml
    /// </summary>

    public partial class theGame : Window
    {
        public static Dictionary<string, Person> fP = new Dictionary<string, Person>();
        public string selec;
        int games;
        public theGame(Dictionary<string, Person> fp, string selec, int games)
        {
            InitializeComponent();
            fP = fp;
            this.selec = selec;
            this.games = games;
        } 
        public theGame(Dictionary<string, Person> fp, string selec)
        {
            InitializeComponent();
            fP = fp;
            this.selec = selec;
            this.games = 0;
        }

        private void New_Game_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game(fP,selec);
            game.Show();
            Close();
        }

        private void Open_Game_Click(object sender, RoutedEventArgs e)
        {
            Game gamus= new Game(fP,selec,true,games);
            gamus.Show();
            Close();
        }

        private void Save_Game_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature available in game, not in the menu");
            return;
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            Statistics sta= new Statistics(fP,selec);
            Application.Current.Dispatcher.BeginInvoke(new Action(() => sta.Show()));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(fP);
            mainWindow.Show();
            Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
