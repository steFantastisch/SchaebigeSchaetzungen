using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Documents;

namespace SchaebigeSchaetzungen.Model
{
    public class Video
    {
        private static Random random = new Random();


        private int videoID;

        public int VideoID
        {
            get { return videoID; }
            set { videoID = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
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

        private bool timmecode;

        public bool Timecode
        {
            get { return timmecode; }
            set { timmecode = value; }
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
            this.url = Video.RandomVideo();
            this.views = Video.GetCurrentViewsWithWebscraper(this.url);
        }

        public Video(int videoID)
        {
            this.videoID = videoID;
        }


        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GenerateRandomVideo()
        {
            var count = 1;
            var API_KEY = "AIzaSyBJhxwz9nrTvCC0tZCJc-QmIZxpv7f6L0M";
            var q = RandomString(3);
            var url = "https://www.googleapis.com/youtube/v3/search?key=" + API_KEY + "&maxResults=" + count + "&part=snippet&type=video&q=" + q;

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                dynamic jsonObject = JsonConvert.DeserializeObject(json);
                string link = "";

                foreach (var line in jsonObject["items"])
                {
                    /*store id*/
                    link = line["id"]["videoId"].ToString();
                }
                return "https://www.youtube.com/watch?v=" + link;
            }
        }


        /// <summary>
        /// Get the current views with a web scrapper
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static int GetCurrentViewsWithWebscraper(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            string innerHtml = doc.DocumentNode.InnerHtml;

            string start = "\"viewCount\":\"";
            int indexStart = innerHtml.IndexOf(start) + start.Length;
            int indexEnd = innerHtml.IndexOf("\",\"author\":\"");

            return Convert.ToInt32(innerHtml.Substring(indexStart, indexEnd - indexStart));
        }

        private static int GetCurrentViewsWithApi(string url)
        {
            string url = "https://youtube.googleapis.com/youtube/v3/videos?id=dQw4w9WgXcQ&part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyBJhxwz9nrTvCC0tZCJc-QmIZxpv7f6L0M";
            int views;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                var data = (JObject)JsonConvert.DeserializeObject(json);
                views = Convert.ToInt32(data.SelectToken("items.[0].statistics.viewCount").Value<string>());

            }
            return views;
        }

        public static List<Video> GeneratePlaylist(Game game)
        {
            //TODO implement
            List<Video> playlist = new List<Video>();

            if (game.Gamemode == Gamemode.Singleplayer)
            {
                //load 10 random videos from the database which playerTwo already guessed
                //playerOne will play against the old guessings from playerTwo
            }

            else
            {
                for (int i = 0; i < 10; i++)
                {
                    //Add random videos and save them in the database
                }

            }

            return playlist;
        }
    }
}
