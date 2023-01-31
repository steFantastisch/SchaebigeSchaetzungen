using Newtonsoft.Json;
using SchaebigeSchaetzungen.View;
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
using System.Windows.Controls;

namespace SchaebigeSchaetzungen.Helpers
{
  

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

    

    public class HTTPHelper
    {
        private Regex YouTubeURLIDRegex = new Regex(@"[?&]v=(?<v>[^&]+)");
        public string Display(string url)
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
            return page;

        }

        
    }
}
