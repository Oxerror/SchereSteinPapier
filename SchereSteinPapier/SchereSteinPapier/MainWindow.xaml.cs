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

            Player1 = ShowSelections(rbPaper1, rbScissors1, rbStone1, Paper, Stone, Scissors, Stone1, Scissors1, Paper1, pbSelectionPlayer1, txtScissors1.Text, txtStone1.Text, txtPaper1.Text);
            Player2 = ShowSelections(rbPaper2, rbScissors2, rbStone2, Paper, Stone, Scissors, Stone2, Scissors2, Paper2, pbSelectionPlayer2, txtScissors2.Text, txtStone2.Text, txtPaper2.Text);

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
            txtScissors1.Visibility = Visibility.Hidden;
            txtStone1.Visibility = Visibility.Hidden;
            txtPaper1.Visibility = Visibility.Hidden;
            txtScissors2.Visibility = Visibility.Hidden;
            txtStone2.Visibility = Visibility.Hidden;
            txtPaper2.Visibility = Visibility.Hidden;
            pbSelectionPlayer1.IsEnabled = true;
            pbSelectionPlayer2.IsEnabled = true;
            btnConfirm1.IsEnabled = true;
            btnConfirm2.IsEnabled = true;
            rbPaper1.IsEnabled = true;
            rbPaper2.IsEnabled = true;
            rbScissors1.IsEnabled = true;
            rbScissors2.IsEnabled = true;
            rbStone1.IsEnabled = true;
            rbStone2.IsEnabled = true;
            lblChoseLetter1.Visibility = Visibility.Hidden;
            lblChoseLetter2.Visibility = Visibility.Hidden;
            pbSelectionPlayer1.Visibility = Visibility.Visible;
            pbSelectionPlayer2.Visibility = Visibility.Visible;
        }

        private void DisableGame()
        {
            txtBestOfCount.IsEnabled = true;
            txtScissors1.Visibility = Visibility.Visible;
            txtStone1.Visibility = Visibility.Visible;
            txtPaper1.Visibility = Visibility.Visible;
            txtScissors2.Visibility = Visibility.Visible;
            txtStone2.Visibility = Visibility.Visible;
            txtPaper2.Visibility = Visibility.Visible;
            pbSelectionPlayer1.IsEnabled = false;
            pbSelectionPlayer2.IsEnabled = false;
            btnConfirm1.IsEnabled = false;
            btnConfirm2.IsEnabled = false;
            rbPaper1.IsEnabled = false;
            rbPaper2.IsEnabled = false;
            rbScissors1.IsEnabled = false;
            rbScissors2.IsEnabled = false;
            rbStone1.IsEnabled = false;
            rbStone2.IsEnabled = false;
            lblChoseLetter1.Visibility = Visibility.Visible;
            lblChoseLetter2.Visibility = Visibility.Visible;
            pbSelectionPlayer1.Visibility = Visibility.Hidden;
            pbSelectionPlayer2.Visibility = Visibility.Hidden;
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
            return "";
        }

        private void AddPointTo(Label WinCount)
        {
            WinCount.Content = (Convert.ToInt32(WinCount.Content) + 1).ToString();
        }

        private int ShowSelections(RadioButton rbPaper, RadioButton rbScissors, RadioButton rbStone, int Paper, int Stone, int Scissors, Image IStone, Image IScissors, Image IPaper, PasswordBox passwordbox, string Pw1, string Pw2, string Pw3)
        {
            if (passwordbox.Password.Length > 0)
            {
                if (passwordbox.Password == Pw1)
                {
                    HidePictures(IPaper, IStone);
                    return Scissors;
                }
                else if (passwordbox.Password == Pw2)
                {
                    HidePictures(IScissors, IPaper);
                    return Stone;
                }
                else if(passwordbox.Password == Pw3)
                {
                    HidePictures(IScissors, IStone);
                    return Paper;
                }
            }

            if (true == rbPaper.IsChecked)
            {
                HidePictures(IStone, IScissors);
                return Paper;
            }
            else if (true == rbStone.IsChecked)
            {
                HidePictures(IPaper, IScissors);
                return Stone;
            }
            else
            {
                HidePictures(IPaper, IStone);
                return Scissors;
            }
        }

        private void HidePictures(Image Image1, Image Image2)
        {
            Image1.Visibility = Visibility.Hidden;
            Image2.Visibility = Visibility.Hidden;
        }

        private async void AllVisable()
        {
            btnConfirm1.IsEnabled = true;
            btnConfirm2.IsEnabled = true;
            pbSelectionPlayer1.IsEnabled = true;
            pbSelectionPlayer2.IsEnabled = true;
            pbSelectionPlayer1.Clear();
            pbSelectionPlayer2.Clear();
            rbPaper1.IsChecked = false;
            rbPaper2.IsChecked = false;
            rbStone1.IsChecked = false;
            rbStone2.IsChecked = false;
            rbScissors1.IsChecked = false;
            rbScissors2.IsChecked = false;
            // http://stackoverflow.com/questions/15599884/how-to-put-delay-before-doing-an-operation-in-wpf for the Delay
            Paper1.Visibility = await Task.Delay(1000).ContinueWith(_ => Visibility.Visible);
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
            return;
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
            PasswordBox pbSelection;

            int X;

            if (button.Name == "btnConfirm1")
            {
                rbPaper = rbPaper1;
                rbScissors = rbScissors1;
                rbStone = rbStone1;
                pbSelection = pbSelectionPlayer1;
                X = 1;
            }
            else if (button.Name == "btnConfirm2")
            {
                rbPaper = rbPaper2;
                rbScissors = rbScissors2;
                rbStone = rbStone2;
                pbSelection = pbSelectionPlayer2;
                X = 2;
            }
            else
            {
                return;
            }

            if (!(true == rbPaper.IsChecked || true == rbScissors.IsChecked || true == rbStone.IsChecked || ValidPassword(pbSelection, X)))
            {
                MessageBox.Show("You have to select a Value for Player" + X);
                return;
            }
            rbPaper.Visibility = Visibility.Hidden;
            rbStone.Visibility = Visibility.Hidden;
            rbScissors.Visibility = Visibility.Hidden;
            pbSelection.IsEnabled = false;
            button.IsEnabled = false;
            btnPlay.IsEnabled = true;
        }

        private bool ValidPassword(PasswordBox pbSelection, int X)
        {
            string ValidPW1;
            string ValidPW2;
            string ValidPW3;

            if(X == 1)
            {
                ValidPW1 = txtScissors1.Text;
                ValidPW2 = txtStone1.Text;
                ValidPW3 = txtPaper1.Text;
            }
            else
            {
                ValidPW1 = txtScissors2.Text;
                ValidPW2 = txtStone2.Text;
                ValidPW3 = txtPaper2.Text;
            }

            if (pbSelection.Password == ValidPW1 || pbSelection.Password == ValidPW2 || pbSelection.Password == ValidPW3)
            {
                return true;
            }

            return false;
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

        private bool IsTextSame(string Field1, string Field2, string Field3)
        {
            if (Field1 == Field2 || Field1 == Field3 || Field2 == Field3)
            {
                return false;
            }

            return true;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(txtScissors1.Text.Length > 0 && txtStone1.Text.Length > 0 && txtPaper1.Text.Length > 0 && txtScissors2.Text.Length > 0 && txtStone2.Text.Length > 0 && txtPaper2.Text.Length > 0))
            {
                btnPlay.IsEnabled = false;
                return;
            }

            if(IsTextSame(txtScissors1.Text, txtStone1.Text, txtPaper1.Text) == false || IsTextSame(txtScissors2.Text, txtStone2.Text, txtPaper2.Text) == false)
            {
                btnPlay.IsEnabled = false;
                return;
            }

            btnPlay.IsEnabled = true;
        }

        private void OnRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (!(sender is RadioButton))
            {
                return;
            }

            RadioButton radiobutton = (RadioButton)sender;
            PasswordBox PWBox;

            if (radiobutton == rbPaper1 || radiobutton == rbScissors1 || radiobutton == rbStone1)
            {
                PWBox = pbSelectionPlayer1;
            }
            else if (radiobutton == rbPaper2 || radiobutton == rbScissors2 || radiobutton == rbStone2)
            {
                PWBox = pbSelectionPlayer2;
            }
            else
            {
                return;
            }

            PWBox.Clear();
        }

        private void OnPasswordChanged(object sender, KeyEventArgs e)
        {
            if (!(sender is PasswordBox))
            {
                return;
            }

            PasswordBox PWBox = (PasswordBox)sender;
            RadioButton scissors;
            RadioButton stone;
            RadioButton paper;

            if (PWBox == pbSelectionPlayer1)
            {
                scissors = rbScissors1;
                stone = rbStone1;
                paper = rbPaper1;
            }
            else if (PWBox == pbSelectionPlayer2)
            {
                scissors = rbScissors2;
                stone = rbStone2;
                paper = rbPaper2;
            }
            else
            {
                return;
            }

            scissors.IsChecked = false;
            stone.IsChecked = false;
            paper.IsChecked = false;
        }
    }
}
