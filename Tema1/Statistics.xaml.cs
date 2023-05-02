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
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        Dictionary<string, Person> fp = new Dictionary<string, Person>();
        string selec;
        public Statistics(Dictionary<string,Person> fP,string selec)
        {
            InitializeComponent();
            fp = fP;
            this.selec = selec;
            Player_Name.Content +="\n";
            Won_Games.Content += "\n";
            Total_Games.Content += "\n";
            foreach (Person p in fp.Values ) 
            {
                Player_Name.Content += p.name+"\n";
                Won_Games.Content += Convert.ToString(p.gamesWon)+"\n";
                Total_Games.Content += Convert.ToString(p.gamesPlayed) + "\n";
            }
            Me.Source = fp[selec].Is;
        }
    }
}
