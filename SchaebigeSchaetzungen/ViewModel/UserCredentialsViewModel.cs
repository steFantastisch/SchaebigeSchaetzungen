﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class UserCredentialsViewModel : ViewModelBase
    {
        private string username;
        private string password;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommant { get; }
        public ICommand CreateCommant { get; }
        public ICommand HelpCommant { get; }

        public UserCredentialsViewModel()
        {
            //TODO DELETE FOLLOWING LINE
            this.Username = "Stefan";
        }
    }
}