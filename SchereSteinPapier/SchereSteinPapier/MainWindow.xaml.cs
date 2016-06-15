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

  //          foreach(RadioButton rb in )


//            for (int i = 1; i <= 2; i++)
//            {
//                string Selected = IsSelected(i);
//                ShowSelections(Selected, i);
//            }

            if(true == rbPaper1.IsChecked)
            {
                Stone1.Visibility = Visibility.Hidden;
                Scissors1.Visibility = Visibility.Hidden;
            }
            else if (true == rbStone1.IsChecked)
            {
                Paper1.Visibility = Visibility.Hidden;
                Scissors1.Visibility = Visibility.Hidden;
            }
            else
            {
                Paper1.Visibility = Visibility.Hidden;
                Stone1.Visibility = Visibility.Hidden;
            }

            if (true == rbPaper2.IsChecked)
            {
                Stone2.Visibility = Visibility.Hidden;
                Scissors2.Visibility = Visibility.Hidden;
            }
            else if (true == rbStone2.IsChecked)
            {
                Paper2.Visibility = Visibility.Hidden;
                Scissors2.Visibility = Visibility.Hidden;
            }
            else
            {
                Paper2.Visibility = Visibility.Hidden;
                Stone2.Visibility = Visibility.Hidden;
            }





            btnConfirm1.IsEnabled = true;
            btnConfrim2.IsEnabled = true;            
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

 //       private string IsSelected(int Player)
 //       {
 //           return Selected;
 //       }
 //
        private void ShowSelections(string Selection, int Player)
        {

        }
    }
}
