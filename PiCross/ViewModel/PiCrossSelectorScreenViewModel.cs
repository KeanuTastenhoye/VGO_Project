using PiCross;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class PiCrossSelectorScreenViewModel
    {
        public MainViewModel mvm { get; private set; }
        public ArrayList Puzzels { get; }
        public ICommand Quit { get; private set; }
        public ICommand Home { get; private set; }
        public ICommand Choose { get; private set; }

        public PiCrossSelectorScreenViewModel(MainViewModel m)
        {
            this.mvm = m;
            var data = this.mvm.PiCrossFacade.CreateDummyGameData();
            var list = data.PuzzleLibrary.Entries;
            this.Puzzels = new ArrayList();
            this.Quit = new QuitCommand(this.mvm);
            this.Home = new HomeCommand(this.mvm);
            this.Choose = new ChooseCommand(this.mvm);

            foreach (IPuzzleLibraryEntry entry in list)
            {
                if (this.Puzzels.Count != 3)
                {
                    this.Puzzels.Add(entry.Puzzle);
                } else
                {
                    break;
                }
            }
        }
    }
}
