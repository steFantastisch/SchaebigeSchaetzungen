using Google.Protobuf.WellKnownTypes;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Stores
{
    public class NavigationStore
    {

        private ViewModelBase? _currentViewModel;


        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
            }
        }
    }
}
