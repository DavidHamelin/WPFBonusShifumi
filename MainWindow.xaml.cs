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

namespace ShiFuMi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int randomed;
        string[] choice = new string[] { "Pierre", "Feuille", "Ciseaux" };
        int userAnswer;
        int win = 0;
        int lose = 0;
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        void Random()
        {
            randomed = new Random().Next(1, 4);
        }

        private void Stone_Click(object sender, RoutedEventArgs e)
        {
            userAnswer = 0;
        }

        private void Leaf_Click(object sender, RoutedEventArgs e)
        {
            userAnswer = 1;
        }

        private void Scissors_Click(object sender, RoutedEventArgs e)
        {
            userAnswer = 2;
        }

        private void Fight_Click(object sender, RoutedEventArgs e)
        {
            if ((userAnswer == 0 && randomed == 1) || (userAnswer == 1 && randomed == 2) || (userAnswer == 2 && randomed == 0))
            {
                OutputInfo.Text = $"Perdu avec { choice[userAnswer]}... \nVotre adversaire avait choisi : { choice[randomed]} !";
                lose++;
            }
            else if ((userAnswer == 0 && randomed == 2) || (userAnswer == 1 && randomed == 0) || (userAnswer == 2 && randomed == 1))
            {
            OutputInfo.Text = $"Gagné avec { choice[userAnswer]} !!! \nVotre adversaire avait choisi : { choice[randomed]}!";
                win++;
            }
            else
            {
            OutputInfo.Text = $"Egalité avec { choice[userAnswer]} ! \nVotre adversaire avait choisi : { choice[randomed]}!";
            }
            counter++;
        OutputCounter.Text = $"Victoires : {win} / Défaites :  {lose} \nNombre de parties : {counter}";
            Random();
        }
    }
}
