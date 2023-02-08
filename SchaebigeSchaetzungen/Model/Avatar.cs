using Microsoft.Win32;
using Org.BouncyCastle.Utilities;
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
		private int avatarID;

		public int AvatarID
        {
			get { return avatarID; }
			set { avatarID = value; }
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

		private byte[] path;

		public byte[] Path
		{
			get { return path; }
			set { path = value; }
		}


        public Avatar(OpenFileDialog dialog)
		{
			StreamReader sr = new StreamReader(dialog.FileName);
			Stream sm = sr.BaseStream;
			BinaryReader br = new BinaryReader(sm);
            this.path = br.ReadBytes((Int32)sm.Length);

			string[] localPath = dialog.FileName.Replace(".", "\\").Split("\\");
			this.type = localPath[localPath.Count() - 1];
			this.name = localPath[localPath.Count() - 2];

			DBAvatar.Insert(this);
        }

		public Avatar(int AvatarID)
		{
			this.AvatarID = AvatarID;
			DBAvatar.Read(this);
		}


		/// <summary>
		/// Converts the byte-array to a image-source
		/// </summary>
		/// <returns></returns>
		public ImageSource imageSource()
		{
            Image img = System.Drawing.Image.FromStream(new MemoryStream(path));
            Bitmap bitmap = new Bitmap(img);
            return BitmapToBitmapSourceConverter.BitmapToBitmapSource(bitmap);
        }

	}
}
