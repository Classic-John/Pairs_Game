using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tema1
{
    public struct Details
    {
        public Image Im;
        public ImageSource Is;
        Details(Image Im, ImageSource Is)
        {
            this.Im = Im;
            this.Is = Is;
        }

    }
    public partial class Game : Window
    {
        private List<ImageSource> images = new List<ImageSource>();
        private Image firstCard = null;
        private Image secondCard = null;
        private BitmapImage defaultus = null;
        static public Dictionary<int, Details> results = new Dictionary<int, Details>();
        private Dictionary<int, ImageSource> getTheImage = new Dictionary<int, ImageSource>();
        private Dictionary<string, Person> fp = new Dictionary<string, Person>();
        string selec;
        int i = 1;
        int firstIndex = 0;
        int secondIndex = 0;
        int count = 0;
        int games = 0;
        private void Shuffle(List<ImageSource> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                ImageSource value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        private void LoadGame()
        {
            // Load images into list
            try
            {
                var image = new BitmapImage();
                while (i != 14)
                {
                    image = new BitmapImage(new Uri(@"/GameImages/image" + i + ".jpg", UriKind.Relative));
                    images.Add(image);
                    i++;
                }
                i = 1;
            }
            catch (Exception e)
            {

            }
            // Shuffle images
            Shuffle(images);

            // Add images to cards list
            for (int i = 0; i < images.Count; i++)
            {
                getTheImage[i] = images[i];
            }
            results[0] = new Details { Im = Image1, Is = images[0] }; results[1] = new Details { Im = Image2, Is = images[1] }; results[2] = new Details { Im = Image3, Is = images[2] }; results[3] = new Details { Im = Image4, Is = images[3] }; results[4] = new Details { Im = Image5, Is = images[4] }; results[5] = new Details { Im = Image6, Is = images[5] }; results[6] = new Details { Im = Image7, Is = images[6] }; results[7] = new Details { Im = Image8, Is = images[7] }; results[8] = new Details { Im = Image9, Is = images[8] }; results[9] = new Details { Im = Image10, Is = images[9] }; results[10] = new Details { Im = Image11, Is = images[10] }; results[11] = new Details { Im = Image12, Is = images[11] }; results[12] = new Details { Im = Image13, Is = images[12] }; results[13] = new Details { Im = Image14, Is = images[0] }; results[14] = new Details { Im = Image15, Is = images[1] }; results[15] = new Details { Im = Image16, Is = images[2] }; results[16] = new Details { Im = Image17, Is = images[3] }; results[17] = new Details { Im = Image18, Is = images[4] }; results[18] = new Details { Im = Image19, Is = images[5] }; results[19] = new Details { Im = Image20, Is = images[6] }; results[20] = new Details { Im = Image22, Is = images[7] }; results[21] = new Details { Im = Image23, Is = images[8] }; results[22] = new Details { Im = Image24, Is = images[9] }; results[23] = new Details { Im = Image25, Is = images[10] }; results[24] = new Details { Im = Image26, Is = images[11] };
            defaultus = new BitmapImage(new Uri(@"/GameImages/image" + 0 + ".jpg", UriKind.Relative));
            count = results.Count;
        }

        private void PlayGame()
        {
            LoadGame();

        }
        public Game(int games)
        {
            InitializeComponent();
            this.games = games;
            PlayGame();
            Level.Content += (" " + Convert.ToString(games));
        }
        public Game(Dictionary<string, Person> p, string selec)
        {
            InitializeComponent();
            fp = p;
            this.selec = selec;
            games = 0;
            PlayGame();
            Level.Content += (" " + Convert.ToString(games));
        }
        public Game(Dictionary<string, Person> p, string selec, bool openSaveFile,int games)
        {
            InitializeComponent();
            fp = p;
            this.selec = selec;
            this.games = games;
            PlayGame();
            string[] persons = File.ReadAllLines("saves.txt");
            int k = 0;
            foreach (string person in persons)
            {
                string[] details = Regex.Split(person, @" ");
                if (details[0].Equals("no"))
                {
                    results[k].Im.Visibility = Visibility.Hidden;
                }
                k++;
            }
            StreamWriter writer = new StreamWriter("saves.txt");
            writer.Write("");
            writer.Close();
            k = 0;
            Level.Content += (" "+Convert.ToString(games));
        }

        private void ReplaceImage(Image image, ImageSource source)
        {
            image.Source = source;
            Dispatcher.Invoke(() => { }, DispatcherPriority.Render);
        }
        private void Card_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point clickPosition = e.GetPosition(CardsCanvas);

            HitTestResult hitTestResult = VisualTreeHelper.HitTest(CardsCanvas, clickPosition);
            Image card = hitTestResult.VisualHit as Image;
            int index = CardsCanvas.Children.IndexOf(card);
            if (firstCard == null)
            {
                firstCard = card;
                firstIndex = index;
                ReplaceImage(results[firstIndex].Im, results[firstIndex].Is);
                //firstCard.Opacity = 0.5;
            }
            else
            {
                secondCard = card;
                secondIndex = index;
                ReplaceImage(results[secondIndex].Im, results[secondIndex].Is);

                if (firstCard.Source.ToString() == secondCard.Source.ToString())
                {
                    firstCard.Visibility = Visibility.Hidden;
                    secondCard.Visibility = Visibility.Hidden;
                    firstCard = null;
                    secondCard = null;
                    count -= 2;
                }
                else
                {
                    firstCard.Opacity = 1;
                    secondCard.Opacity = 1;
                    firstCard = null;
                    secondCard = null;
                    Thread.Sleep(3000);
                    results[firstIndex].Im.Source = defaultus;
                    results[secondIndex].Im.Source = defaultus;
                }

            }

            if (count <= 1)
            {

                count = results.Count;
                games++;
                if (games == 3)
                {
                    MessageBox.Show("You have won the pairs game");
                    Close();
                    int played = (fp[selec].gamesPlayed + 1);
                    int won = (fp[selec].gamesWon + 1);
                    Person p = new Person(fp[selec].name, fp[selec].group, fp[selec].spec, played, won);
                    fp[selec] = p;
                    theGame Game = new theGame(fp, selec);
                    Game.Show();
                    Close();
                    return;
                }
                MessageBox.Show("You win this round");
                var newGame = new Game(games);
                Close();
                newGame.Show();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            List<string> saves= new List<string>();
            saves.Add(Image1.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add( Image2.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image3.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add( Image4.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add( Image5.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add( Image6.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add( Image7.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add( Image8.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image9.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image10.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image11.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add( Image12.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add( Image13.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image14.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image15.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image16.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image17.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image18.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image19.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image20.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image22.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image23.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image24.Visibility == Visibility.Visible ? "yes" : "no");
            saves.Add(Image25.Visibility == Visibility.Visible ? "yes" : "no");
            int i = 0;
            StreamWriter writer = new StreamWriter("saves.txt");
            foreach (string answer in saves)
            {
                if(i ==images.Count) 
                {
                    i = 0;
                }
                writer.WriteLine(answer + " " + images[i++]);
            }
            writer.Close();
            theGame gamus = new theGame(fp, selec,games);
            gamus.Show();
            Close();
            return;
        }

        private void Loser_Click(object sender, RoutedEventArgs e)
        {
            int played = (fp[selec].gamesPlayed + 1);
            Person p = new Person(fp[selec].name, fp[selec].group, fp[selec].spec, played, fp[selec].gamesWon);
            fp[selec] = p;
            theGame Game = new theGame(fp, selec);
            Game.Show();
            Close();
            return;
        }
    }
}

