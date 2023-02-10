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
            //TODO Spielername über game bekommen
            round=0;
            InitializeComponent();
            Init();
        }

        public async void Init()
        {
            //consider taking the next line into the constructor due to potential performance loss
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
            if (HintCheckBox.IsChecked==true)
            {
                HintLikes.Content = "Likes: " + likeCount.ToString();
                HintLikes.Visibility = Visibility.Visible;
                HintComments.Content = "Comments: "+ commentCount.ToString();
                HintComments.Visibility = Visibility.Visible;
            }

            HintLabel.Content= "Hints";
            ViewLabel.Visibility = Visibility.Collapsed;
            LanguageLabel.Visibility = Visibility.Collapsed;
            NextRound.Visibility = Visibility.Collapsed;
            TextBox1.Text="";
            TextBox2.Text="";
            
        }

        private void P1Submit_Click(object sender, RoutedEventArgs e)
        {

            if (!Int32.TryParse(TextBox1.Text, out PlayerOneguess))
            {
                //TODO
                //Fehlermessage wegen falscheingabe
                return;
            }
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
                //TODO
                //Fehlermessage wegen falscheingabe
                return;
            }
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
            HintCheckBox.Visibility= Visibility.Collapsed;
            HintLikes.Visibility = Visibility.Collapsed;
            HintComments.Visibility = Visibility.Collapsed;
            HintLabel.Content= " Du lagst " +Math.Abs(viewCount - PlayerOneguess)+ " von der richtigen Lösung weg!\nDu lagst" +Math.Abs(viewCount - PlayerTwoguess)+ " von der richtigen Lösung weg!";
            LanguageLabel.Content="Language: "+language;
            LanguageLabel.Visibility = Visibility.Visible;
            //CalcPointsCommand Rechner = new CalcPointsCommand();
           // ViewLabel.Content= Rechner.MultiplayerPtns(PlayerOneguess, PlayerTwoguess, viewCount);
            ViewLabel.Visibility = Visibility.Visible;

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
    }
}
