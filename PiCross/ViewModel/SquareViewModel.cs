using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class SquareViewModel
    {
        public IPlayablePuzzleSquare Square { get; }
        public ICommand State { get; }
        public Cell<Square> Contents
        {
            get
            {
                return Square.Contents;
            }
        }
        public SquareViewModel(IPlayablePuzzleSquare square)
        {
            this.Square = square;
            //Empty, filled of unknown
            this.State = new SquareStateCommand(this);
        }
    }
}
