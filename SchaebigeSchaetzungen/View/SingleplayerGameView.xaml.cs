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
    public class Item
    {
        public Snippet snippet { get; set; }
        public Statistics statistics { get; set; }
    }

    public class RootObject
    {
        public List<Item> items { get; set; }
    }

    public class Snippet
    {
        public string publishedAt { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string defaultAudioLanguage { get; set; }
    }

    public class Statistics
    {
        public int viewCount { get; set; }
        public int likeCount { get; set; }
        public int commentCount { get; set; }

    }

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
        private HTTPHelper Helper;
        string[] VideoIDs;
        int guess;

        public SingleplayerGameView()
        {
            round=0;
            InitializeComponent();
            Init();

        }

        public void Init()
        {
            VideoInfo Video = new VideoInfo();
            Video.GetDetailsAsync(VideoIDs[round]);
            Video.viewCount=viewCount; 
            Video.likeCount=likeCount;
            Video.commentCount=commentCount;
            Video.language=language;

            //consider taking the next line into the constructor due to potential performance loss
            VideoIDs= Youtube.randomVidIDs();
            HTTPHelper Helper = new HTTPHelper();
            webBrowser1.NavigateToString(Helper.Display("https://www.youtube.com/watch?v="+VideoIDs[round]));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SubmitBtn.Content.ToString() == "Submit")
            {
                if (Int32.TryParse(TextBox1.Text, out guess))
                {
                    //TODO change to 4
                    if (round > 2) // Maximum 5 Runden
                    {

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
                }
                else
                {
                    //TODO
                    //Fehlermessage wegen falscheingabe
                    return;
                }

            }

            else
            {
                TextBox1.Visibility= Visibility.Visible;
                GuessLabel.Visibility= Visibility.Visible;
                HintCheckBox.Visibility= Visibility.Visible;
                if (HintCheckBox.IsEnabled)
                {
                    HintLikes.Visibility= Visibility.Visible;
                    HintComments.Visibility= Visibility.Visible;
                }
                HintLabel.Content= "Hints";
                ViewLabel.Visibility = Visibility.Collapsed;
                LanguageLabel.Visibility = Visibility.Collapsed;
                SubmitBtn.Content="Submit";
                TextBox1.Text="";
                round++;
                Init();
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

