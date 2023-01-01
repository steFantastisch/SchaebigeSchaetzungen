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
        public string kind { get; set; }
        public string etag { get; set; }
        public string id { get; set; }
        public Snippet snippet { get; set; }
        public Statistics statistics { get; set; }
    }

    public class RootObject
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public List<Item> items { get; set; }
    }

    public class Snippet
    {
        public string publishedAt { get; set; }
        public string channelId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Thumbnails thumbnails { get; set; }
        public string defaultLanguage { get; set; }
    }

    public class Statistics
    {
        public int viewCount { get; set; }
        public int likeCount { get; set; }
        public int commentCount { get; set; }

    }

    public class Thumbnails
    {
        public Default @default { get; set; }
        public Medium medium { get; set; }
        public High high { get; set; }
    }

    public class Default
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Medium
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class High
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
    /// <summary>
    /// Interaction logic for SingleplayerGameView.xaml
    /// </summary>
    /// 
    public partial class SingleplayerGameView : UserControl
    {
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
                + "<iframe src=\"" + url1 +  "\" width=\"100%\" height=\"100%\" frameborder=\"0\" allowfullscreen></iframe>"
                + "</body></html>";
            webBrowser1.NavigateToString(page);

        }
        private async Task GetDetailsAsync(string id)
        {
            //TODO DELETE FOLLOWING LINE id muss aus link extrahiert werden
            id= "dQw4w9WgXcQ";
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
                int viewCount = rootObject.items[0].statistics.viewCount;
                int commentCount = rootObject.items[0].statistics.commentCount;
                int likeCount = rootObject.items[0].statistics.likeCount;
                string lang = rootObject.items[0].snippet.defaultLanguage;

                Console.WriteLine("ALles gut: " + response.StatusCode);
                // Hier können Sie das JSON-String verarbeiten
            }
            else
            {
                Console.WriteLine("Fehler beim Abrufen der API-Antwort: " + response.StatusCode);
            }



        }
    }







}
