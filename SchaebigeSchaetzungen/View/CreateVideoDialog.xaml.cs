using Amazon.Auth.AccessControlPolicy;
using HtmlAgilityPack;
using Newtonsoft.Json;
using SchaebigeSchaetzungen.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace SchaebigeSchaetzungen.View
{
    /// <summary>
    /// Interaktionslogik für CreateVideoDialog.xaml
    /// </summary>
    public partial class CreateVideoDialog : Window
    {
        public CreateVideoDialog()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Video temp = new Video();
            MessageBox.Show($"URL: {temp.Url}\nViews: {temp.Views}");
        }

    }
}
