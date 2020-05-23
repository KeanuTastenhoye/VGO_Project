using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class GameScreenViewModel
    {
        //Declaraties van de nodige zaken
        public MainViewModel mvm { get; private set; }
        public Puzzle puzzle;
        //public PiCrossFacade fac { get; }
        public Cell<IGrid<SquareViewModel>> grid { get; private set; }
        public Cell<bool> IsSolved { get; set; }
        public IPlayablePuzzle GoedePuzzel { get; private set; }
        public ICommand Home { get; private set; }
        public ICommand Quit { get; private set; }

        //Basis puzzel voor als er geen puzzel is meegegeven
        public GameScreenViewModel(MainViewModel mainWindowViewModel) : this(mainWindowViewModel, Puzzle.FromRowStrings(
                    "xx...",
                    ".x...",
                    "..x..",
                    "..x..",
                    "...xx"
             ))
        { }

        private void IsSolved_ValueChanged()
        {
            this.IsSolved.Value = GoedePuzzel.IsSolved.Value;
        }

        //Initialisatie & dooverwijzing naar het maken van een puzzel
        public GameScreenViewModel(MainViewModel m, Puzzle p)
        {
            this.mvm = m;
            this.puzzle = p;
            this.Quit = new QuitCommand(this.mvm);
            this.Home = new HomeCommand(this.mvm);
            //this.f = new PiCrossFacade();
            this.grid = Cell.Create<IGrid<SquareViewModel>>(null);
            this.IsSolved = Cell.Create(false);
            //this.GoedePuzzel = f.CreatePlayablePuzzle(p);
            //this.PuzzelMaken(m, GoedePuzzel);
            PuzzelMaken();
        }

        //Puzzel genereren via de sub klassse in PiCrossFacade
        public void PuzzelMaken()
        {
            var f = new PiCrossFacade();
            GoedePuzzel = f.CreatePlayablePuzzle(puzzle);
            GoedePuzzel.IsSolved.ValueChanged += IsSolved_ValueChanged;

            this.grid.Value = this.GoedePuzzel.Grid.Map(square => new SquareViewModel(square)).Copy();
            IsSolved_ValueChanged();
        }

        /*
        public void PuzzelMaken(MainViewModel m, IPlayablePuzzle GoedePuzzel)
        {
            this.mvm = m;
            this.GoedePuzzel = GoedePuzzel;
            this.grid.Value = this.GoedePuzzel.Grid.Map(square => new SquareViewModel(square)).Copy();
        }
        */

        /*
        public Cell<bool> isSolved
        {
            get
            {
                return GoedePuzzel.IsSolved;
            }
        }
        */
    }
}
