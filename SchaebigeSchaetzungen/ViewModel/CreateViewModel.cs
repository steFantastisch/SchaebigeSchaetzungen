using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class CreateViewModel : ViewModelBase
    {

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string mail;

		public string Mail
		{
			get { return mail; }
			set { mail = value; }
		}

		private string password;

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

	}
}
