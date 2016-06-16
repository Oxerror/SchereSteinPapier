using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Threading;

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

        public int Count = 0;

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (txtBestOfCount.IsEnabled == true && txtBestOfCount.Text.Length > 0)
            {
                txtBestOfCount.Background = Brushes.White;
                EnableGame();
                return;
            }
            else if (txtBestOfCount.Text.Length == 0)
            {
                txtBestOfCount.Background = Brushes.Red;
                return;
            }

            // That nobody can click on the Button while the Code is running
            btnPlay.IsEnabled = false;

            if (SelectionsAreConfirmed() == false)
            {
                return;
            }

            int Player1;
            int Player2;
            int Scissors = 1;
            int Stone = 2;
            int Paper = 3;
            string Winner;

            Player1 = ShowSelections(rbPaper1, rbScissors1, rbStone1, Paper, Stone, Scissors, Stone1, Scissors1, Paper1);
            Player2 = ShowSelections(rbPaper2, rbScissors2, rbStone2, Paper, Stone, Scissors, Stone2, Scissors2, Paper2);

            Winner = ShowResult(Player1, Player2, Scissors, Paper);

            ShowWinner(Winner);

            AllVisable();
            Count++;
            if(Count == Convert.ToInt32(txtBestOfCount.Text))
            {
                MessageBox.Show("The Game is over\n You can now Change the Amount of Rounds to be played");
                Count = 0;
                DisableGame();
            }

            // Wait 3 seconds until the borders get hidden (async)
            HideBorders();
            // Activates the Playbutton again
            btnPlay.IsEnabled = true;
        }

        private async void HideBorders()
        {
            // http://stackoverflow.com/questions/15599884/how-to-put-delay-before-doing-an-operation-in-wpf for the Delay
            BorderPlayer1.Visibility = await Task.Delay(3000).ContinueWith(_ => Visibility.Hidden);
            BorderPlayer2.Visibility = Visibility.Hidden;
            return;
        }

        private void EnableGame()
        {
            txtBestOfCount.IsEnabled = false;
            btnConfirm1.IsEnabled = true;
            btnConfirm2.IsEnabled = true;
            rbPaper1.IsEnabled = true;
            rbPaper2.IsEnabled = true;
            rbScissors1.IsEnabled = true;
            rbScissors2.IsEnabled = true;
            rbStone1.IsEnabled = true;
            rbStone2.IsEnabled = true;
        }

        private void DisableGame()
        {
            txtBestOfCount.IsEnabled = true;
            btnConfirm1.IsEnabled = false;
            btnConfirm2.IsEnabled = false;
            rbPaper1.IsEnabled = false;
            rbPaper2.IsEnabled = false;
            rbScissors1.IsEnabled = false;
            rbScissors2.IsEnabled = false;
            rbStone1.IsEnabled = false;
            rbStone2.IsEnabled = false;
        }

        private void ShowWinner(string Winner)
        {
            if (Winner == "e")
            {
                PaintBorders(BorderPlayer1, "Orange");
                PaintBorders(BorderPlayer2, "Orange");
            }
            else if (Winner == "P1")
            {
                PaintBorders(BorderPlayer1, "Green");
                PaintBorders(BorderPlayer2, "Red");
            }
            else if (Winner == "P2")
            {
                PaintBorders(BorderPlayer1, "Red");
                PaintBorders(BorderPlayer2, "Green");
            }

            BorderPlayer1.Visibility = Visibility.Visible;
            BorderPlayer2.Visibility = Visibility.Visible;
        }

        private void PaintBorders(Border border, string color)
        {
            if (color == "Orange")
            {
                border.BorderBrush = Brushes.Orange;
            }
            else if (color == "Green")
            {
                border.BorderBrush = Brushes.Green;
            }
            else if (color == "Red")
            {
                border.BorderBrush = Brushes.Red;
            }
        }

        private string ShowResult(int Player1, int Player2, int Scissors, int Paper)
        {
            string equal = "e";
            string P1W = "P1";
            string P2W = "P2";

            if (Player1 == Player2)
            {
                return equal;
            }
            else if (Player1 > Player2 || (Player2 == Paper && Player1 == Scissors))
            {
                AddPointTo(lblPlayer1WinsCount);
                return P1W;
            }
            else if (Player2 > Player1 || Player2 == Scissors && Player1 == Paper)
            {
                AddPointTo(lblPlayer2WinsCount);
                return P2W;
            }
            MessageBox.Show("Something went wrong\nPlease contact the Administrator of this game");
            return "";
        }

        private void AddPointTo(Label WinCount)
        {
            WinCount.Content = (Convert.ToInt32(WinCount.Content) + 1).ToString();
        }

        private int ShowSelections(RadioButton rbPaper, RadioButton rbScissors, RadioButton rbStone, int Paper, int Stone, int Scissors, Image IStone, Image IScissors, Image IPaper)
        {
            if (true == rbPaper.IsChecked)
            {
                IStone.Visibility = Visibility.Hidden;
                IScissors.Visibility = Visibility.Hidden;
                return Paper;
            }
            else if (true == rbStone.IsChecked)
            {
                IPaper.Visibility = Visibility.Hidden;
                IScissors.Visibility = Visibility.Hidden;
                return Stone;
            }
            else
            {
                IPaper.Visibility = Visibility.Hidden;
                IStone.Visibility = Visibility.Hidden;
                return Scissors;
            }
        }

        private void AllVisable()
        {
            btnConfirm1.IsEnabled = true;
            btnConfirm2.IsEnabled = true;
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

        private void btnConfrim_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button))
            {
                return;
            }

            var button = (Button)sender;
            RadioButton rbPaper;
            RadioButton rbScissors;
            RadioButton rbStone;
            int X;

            if (button.Name == "btnConfirm1")
            {
                rbPaper = rbPaper1;
                rbScissors = rbScissors1;
                rbStone = rbStone1;
                X = 1;
            }
            else if (button.Name == "btnConfirm2")
            {
                rbPaper = rbPaper2;
                rbScissors = rbScissors2;
                rbStone = rbStone2;
                X = 2;
            }
            else
            {
                return;
            }

            if (!(true == rbPaper.IsChecked || true == rbScissors.IsChecked || true == rbStone.IsChecked))
            {
                MessageBox.Show("You have to select a Value for Player" + X);
                return;
            }
            rbPaper.Visibility = Visibility.Hidden;
            rbStone.Visibility = Visibility.Hidden;
            rbScissors.Visibility = Visibility.Hidden;
            button.IsEnabled = false;
        }

        private bool SelectionsAreConfirmed()
        {
            bool AreConfirmed = false;

            if (false == btnConfirm1.IsEnabled && false == btnConfirm2.IsEnabled)
            {
                AreConfirmed = true;
            }
            else
            {
                MessageBox.Show("Both Player have to Confirm their Selection");
            }

            return AreConfirmed;
        }

        private void OnTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }
    }
}
