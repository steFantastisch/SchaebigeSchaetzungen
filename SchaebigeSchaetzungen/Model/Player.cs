using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SchaebigeSchaetzungen.Model
{

    public class Player
    {
		private int playerID;

		public int PlayerID
		{
			get { return playerID; }
			set { playerID = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string password;

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		private string mail;

		public string Mail
		{
			get { return mail; }
			set { mail = value; }
		}

		private int crowns;

		public int Crowns
		{
			get { return crowns; }
			set { crowns = value; }
		}


		private Avatar image;

		public Avatar Image
		{
			get { return image; }
			set { image = value; }
		}



	}
}
