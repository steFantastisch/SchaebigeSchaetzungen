using SchaebigeSchaetzungen.Command;
using SchaebigeSchaetzungen.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public ICommand FinishCommand { get; }
        public ICommand CancelCommand { get; }

		public CreateViewModel(NavigationStore navigationStore, Func<LoginPlayerOneViewModel> createUserCredentialViewModel)
		{
            this.CancelCommand = new NavigateCommand(navigationStore, createUserCredentialViewModel);
        }
    }
}
