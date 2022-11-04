using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Commands
{
    public class CreatePlayerCommand : CommandBase
    {
        private readonly RegistrationVM _registrationVM;

        public CreatePlayerCommand(RegistrationVM registrationVM)
        {
            _registrationVM=registrationVM;
        }

        

        public override void Execute(object? parameter)
        {
            Player Spieler = new Player(_registrationVM.Username, _registrationVM.Password, _registrationVM.Email);
            
        }
    }
}
