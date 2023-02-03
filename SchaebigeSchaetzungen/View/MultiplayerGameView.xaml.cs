using SchaebigeSchaetzungen.Helpers;
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
            VideoIDs= YoutubeRandom.randomVidIDs();

            VideoInfo Video = new VideoInfo();
            await Video.GetDetailsAsync(VideoIDs[round]);
            viewCount=Video.viewCount;
            likeCount=Video.likeCount;
            commentCount=Video.commentCount;
            language=Video.language;

            YoutubeTab Helper = new YoutubeTab();
            webBrowser1.NavigateToString(Helper.Display(VideoIDs[round]));
        }

        private void P1Submit_Click(object sender, RoutedEventArgs e)
        {
            if (P1Submit.Content.ToString() == "Submit")
            {
                if (!Int32.TryParse(TextBox1.Text, out PlayerOneguess))
                {
                    //TODO
                    //Fehlermessage wegen falscheingabe
                    return;
                }

                //TODO change to 3
                if (round > 1) // Maximum 5 Runden
                {
                    SubmitBtn.Content="Result";
                    SubmitBtn.Visibility= Visibility.Collapsed;
                    ResultBtn.Visibility= Visibility.Visible;
                }
                else
                {
                    SubmitBtn.Content="Next Round";
                }
                SubmitBtn.Content="Next Round";
                TextBox1.Visibility= Visibility.Collapsed;
                GuessLabel.Visibility= Visibility.Collapsed;
                HintCheckBox.Visibility= Visibility.Collapsed;
                HintLikes.Visibility = Visibility.Collapsed;
                HintComments.Visibility = Visibility.Collapsed;

                CalcPoints Rechner = new CalcPoints();
                ViewLabel.Content= Rechner.SingleplayerPts(guess, viewCount);

                HintLabel.Content= " Du lagst " +Math.Abs(viewCount - guess)+ " von der richtigen Lösung weg!";

                ViewLabel.Visibility = Visibility.Visible;
                LanguageLabel.Content="Language: "+language;
                LanguageLabel.Visibility = Visibility.Visible;
                return;

            }

            else if (SubmitBtn.Content.ToString() == "Next Round")
            {
                Init();
                TextBox1.Visibility= Visibility.Visible;
                GuessLabel.Visibility= Visibility.Visible;
                HintCheckBox.Visibility= Visibility.Visible;
                if (HintCheckBox.IsEnabled)
                {
                    HintLikes.Content = "Likes: " + likeCount.ToString();
                    HintLikes.Visibility = Visibility.Visible;
                    HintComments.Content = "Comments: "+ commentCount.ToString();
                    HintComments.Visibility = Visibility.Visible;
                }

                HintLabel.Content= "Hints";
                ViewLabel.Visibility = Visibility.Collapsed;
                LanguageLabel.Visibility = Visibility.Collapsed;
                SubmitBtn.Content="Submit";
                TextBox1.Text="";
                round++;

            }
        }

        private void P2Submit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
