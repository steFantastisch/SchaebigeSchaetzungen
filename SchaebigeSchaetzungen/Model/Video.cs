using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Model
{
    public class Video
    {
		private int videoID;

		public int VideoID
		{
			get { return videoID; }
			set { videoID = value; }
		}

		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		private string url;

		public string Url
		{
			get { return url; }
			set { url = value; }
		}

		private int views;

		public int Views
		{
			get { return views; }
			set { views = value; }
		}

		private bool available;

		public bool Available
		{
			get { return available; }
			set { available = value; }
		}

		private bool german;

		public bool German
		{
			get { return german; }
			set { german = value; }
		}

		private bool timmecode;

		public bool Timecode
		{
			get { return timmecode; }
			set { timmecode = value; }
		}

		private Player creator;

		public Player Creator
		{
			get { return creator; }
			set { creator = value; }
		}


		public Video() 
		{

		}

		public Video(int videoID)
		{
			this.videoID = videoID;
		}


	}
}
