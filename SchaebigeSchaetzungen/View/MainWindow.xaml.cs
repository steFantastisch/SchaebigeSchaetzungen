using Microsoft.Win32;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Drawing;
using MySql.Data.MySqlClient;

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
                Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg"
            };

            bool ? response = openFileDialog.ShowDialog();

            if(response == true)
            {
                string filepath = openFileDialog.FileName;

                StreamReader sr = new StreamReader(filepath);
                Stream sm = sr.BaseStream;
                BinaryReader br = new BinaryReader(sm);
                byte[] bytes = br.ReadBytes((Int32)sm.Length);

                MySqlConnection temp = DBAccess.OpenDB();
                string sql = $"Insert into Image (ImageName, ImageType, ImagePath) Values (@name, @type, @path)";
                MySqlCommand cmd = new MySqlCommand(sql, temp);
                cmd.Parameters.AddWithValue("@name", "test");
                cmd.Parameters.AddWithValue("@type", "test");
                cmd.Parameters.AddWithValue("@path", bytes);
                cmd.ExecuteNonQuery();
                //DBAccess.ExecuteNonQuery(sql);

                DBAccess.CloseDB(temp);
                //var temp = System.Drawing.Image.FromStream(new MemoryStream(bytes));

                MessageBox.Show(bytes.ToString());
            }
        }
    }
}
