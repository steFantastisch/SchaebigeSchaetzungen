using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Helpers
{
    /// <summary>
    /// necessary for randomizing the displayed youtube videos
    /// </summary>
    public class YoutubeRandom
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

}
