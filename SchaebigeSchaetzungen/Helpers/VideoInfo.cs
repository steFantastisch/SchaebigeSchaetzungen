using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Helpers
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


    public class VideoInfo
    {

        public int viewCount;
        public int commentCount;
        public int likeCount;
        public string language;

        /// <summary>
        /// Get Details from the Video like LIKES, VIEWS, COMMENTS, and LANGUAGE 
        /// </summary>
        /// <param name="id"> Video ID</param>
        /// <returns></returns>
        public async Task GetDetailsAsync(string id)
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
                this.viewCount = rootObject.items[0].statistics.viewCount;
                this.commentCount = rootObject.items[0].statistics.commentCount;
                this.likeCount = rootObject.items[0].statistics.likeCount;
                this.language = rootObject.items[0].snippet.defaultAudioLanguage;


                stream.Close();
                //vielleicht etwas returnen?
                /// client.Dispose();   
            }
            else
            {
                //TODO Handle HTTP ERROR
                // Console.WriteLine("Fehler beim Abrufen der API-Antwort: " + response.StatusCode);
            }
        }
    }
}
