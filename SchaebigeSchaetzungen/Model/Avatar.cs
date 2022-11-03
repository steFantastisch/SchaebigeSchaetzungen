using Microsoft.Win32;
using SchaebigeSchaetzungen.Converter;
using SchaebigeSchaetzungen.Persistence;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SchaebigeSchaetzungen.Model
{
    public class Avatar
    {
		private int imageID;

		public int ImageID
		{
			get { return imageID; }
			set { imageID = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string type;

		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		private Bitmap path;

		public Bitmap Path
		{
			get { return path; }
			set { path = value; }
		}

		public Avatar(OpenFileDialog dialog)
		{
			StreamReader sr = new StreamReader(dialog.FileName);
			Stream sm = sr.BaseStream;
			BinaryReader br = new BinaryReader(sm);
            byte[] bytes = br.ReadBytes((Int32)sm.Length);
            Image img = System.Drawing.Image.FromStream(new MemoryStream(bytes));
            this.path = new Bitmap(img);

			string[] localPath = dialog.FileName.Replace(".", "\\").Split("\\");

			this.type = localPath[localPath.Count() - 1];
			this.name = localPath[localPath.Count() - 2];

			DBAvatar.Insert(this);
        }

		public Avatar()
		{ }


		public ImageSource imageSource()
		{
			return BitmapToBitmapSourceConverter.BitmapToBitmapSource(this.path);

        }

	}
}
