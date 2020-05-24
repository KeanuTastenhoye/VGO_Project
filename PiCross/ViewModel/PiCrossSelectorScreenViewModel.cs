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
        public ArrayList PuzzelsKlein { get; }
        public ArrayList PuzzelsGroot { get; }
        public bool isSmall { get; }
        public bool isBig { get; }
        public ICommand Quit { get; private set; }
        public ICommand Home { get; private set; }
        public ICommand Choose { get; private set; }
        public ICommand Big { get; private set; }
        public ICommand Small { get; private set; }

        public PiCrossSelectorScreenViewModel(MainViewModel m)
        {
            this.mvm = m;
            var data = this.mvm.PiCrossFacade.CreateDummyGameData();
            var lijst = data.PuzzleLibrary.Entries;
            this.PuzzelsKlein = new ArrayList();
            this.PuzzelsGroot = new ArrayList();
            this.isSmall = true;
            this.isBig = false;
            this.Quit = new QuitCommand(this.mvm);
            this.Home = new HomeCommand(this.mvm);
            this.Choose = new ChooseCommand(this.mvm);
            this.Big = new BigCommand(this.mvm);
            this.Small = new SmallCommand(this.mvm);

            foreach (IPuzzleLibraryEntry entry in lijst)
            {
                //Verdeel de puzzels onder 5x5 en 10x10, Max 2 per
                if (entry.Puzzle.Size.Height.Equals(5)) {
                    if (this.PuzzelsKlein.Count != 2)
                    {
                        this.PuzzelsKlein.Add(entry.Puzzle);
                    }
                } else
                {
                    if (this.PuzzelsGroot.Count != 2)
                    {
                        this.PuzzelsGroot.Add(entry.Puzzle);
                    }
                }
            }

            //Irritante puzzel wegdoen
            this.PuzzelsGroot.RemoveAt(0);
        }

        public PiCrossSelectorScreenViewModel(MainViewModel m, String keuze)
        {
            this.mvm = m;
            var data = this.mvm.PiCrossFacade.CreateDummyGameData();
            var lijst = data.PuzzleLibrary.Entries;
            this.PuzzelsKlein = new ArrayList();
            this.PuzzelsGroot = new ArrayList();
            this.Quit = new QuitCommand(this.mvm);
            this.Home = new HomeCommand(this.mvm);
            this.Choose = new ChooseCommand(this.mvm);
            this.Big = new BigCommand(this.mvm);
            this.Small = new SmallCommand(this.mvm);

            foreach (IPuzzleLibraryEntry entry in lijst)
            {
                //Verdeel de puzzels onder 5x5 en 10x10, Max 2 per
                if (entry.Puzzle.Size.Height.Equals(5))
                {
                    if (this.PuzzelsKlein.Count != 2)
                    {
                        this.PuzzelsKlein.Add(entry.Puzzle);
                    }
                }
                else
                {
                    if (this.PuzzelsGroot.Count != 2)
                    {
                        this.PuzzelsGroot.Add(entry.Puzzle);
                    }
                }
            }

            //Irritante puzzel wegdoen
            this.PuzzelsGroot.RemoveAt(0);

            //bool waarde geven aan variabelen
            if (keuze == "Big")
            {
                this.isBig = true;
                this.isSmall = false;
            } else
            {
                this.isBig = false;
                this.isSmall = true;
            }
        }
    }
}
