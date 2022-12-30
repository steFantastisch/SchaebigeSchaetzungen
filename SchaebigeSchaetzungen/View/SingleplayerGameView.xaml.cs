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

namespace SchaebigeSchaetzungen.View
{
    /// <summary>
    /// Interaction logic for SingleplayerGameView.xaml
    /// </summary>
    public partial class SingleplayerGameView : UserControl
    {
        public SingleplayerGameView()
        {
            InitializeComponent();
            Display("https://www.youtube.com/watch?v=iSfPNVf0_JM");
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
    }

    
    
}
