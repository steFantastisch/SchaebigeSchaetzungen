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
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net;
using Amazon.DynamoDBv2.Model.Internal.MarshallTransformations;
using SchaebigeSchaetzungen.Helpers;

namespace SchaebigeSchaetzungen.View
{

    /// <summary>
    /// Interaction logic for SingleplayerGameView.xaml
    /// </summary>
    /// 
    public partial class SingleplayerGameView : UserControl
    {
        int viewCount;
        int commentCount;
        int likeCount;
        string language;
        int round;
        string[] VideoIDs;
        int guess;

        public SingleplayerGameView()
        {
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
            webBrowser1.NavigateToString(Helper.Display("https://www.youtube.com/watch?v="+VideoIDs[round]));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SubmitBtn.Content.ToString() == "Submit")
            {
                if (!Int32.TryParse(TextBox1.Text, out guess))
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
                //TODO Punkte verarbeiten
                ViewLabel.Content= ">>>Views: " + viewCount.ToString() + "<<<    ->?? Punkte";
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
    }

}

