using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private object active;

        public Action Close { get; set; }
        public PiCrossFacade PiCrossFacade { get; }

        public MainViewModel()
        {
            this.Active = new HomeScreenViewModel(this);
            this.PiCrossFacade = new PiCrossFacade();
        }
        public object Active
        {
            get
            {
                return active;
            }

            private set
            {
                active = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Active)));
            }
        }

        //Go to home screen
        public void Home()
        {
            this.Active = new HomeScreenViewModel(this);
        }

        //Go to the selector screen
        public void GoToLevelSelect()
        {
            this.Active = new PiCrossSelectorScreenViewModel(this);
        }

        //Go to theme change screen
        public void GoToThemeChange()
        {
            //this.Active = new ThemeSelectorScreenViewModel(this);
        }

        //Stop
        public void Quit()
        {
            this.Close?.Invoke();
        }

        //Start a game
        public void Start()
        {
            this.Active = new GameScreenViewModel(this);
        }

        public void Start(Puzzle picross)
        {
            this.Active = new GameScreenViewModel(this, picross);
        }

        //Choose the level to play (go to selector page)
        public void Choose(Puzzle picross)
        {
            this.Active = new GameScreenViewModel(this, picross);
        }
    }
}
