using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _selectedViewModel= new GameVM();
        public ViewModelBase SelectedViewModel { get { return _selectedViewModel; } set { _selectedViewModel =value; } }  

    }
}
