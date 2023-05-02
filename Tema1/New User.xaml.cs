using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Tema1
{
    public partial class NewUserWindow : Window
    {
        ObservableCollection<string> EA;
        Dictionary<string, Person> fp;

        public NewUserWindow(ObservableCollection<string> EA, Dictionary<string, Person> fP)
        {
            InitializeComponent();
            this.EA = EA;
            this.fp = fP;
        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string newAccountName = NewAccountNameTextBox.Text;

            if (string.IsNullOrEmpty(newAccountName))
            {
                MessageBox.Show("Please enter a valid account name.");
                return;
            }
            EA.Add(newAccountName);
            fp[newAccountName] = new Person(newAccountName,"secret","topSecret",0,0);
            var mainWindow = new MainWindow(EA,fp);
            mainWindow.Show();
            Close();
        }

        private void ChangePicture_Click(object sender, RoutedEventArgs e)
        {
            Random rnt = new Random();
            int i = rnt.Next() % 10;
            BitmapImage image = new BitmapImage(new Uri(@"/AccountImages/face" + i + ".jpg", UriKind.Relative));
            NewUserImage.Source = image;
        }
    }
}