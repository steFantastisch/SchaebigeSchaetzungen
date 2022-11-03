using Microsoft.Win32;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing.Imaging;
using System.Linq;

namespace SchaebigeSchaetzungen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<Player> temp = DBPlayer.ReadAll();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                //Only png?
                Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg"
            };

            bool ? response = openFileDialog.ShowDialog();

            if(response == true)
            {
                string filepath = openFileDialog.FileName;
                string[] localPath = openFileDialog.FileName.Replace(".", "\\").Split("\\");


                MessageBox.Show(localPath[localPath.Count() - 1] + "\n" + localPath[localPath.Count() - 2]); ;

                //StreamReader sr = new StreamReader(filepath);
                //Stream sm = sr.BaseStream;
                //BinaryReader br = new BinaryReader(sm);
                //byte[] bytes = br.ReadBytes((Int32)sm.Length);
                //Image img = System.Drawing.Image.FromStream(new MemoryStream(bytes));


                //Bitmap bitmap = new Bitmap(img);
                //ImageSource imageSource = CreateBitmapSourceFromGdiBitmap(bitmap);
                //testimage.Source = imageSource;

                //MySqlConnection temp = DBAccess.OpenDB();
                //string sql = $"Insert into Image (ImageName, ImageType, ImagePath) Values (@name, @type, @path)";
                //MySqlCommand cmd = new MySqlCommand(sql, temp);
                //cmd.Parameters.AddWithValue("@name", "test");
                //cmd.Parameters.AddWithValue("@type", "test");
                //cmd.Parameters.AddWithValue("@path", bytes);
                //cmd.ExecuteNonQuery();
                //DBAccess.CloseDB(temp);
            }
        }

        
    }
}
