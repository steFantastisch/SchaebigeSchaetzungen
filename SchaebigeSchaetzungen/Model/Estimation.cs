using MySqlX.XDevAPI.Relational;
using SchaebigeSchaetzungen.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Model
{
    public class Estimation
    {
		private int estimationID;

		public int EstimationID
		{
			get { return estimationID; }
			set { estimationID = value; }
		}

		private Player player;

		public Player Player
		{
			get { return player; }
			set { player = value; }
		}

		private Video video;

		public Video Video
		{
			get { return video; }
			set { video = value; }
		}

		private int difference;

		public int Difference
		{
			get { return difference; }
			set { difference = value; }
		}


		public Estimation()
		{ }

		public Estimation(Player player)
		{
			//TODO implement
			//Loaded from the db for the singleplayermode
		}

		public Estimation(Player player, Video video, int tip)
		{
			//Created during the game
			this.player = player;
			this.video= video;
			this.difference = tip - video.Views;

			Insert();
		}

		public void Insert()
		{
			DBEstimation.Insert(this);
		}

		public void Read()
		{
			DBEstimation.Read(this);
		}

		public static List<Estimation> ReadAll()
		{
			return DBEstimation.ReadAll();
		}
	}
}
