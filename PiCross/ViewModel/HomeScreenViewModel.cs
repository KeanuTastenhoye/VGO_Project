using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class HomeScreenViewModel
    {
        public MainViewModel mvm { get; }
        public ICommand Start { get; }
        public ICommand GoToLevelSelect { get; }
        public ICommand Quit { get; }
        public HomeScreenViewModel(MainViewModel mainViewModel)
        {
            this.mvm = mainViewModel;
            //Nodige commands op HomeScreen
            this.Start = new StartCommand(this.mvm);
            this.GoToLevelSelect = new GoToLevelSelectCommand(this.mvm);
            this.Quit = new QuitCommand(this.mvm);
        }
    }
}