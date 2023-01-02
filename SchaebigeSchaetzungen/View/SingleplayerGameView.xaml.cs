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

        public SingleplayerGameView()
        {
            InitializeComponent();
            Display("https://www.youtube.com/watch?v=iSfPNVf0_JM");
            //TODO id übergeben
            GetDetailsAsync("");
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
                + "<iframe src=\"" + url1 +  " \" width=\"770px\" ?showinfo=\"0\" height=\"350px\" frameborder=\"0\" allowfullscreen></iframe>"
                + "</body></html>";
            webBrowser1.NavigateToString(page);

        }
        private async Task GetDetailsAsync(string id)
        {
            //TODO DELETE FOLLOWING LINE id muss aus link extrahiert werden
            id= "Ep0uIWmXV_g";
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


                // Hier können Sie das JSON-String verarbeiten
            }
            else
            {
                Console.WriteLine("Fehler beim Abrufen der API-Antwort: " + response.StatusCode);
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Visibility= Visibility.Collapsed;
            GuessLabel.Visibility= Visibility.Collapsed;
            SubmitBtn.Visibility= Visibility.Collapsed; 
            HintCheckBox.Visibility= Visibility.Collapsed;
            HintLabel.Visibility= Visibility.Collapsed;

            LikeLabel.Content = "Likes: " + likeCount.ToString();
            LikeLabel.Visibility = Visibility.Visible;
            CommentLabel.Content = "Comments: "+ commentCount.ToString();
            CommentLabel.Visibility = Visibility.Visible;
            ViewLabel.Content= "Views: " + viewCount.ToString();
            ViewLabel.Visibility = Visibility.Visible;
            LanguageLabel.Content="Language: "+language;
            LanguageLabel.Visibility = Visibility.Visible;
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
