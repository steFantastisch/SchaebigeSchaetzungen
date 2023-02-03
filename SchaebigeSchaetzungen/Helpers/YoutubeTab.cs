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

    //Single responsibility principle
    public class YoutubeTab
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
