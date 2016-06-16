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


            Player1 = ShowSelections(rbPaper1, rbScissors1, rbStone1, Paper, Stone, Scissors, Stone1, Scissors1, Paper1);
            Player2 = ShowSelections(rbPaper2, rbScissors2, rbStone2, Paper, Stone, Scissors, Stone2, Scissors2, Paper2);

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
                AddPointTo(lblPlayer2WinsCount);
            }
            else if (Player1 > Player2 || (Player2 == Paper && Player1 == Scissors))
            {
                MessageBox.Show("Player 1 have won this Round");
                AddPointTo(lblPlayer1WinsCount);
            }
            else if (Player2 > Player1)
            {
                MessageBox.Show("Player 2 have won this Round");
                AddPointTo(lblPlayer2WinsCount);
            }
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
            if(!(sender is Button))
            {
                return;
            }

            var button = (Button)sender;
            RadioButton rbPaper;
            RadioButton rbScissors;
            RadioButton rbStone;

            if(button.Name == "btnConfirm1")
            {
                rbPaper = rbPaper1;
                rbScissors = rbScissors1;
                rbStone = rbStone1;
            }
            else if (button.Name == "btnConfirm2")
            {
                rbPaper = rbPaper2;
                rbScissors = rbScissors2;
                rbStone = rbStone2;
            }
            else
            {
                return;
            }

            if (!(true == rbPaper.IsChecked || true == rbScissors.IsChecked || true == rbStone.IsChecked))
            {
                MessageBox.Show("You have to select a Value for Player 1");
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

            if(false == btnConfirm1.IsEnabled && false == btnConfirm2.IsEnabled)
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
