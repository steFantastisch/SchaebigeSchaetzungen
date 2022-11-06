using Amazon.DynamoDBv2.Model;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UserCredential = Google.Apis.Auth.OAuth2.UserCredential;

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


		public Video() 
		{
			this.url = Video.RandomVideo();
			this.views = Video.GetCurrentViews(this.url);
		}

		public Video(int videoID)
		{
			this.videoID = videoID;
		}


		void foo()
		{
			//string views = SearchY(richTextBoxSC, "watch-view-count", 19, "</");
		}

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string RandomVideo()
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
					/*store your id*/
					link = line["id"]["videoId"].ToString();
				}
				return "https://www.youtube.com/watch?v=" + link;
            }
        }

		private static int GetCurrentViews(string url)
		{
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            string innerHtml = doc.DocumentNode.InnerHtml;

            string start = "\"viewCount\":\"";
            int indexStart = innerHtml.IndexOf(start) + start.Length;
            int indexEnd = innerHtml.IndexOf("\",\"author\":\"");

            return Convert.ToInt32(innerHtml.Substring(indexStart, indexEnd - indexStart));
        }
    }
}
