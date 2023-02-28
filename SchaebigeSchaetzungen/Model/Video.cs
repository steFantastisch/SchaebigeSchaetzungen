using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SchaebigeSchaetzungen.Model
{
    public class Video
    {
        private static Random random = new Random();
        private string videoID;

        public string VideoID
        {
            get { return videoID; }
            set { videoID = value; }
        }

        private string language;

        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        private string dispstr;

        public string Dispstr
        {
            get { return dispstr; }
            set { dispstr = value; }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private int comments;

        public int Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        private int likes;

        public int Likes
        {
            get { return likes; }
            set { likes = value; }
        }

        private int views;

        public int Views
        {
            get { return views; }
            set { views = value; }
        }

        private bool available;

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        private bool german;

        public bool German
        {
            get { return german; }
            set { german = value; }
        }

        private bool timecode;

        public bool Timecode
        {
            get { return timecode; }
            set { timecode = value; }
        }

        private Player creator;

        public Player Creator
        {
            get { return creator; }
            set { creator = value; }
        }


        /// <summary>
        /// Constructor for Multiplayer
        /// Views and Link is known from the beginning
        /// Multiplicator are getting setted during the game
        /// </summary>
        public Video()
        {
            this.videoID = randomVidID();
            this.dispstr= Display(videoID);
            //Getdetails klappt hier nicht rein wegen awaiten

        }

        private Regex YouTubeURLIDRegex = new Regex(@"[?&]v=(?<v>[^&]+)");
        private string Display(string url)
        {
            Match m = YouTubeURLIDRegex.Match("https://www.youtube.com/watch?v="+url);
            String id = m.Groups["v"].Value;
            string url1 = "http://www.youtube.com/embed/" + id;
            string page =
                 "<html>"
                +"<head><meta http-equiv='X-UA-Compatible' content='IE=11' />"
                + "<body>" + "\r\n"
                + "<iframe src=\"" + url1 +  "?autoplay=1&loop=1 \" width=\"770px\" height=\"350px\" frameborder=\"0\" allowfullscreen></iframe>"
                + "</body></html>";
            return page;

        }
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private static string randomVidID()
        {
            var count = 1;
            string vidID = "";
            var API_KEY = "AIzaSyBJhxwz9nrTvCC0tZCJc-QmIZxpv7f6L0M";
            var q = RandomString(3);
            var url = "https://www.googleapis.com/youtube/v3/search?key=" + API_KEY + "&maxResults="+count+"&part=snippet&type=video&q=" +q;

            HttpClient client = new HttpClient();

            using (HttpResponseMessage response = client.GetAsync(url).Result)
            {
                using (HttpContent content = response.Content)
                {
                    var json = content.ReadAsStringAsync().Result;
                    dynamic jsonObject = JsonConvert.DeserializeObject(json);
                    int i = -1;
                    foreach (var line in jsonObject["items"])
                    {
                        i++;
                        vidID=(string)(line["id"]["videoId"]);
                    }
                    return vidID;
                }
            }


           
        }
        /// <summary>
        /// Get Details from the Video like LIKES, VIEWS, COMMENTS, and LANGUAGE 
        /// </summary>
        /// <param name="id"> Video ID</param>
        /// <returns></returns>
        public async Task GetDetailsAsync(string id)
        {
            string apiUrl = "https://youtube.googleapis.com/youtube/v3/videos?id="+ id +"&part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyBJhxwz9nrTvCC0tZCJc-QmIZxpv7f6L0M";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    //JSON-Dokument aus GET auslesen
                    string json = await response.Content.ReadAsStringAsync();

                    // JSON-Dokument in einen Stream schreiben
                    byte[] byteArray = Encoding.UTF8.GetBytes(json);
                    using (MemoryStream stream = new MemoryStream(byteArray))
                    {
                        // Serialisierer und Klasse für das Deserialisieren vorbereiten
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RootObject));
                        RootObject rootObject = (RootObject)serializer.ReadObject(stream);

                        //Daten auslesen
                        this.views = rootObject.items[0].statistics.viewCount;
                        this.comments = rootObject.items[0].statistics.commentCount;
                        this.likes = rootObject.items[0].statistics.likeCount;
                        this.language = rootObject.items[0].snippet.defaultAudioLanguage;
                        if (this.language=="de") { this.german=true; }
                    }
                }
                else
                {
                    //TODO Handle HTTP ERROR
                    // Console.WriteLine("Fehler beim Abrufen der API-Antwort: " + response.StatusCode);
                }
                return;
            }
        }
    }
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
}
