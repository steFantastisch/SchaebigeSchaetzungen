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

		private int tip;

		public int Tip
		{
			get { return tip; }
			set { tip = value; }
		}

		private int difference;

		public int Difference
		{
			get { return difference; }
			set { difference = value; }
		}


	}
}
