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
        public MainViewModel mainViewModel { get; }
        public ICommand Start { get; }
        public ICommand GoToLevelSelect { get; }
        public ICommand Quit { get; }
        public HomeScreenViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.Start = new StartCommand(this.mainViewModel);
            this.GoToLevelSelect = new GoToLevelSelectCommand(this.mainViewModel);
            this.Quit = new QuitCommand(this.mainViewModel);
        }
    }
}