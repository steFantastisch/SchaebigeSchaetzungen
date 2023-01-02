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
    /// necessary for randomizing youtube videos
    /// </summary>
    public class Youtube
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string[] randomVidIDs()
        {
            var count = 50;
            string[] vidIDs = new string[count];
            var API_KEY = "AIzaSyBJhxwz9nrTvCC0tZCJc-QmIZxpv7f6L0M";
            var q = RandomString(3);
            var url = "https://www.googleapis.com/youtube/v3/search?key=" + API_KEY + "&maxResults="+count+"&part=snippet&type=video&q=" +q;

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                dynamic jsonObject = JsonConvert.DeserializeObject(json);
                int i = -1;
                foreach (var line in jsonObject["items"])
                {
                    i++;
                    vidIDs[i]=(string)(line["id"]["videoId"]);

                }
                return vidIDs;
            }
        }
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
        string[] VideoIDs;
        int guess;

        public SingleplayerGameView()
        {
            round=0;
            InitializeComponent();

            //TODO id übergeben
            VideoIDs= Youtube.randomVidIDs();
            Display("https://www.youtube.com/watch?v="+VideoIDs[round]);
            GetDetailsAsync(VideoIDs[round]);
        }
        //brauchen wir evt 
        private Regex YouTubeURLIDRegex = new Regex(@"[?&]v=(?<v>[^&]+)");
        public void Display(string url)
        {
            Match m = YouTubeURLIDRegex.Match(url);
            String id = m.Groups["v"].Value;
            string url1 = "http://www.youtube.com/embed/" + id;
            string page =
                 "<html>"
                +"<head><meta http-equiv='X-UA-Compatible' content='IE=11' />"
                + "<body>" + "\r\n"
                + "<iframe src=\"" + url1 +  " \" width=\"770px\" height=\"350px\" frameborder=\"0\" allowfullscreen></iframe>"
                + "</body></html>";
            webBrowser1.NavigateToString(page);

        }
        /// <summary>
        /// Get Details from the Video like LIKES, VIEWS, COMMENTS, and LANGUAGE 
        /// </summary>
        /// <param name="id"> Video ID</param>
        /// <returns></returns>
        private async Task GetDetailsAsync(string id)
        {

            string apiUrl = "https://youtube.googleapis.com/youtube/v3/videos?id="+ id +"&part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyBJhxwz9nrTvCC0tZCJc-QmIZxpv7f6L0M";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                //JSON-Dokument aus GET auslesen
                string json = await response.Content.ReadAsStringAsync();

                // JSON-Dokument in einen Stream schreiben
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                MemoryStream stream = new MemoryStream(byteArray);

                // Serialisierer und Klasse für das Deserialisieren vorbereiten
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RootObject));
                RootObject rootObject = (RootObject)serializer.ReadObject(stream);

                //Daten auslesen
                viewCount = rootObject.items[0].statistics.viewCount;
                commentCount = rootObject.items[0].statistics.commentCount;
                likeCount = rootObject.items[0].statistics.likeCount;
                language = rootObject.items[0].snippet.defaultAudioLanguage;


               stream.Close(); 
                client.Dispose();   
            }
            else
            {
                //TODO Handle HTTP ERROR
                Console.WriteLine("Fehler beim Abrufen der API-Antwort: " + response.StatusCode);
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SubmitBtn.Content.ToString() == "Submit")
            {
                if (Int32.TryParse(TextBox1.Text, out guess))
                {
                    SubmitBtn.Content="Next Round";
                    TextBox1.Visibility= Visibility.Collapsed;
                    GuessLabel.Visibility= Visibility.Collapsed;
                    HintCheckBox.Visibility= Visibility.Collapsed;
                    HintLikes.Visibility = Visibility.Collapsed;
                    HintComments.Visibility = Visibility.Collapsed;

                    ViewLabel.Content= ">>>Views: " + viewCount.ToString() + "<<<    ->?? Punkte";
                    HintLabel.Content= " Du lagst " +Math.Abs(viewCount - guess)+ " von der richtigen Lösung weg!";
                    //TODO Punkte verarbeiten
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
                HintLabel.Content= "Hints";
                ViewLabel.Visibility = Visibility.Collapsed;
                LanguageLabel.Visibility = Visibility.Collapsed;
                SubmitBtn.Content="Submit";
                TextBox1.Text="";
                round++;
                Display("https://www.youtube.com/watch?v="+VideoIDs[round]);
                GetDetailsAsync(VideoIDs[round]);
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

