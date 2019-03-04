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
using System.Media;


namespace ShiFuMi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Sons du jeu situé dans les ressources
        System.Media.SoundPlayer fist = new System.Media.SoundPlayer(ShiFuMi.Properties.Resources.fist);
        System.Media.SoundPlayer whip = new System.Media.SoundPlayer(ShiFuMi.Properties.Resources.whip);
        System.Media.SoundPlayer sword = new System.Media.SoundPlayer(ShiFuMi.Properties.Resources.sword);
        System.Media.SoundPlayer fightSound = new System.Media.SoundPlayer(ShiFuMi.Properties.Resources.prompt);
        System.Media.SoundPlayer GameMusic = new System.Media.SoundPlayer(ShiFuMi.Properties.Resources.Highlander);
        
        int randomed;
        string[] choice = new string[] { "The Rock", "Cetelem", "Edward ScissorHands" };
        // Saisie utilisateur
        int userAnswer;
        // nb de parties gagnées
        int win = 0;
        // nb de parties perdues
        int lose = 0;
        // nb de parties totales
        int counter = 0;
        // pourcentage de parties gagnées
        double percent;

        public MainWindow()
        {
            InitializeComponent();
        }
        // L'evenement se déclenche au chargement de la page
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GameMusic.Play();
        }
        // Nombre aléatoire en 0 et 2 (3 exclu)
        private void Random()
        {
            randomed = new Random().Next(0, 3);
        }

        private void Stone_Click(object sender, RoutedEventArgs e)
        {
            userAnswer = 0;
            fist.Play();
            stone.Height += 10;
            leaf.Height = 200;
            scissors.Height = 200;
        }

        private void Leaf_Click(object sender, RoutedEventArgs e)
        {
            userAnswer = 1;
            whip.Play();
            leaf.Height += 10;
            stone.Height = 200;
            scissors.Height = 200;
        }

        private void Scissors_Click(object sender, RoutedEventArgs e)
        {
            userAnswer = 2;
            sword.Play();
            scissors.Height += 10;
            leaf.Height = 200;
            stone.Height = 200;
        }

        private void Fight_Click(object sender, RoutedEventArgs e)
        {
            fightSound.Play();
            if ((userAnswer == 0 && randomed == 1) || (userAnswer == 1 && randomed == 2) || (userAnswer == 2 && randomed == 0))
            {
                OutputInfo.Foreground = Brushes.Red;
                OutputInfo.Text = $"Perdu avec { choice[userAnswer]}... \nVotre adversaire avait choisi : { choice[randomed]} ! ";
                lose++;
            }
            else if ((userAnswer == 0 && randomed == 2) || (userAnswer == 1 && randomed == 0) || (userAnswer == 2 && randomed == 1))
            {
                OutputInfo.Foreground = Brushes.Green;
                OutputInfo.Text = $"Gagné avec { choice[userAnswer]} !!! \nVotre adversaire avait choisi : { choice[randomed]} ! ";
                win++;
            }
            else
            {
                OutputInfo.Foreground = Brushes.Gray;
                OutputInfo.Text = $"Egalité avec { choice[userAnswer]} ! \nVotre adversaire avait choisi : { choice[randomed]} ! ";
            }
            counter++;
            OutputCounter.Text = $"Victoires : {win} / Défaites :  {lose} \nNombre de parties : {counter} ";
            Random();
            // conversion du calcul en double puis arrondi à deux chiffres après la virgule
            percent = Math.Round((double)win / counter * 100, 2);
            // Text affiché en bleu
            Percent.Foreground = Brushes.White;
            //Affichage du pourcentage
            Percent.Text = $"Parties Gagnées : {percent.ToString()} %";
        }

        private void StopMusic_Click(object sender, RoutedEventArgs e)
        {
            GameMusic.Stop();
        }

        private void PlayMusic_Click(object sender, RoutedEventArgs e)
        {
            GameMusic.Play();
        }
    }
}
