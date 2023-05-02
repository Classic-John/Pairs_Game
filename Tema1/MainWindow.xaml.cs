using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Microsoft.VisualBasic;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.Collections;
using System.Windows.Interop;
using System.Text.RegularExpressions;

namespace Tema1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public struct Person
    {
        public string name;
        public string group;
        public string spec;
        public BitmapImage Is;
        public int gamesPlayed;
        public int gamesWon;
        public Person(string name, string group, string spec)
        {
            this.name = name;
            this.group = group;
            this.spec = spec;
            Is = null;
            gamesPlayed = 0;
            gamesWon = 0;
        }
        public Person(string name, string group, string spec, int gamesPlayed, int gamesWon)
        {
            this.name = name;
            this.group = group;
            this.spec = spec;
            Is = null;
            this.gamesPlayed = gamesPlayed;
            this.gamesWon = gamesWon;
        }
    }
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> ExistingAccounts { get; } = new ObservableCollection<string>();
        public ObservableCollection<Person> people { get; } = new ObservableCollection<Person>();
        static Dictionary<int, BitmapImage> showImages = new Dictionary<int, BitmapImage>();
        static Dictionary<string, Person> findPerson = new Dictionary<string, Person>();
        private static string _selectedAccounts;
        int i = 0;
        int picChosen = 0;
        List<BitmapImage> images = new List<BitmapImage>();
        public string SelectedAccounts

        {
            get { return _selectedAccounts; }
            set
            {
                _selectedAccounts = value;
                OnPropertyChanged(nameof(IsPlayButtonEnabled));
            }
        }
        public static BitmapImage BorrowImage()
        {
            Random rnt = new Random();
            BitmapImage image = new BitmapImage();
            image = showImages[showImages.Count % rnt.Next()];
            return image;
        }
        private void TakeImagesFromResource()
        {
            i = 1;
            try
            {
                var image = new BitmapImage();
                while (i != 12)
                {
                    image = new BitmapImage(new Uri(@"/AccountImages/face" + i + ".jpg", UriKind.Relative));
                    images.Add(image);
                    showImages.Add(i, image);
                    i++;
                }
            }
            catch (Exception e)
            {
                return;
            }
        }
        private void ReadFile()
        {
            string[] persons = File.ReadAllLines("Accounts.txt");
            foreach (string person in persons)
            {
                string[] details = Regex.Split(person, @"_");
                Person p = new Person(details[0], details[1], details[2]);
                people.Add(p);
                findPerson[p.name] = p;
                ExistingAccounts.Add(details[0]);
            }
        }
        public bool IsPlayButtonEnabled => !string.IsNullOrEmpty(_selectedAccounts);
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            i = 1;
            ReadFile();
            TakeImagesFromResource();
        }
        public MainWindow(Dictionary<string, Person> fp)
        {

            InitializeComponent();
            DataContext = this;
            i = 1;
            ReadFile();
            findPerson = fp;
            TakeImagesFromResource();
            
        }
        public MainWindow(ObservableCollection<string> EA,Dictionary<string,Person>fP)
        {

            InitializeComponent();
            DataContext = this;
            i = 1;
            ReadFile();
            findPerson = fP;
            ExistingAccounts = EA;
            TakeImagesFromResource();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Play_game_Click(object sender, RoutedEventArgs e)
        {
            if (IsPlayButtonEnabled == false)
            {
                MessageBox.Show("No strangers allowed here");
                return;
            }
            findPerson[_selectedAccounts] = new Person { name = _selectedAccounts, group = findPerson[_selectedAccounts].group, spec = findPerson[_selectedAccounts].spec, Is = images[picChosen] };
            theGame game = new theGame(findPerson,_selectedAccounts);
            Close();
            game.ShowDialog();
        }
        public static Label getName(Label l)
        {
            l.Content = findPerson[_selectedAccounts].name;

            return l;
        }
        public static Label getGroup(Label l)
        {
            l.Content = findPerson[_selectedAccounts].group;
            return l;
        }
        public static string getSpec(string l)
        {
            l += findPerson[_selectedAccounts].spec;
            return l;
        }
        public string getDetails(string l)
        {
            foreach (Person p in findPerson.Values)
            {
                l += p.name+"\n";
            }
            return l;
        }
        private void User_Click(object sender, RoutedEventArgs e)
        {
            var newUserWindow = new NewUserWindow(ExistingAccounts,findPerson);
            Close();
            newUserWindow.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (IsPlayButtonEnabled == false)
            {
                MessageBox.Show("You're not worthy of erasing people");
                return;
            }
            var deleteUser = new Delete_User();
            Close();
            deleteUser.Show();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            i--;
            if (i < 1)
            {
                i = images.Count - 1;
            }
            ImageControl.Source = showImages[i];
            picChosen = i;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i >= showImages.Count)
            {
                i = 1;
            }
            ImageControl.Source = showImages[i];
            picChosen = i;
        }

        private void AccountsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
