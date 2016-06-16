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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchereSteinPapier
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (SelectionsAreConfirmed() == false)
            {
                return;
            }

            int Player1;
            int Player2;
            int Scissors = 1;
            int Stone = 2;
            int Paper = 3;


            Player1 = ShowSelections(rbPaper1, rbScissors1, rbStone1, Paper, Stone, Scissors);
            Player2 = ShowSelections(rbPaper2, rbScissors2, rbStone2, Paper, Stone, Scissors);

            ShowResult(Player1, Player2, Scissors, Paper);

            AllVisable();
        }

        private void ShowResult(int Player1, int Player2, int Scissors, int Paper)
        {
            if (Player1 == Player2)
            {
                MessageBox.Show("Both Player have chosen the same");
            }
            else if (Player2 == Scissors && Player1 == Paper)
            {
                MessageBox.Show("Player 2 have won this Round");
            }
            else if (Player1 > Player2 || (Player2 == Paper && Player1 == Scissors))
            {
                MessageBox.Show("Player 1 have won this Round");
            }
            else if (Player2 > Player1)
            {
                MessageBox.Show("Player 2 have won this Round");
            }
        }

        private int ShowSelections(RadioButton rbPaper, RadioButton rbScissors, RadioButton rbStone, int Paper, int Stone, int Scissors)
        {
            if (true == rbPaper1.IsChecked)
            {
                Stone1.Visibility = Visibility.Hidden;
                Scissors1.Visibility = Visibility.Hidden;
                return Paper;
            }
            else if (true == rbStone1.IsChecked)
            {
                Paper1.Visibility = Visibility.Hidden;
                Scissors1.Visibility = Visibility.Hidden;
                return Stone;
            }
            else
            {
                Paper1.Visibility = Visibility.Hidden;
                Stone1.Visibility = Visibility.Hidden;
                return Scissors;
            }
        }

        private void AllVisable()
        {
            btnConfirm1.IsEnabled = true;
            btnConfrim2.IsEnabled = true;
            Paper1.Visibility = Visibility.Visible;
            Scissors1.Visibility = Visibility.Visible;
            Stone1.Visibility = Visibility.Visible;
            Paper2.Visibility = Visibility.Visible;
            Scissors2.Visibility = Visibility.Visible;
            Stone2.Visibility = Visibility.Visible;
            rbPaper1.Visibility = Visibility.Visible;
            rbStone1.Visibility = Visibility.Visible;
            rbScissors1.Visibility = Visibility.Visible;
            rbPaper2.Visibility = Visibility.Visible;
            rbStone2.Visibility = Visibility.Visible;
            rbScissors2.Visibility = Visibility.Visible;
        }

        private void btnConfrim1_Click(object sender, RoutedEventArgs e)
        {
            if(!(true == rbPaper1.IsChecked || true == rbScissors1.IsChecked || true == rbStone1.IsChecked))
            {
                MessageBox.Show("You have to select a Value for Player 1");
                return;
            }
            rbPaper1.Visibility = Visibility.Hidden;
            rbStone1.Visibility = Visibility.Hidden;
            rbScissors1.Visibility = Visibility.Hidden;
            btnConfirm1.IsEnabled = false;
        }

        private void btnConfrim2_Click(object sender, RoutedEventArgs e)
        {
            if (!(true == rbPaper2.IsChecked || true == rbScissors2.IsChecked || true == rbStone2.IsChecked))
            {
                MessageBox.Show("You have to select a Value for Player 2");
                return;
            }
            rbPaper2.Visibility = Visibility.Hidden;
            rbStone2.Visibility = Visibility.Hidden;
            rbScissors2.Visibility = Visibility.Hidden;
            btnConfrim2.IsEnabled = false;
        }

        private bool SelectionsAreConfirmed()
        {
            bool AreConfirmed = false;

            if(false == btnConfirm1.IsEnabled && false == btnConfrim2.IsEnabled)
            {
                AreConfirmed = true;
            }
            else
            {
                MessageBox.Show("Both Player have to Confirm their Selection");
            }

            return AreConfirmed;
        }
    }
}
