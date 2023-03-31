using SchaebigeSchaetzungen.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

           Video video = new Video();
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

            int[] pts = Game.CalculateMultiplayerPoints(PlayerOneguess, PlayerTwoguess, viewCount);
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
                webBrowser1.NavigateToString("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n  <meta charset=\"UTF-8\">\r\n  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n  <title>Spiel vorbei</title>\r\n  <style>\r\n    * {\r\n      margin: 0;\r\n      padding: 0;\r\n      box-sizing: border-box;\r\n    }\r\n\r\n    html, body {\r\n      height: 100%;\r\n      font-family: Arial, sans-serif;\r\n    }\r\n\r\n    body {\r\n      display: flex;\r\n      justify-content: center;\r\n      align-items: center;\r\n    }\r\n\r\n    .container {\r\n      text-align: center;\r\n    }\r\n  </style>\r\n</head>\r\n<body>\r\n  <div class=\"container\">\r\n    <h1>Spiel vorbei</h1>\r\n    <p>Vielen Dank fürs Spielen!</p>\r\n  </div>\r\n</body>\r\n</html>\r\n");
            }
            else
            {
                NextRound.Visibility= Visibility.Visible;
            }
        }

        
        private void NAButton_Click(object sender, RoutedEventArgs e)
        {
            Init();
        }


    }
}
