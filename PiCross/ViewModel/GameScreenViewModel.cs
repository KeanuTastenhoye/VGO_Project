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
        public ICommand Reset { get; private set; }

        //Basis puzzel voor als er geen puzzel is meegegeven
        public GameScreenViewModel(MainViewModel mainWindowViewModel) : this(mainWindowViewModel, Puzzle.FromRowStrings(

                    "xx...",
                    ".x...",
                    "..x..",
                    "..x..",
                    "...xx"
             ))
        { }

        //Initialisatie & dooverwijzing naar het maken van een puzzel
        public GameScreenViewModel(MainViewModel m, Puzzle p)
        {
            this.mvm = m;
            this.puzzle = p;
            this.Quit = new QuitCommand(this.mvm);
            this.Home = new HomeCommand(this.mvm);
            this.Reset = new ResetCommand(this);
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
            var facade = new PiCrossFacade();
            GoedePuzzel = facade.CreatePlayablePuzzle(puzzle);
            GoedePuzzel.IsSolved.ValueChanged += IsSolved_Verandering;

            this.grid.Value = this.GoedePuzzel.Grid.Map(square => new SquareViewModel(square)).Copy();
            IsSolved_Verandering();
        }

        //Steekt bool waarde in 'GoedePuzzel', deze waarde wordt opgevraagt in de View
        private void IsSolved_Verandering()
        {
            this.IsSolved.Value = GoedePuzzel.IsSolved.Value;
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
