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
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchaebigeSchaetzungen.View
{
    /// <summary>
    /// Interaction logic for MultiplayerGameView.xaml
    /// </summary>
    public partial class MultiplayerGameView : UserControl
    {
        int viewCount;
        int commentCount;
        int likeCount;
        string language;
        int round;
        string[] VideoIDs;
        int PlayerOneguess;
        int PlayerTwoguess;

        public MultiplayerGameView()
        {
            round=0;
            InitializeComponent();
            Init();

        }

        public async void Init()
        {

            Model.Video video = new Model.Video();
            await video.GetDetailsAsync(video.VideoID);
            webBrowser1.NavigateToString(video.Dispstr);

            viewCount=video.Views;
            likeCount=video.Likes;
            commentCount=video.Comments;
            language=video.Language;


            P1Submit.Visibility= Visibility.Visible;
            TextBox1.Visibility= Visibility.Visible;
            P1.Visibility= Visibility.Visible;
            P2Submit.Visibility= Visibility.Visible;
            TextBox2.Visibility= Visibility.Visible;
            P2.Visibility= Visibility.Visible;
            HintCheckBox.Visibility= Visibility.Visible;
            NAButton.Visibility= Visibility.Visible;
            if (HintCheckBox.IsChecked==true)
            {
                HintLikes.Content = "Likes: " + likeCount.ToString();
                HintLikes.Visibility = Visibility.Visible;
                HintComments.Content = "Comments: "+ commentCount.ToString();
                HintComments.Visibility = Visibility.Visible;
            }

            HintLabel.Content= "Hints";
            AbstandLabel.Content="";

            ViewTextBox.Visibility = Visibility.Collapsed;
            PointsTextBox.Visibility= Visibility.Collapsed;
            PointsTextBox2.Visibility= Visibility.Collapsed;
            ViewLabel.Visibility= Visibility.Collapsed;
            PointsLabel.Visibility= Visibility.Collapsed;
            PointsLabel2.Visibility= Visibility.Collapsed;


            LanguageLabel.Visibility = Visibility.Collapsed;
            NextRound.Visibility = Visibility.Collapsed;
            TextBox1.Text="";
            TextBox2.Text="";
        }

        private void P1Submit_Click(object sender, RoutedEventArgs e)
        {

            if (!Int32.TryParse(TextBox1.Text, out PlayerOneguess))
            {
                MessageBox.Show("You did not insert a number!", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            BindingExpression binding = TextBox1.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();

            if (P2Submit.Visibility==Visibility.Collapsed) //Zweiter spieler hat schon getippt
            {
                InitNR();

            }
            else //Zweiter Spieler noch nicht getippt
            {
                P1Submit.Visibility= Visibility.Collapsed;
                TextBox1.Text="******************";
            }
        }

        private void P2Submit_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(TextBox2.Text, out PlayerTwoguess))
            {
                MessageBox.Show("You did not insert a number!", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            BindingExpression binding = TextBox2.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();

            if (P1Submit.Visibility==Visibility.Collapsed) //Erster spieler hat schon getippt
            {
                InitNR();

            }
            else //Zweiter Spieler noch nicht getippt
            {
                P2Submit.Visibility= Visibility.Collapsed;
                TextBox2.Text="******************";
            }
        }

        private void NextRound_Click(object sender, RoutedEventArgs e)
        {
            Init();
            round++;

        }

        private void HintCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            HintLikes.Content = "Likes: " + likeCount.ToString();
            HintLikes.Visibility = Visibility.Visible;
            HintComments.Content = "Comments: "+ commentCount.ToString();
            HintComments.Visibility = Visibility.Visible;
        }
        private void HintCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            HintLikes.Visibility = Visibility.Collapsed;
            HintComments.Visibility = Visibility.Collapsed;
        }
        private void InitNR()
        {
            ViewTextBox.Text= viewCount.ToString();
            BindingExpression binding = ViewTextBox.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();

            int[] pts = CalculateMultiplayerPoints(PlayerOneguess, PlayerTwoguess, viewCount);
            PointsTextBox.Text=pts[0].ToString();
            BindingExpression binding2 = PointsTextBox.GetBindingExpression(TextBox.TextProperty);
            binding2.UpdateSource();
            PointsTextBox2.Text=pts[1].ToString();
            BindingExpression binding3 = PointsTextBox2.GetBindingExpression(TextBox.TextProperty);
            binding3.UpdateSource();

            ViewTextBox.Visibility = Visibility.Visible;
            PointsTextBox.Visibility= Visibility.Visible;
            PointsTextBox2.Visibility= Visibility.Visible;
            ViewLabel.Visibility= Visibility.Visible;
            PointsLabel.Visibility= Visibility.Visible;
            PointsLabel2.Visibility= Visibility.Visible;

            HintCheckBox.Visibility= Visibility.Collapsed;
            HintLikes.Visibility = Visibility.Collapsed;
            HintComments.Visibility = Visibility.Collapsed;
            HintLabel.Content= "Du lagst " +Math.Abs(viewCount - PlayerOneguess)+ " von der richtigen Lösung weg!";
            AbstandLabel.Content="Du lagst" +Math.Abs(viewCount - PlayerTwoguess)+ " von der richtigen Lösung weg!";
            LanguageLabel.Content="Language: "+language;
            LanguageLabel.Visibility = Visibility.Visible;


            NAButton.Visibility= Visibility.Collapsed;
            P1Submit.Visibility= Visibility.Collapsed;
            TextBox1.Visibility= Visibility.Collapsed;
            P1.Visibility= Visibility.Collapsed;
            P2Submit.Visibility= Visibility.Collapsed;
            TextBox2.Visibility= Visibility.Collapsed;
            P2.Visibility= Visibility.Collapsed;
            TextBox1.Text="";
            if (round > 1) // Spiel vorbei?
            {
                ResultBtn.Visibility= Visibility.Visible;
            }
            else
            {
                NextRound.Visibility= Visibility.Visible;
            }
        }

        int[] CalculateMultiplayerPoints(int P1guess, int P2guess, int Views)
        {
            int distance1 = Math.Abs(P1guess - Views);
            int distance2 = Math.Abs(P2guess - Views);
            double percentage1;
            double percentage2;
            if (distance1 > Views)
            {
                percentage1 = ((double)Views / (double)distance1);
            }
            else
            {
                percentage1 = ((double)distance1 / (double)Views);
            }
            if (distance2 > Views)
            {
                percentage2 = ((double)Views / (double)distance2);
            }
            else
            {
                percentage2 = ((double)distance2 / (double)Views);
            }


            int[] pts = new int[2];

            pts[0] = (int)(( percentage1) * 100);
            pts[1]= (int)((percentage2) * 100);

            return pts;
        }
        private void NAButton_Click(object sender, RoutedEventArgs e)
        {
            Init();
        }


    }
}
