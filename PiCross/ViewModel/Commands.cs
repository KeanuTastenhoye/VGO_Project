using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    //Nav commands
    public class HomeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel mv;
        private bool _execute;
        public HomeCommand(MainViewModel mainViewModel)
        {
            mv = mainViewModel;
            _execute = true;
        }
        public bool CanExecute(object param)
        {
            return _execute;
        }
        public void Execute(object param)
        {
            mv.Home();
        }
    }

    public class GoToLevelSelectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel mv;
        private bool _execute;
        public GoToLevelSelectCommand(MainViewModel mainViewModel)
        {
            mv = mainViewModel;
            _execute = true;
        }
        public bool CanExecute(object param)
        {
            return _execute;
        }
        public void Execute(object param)
        {
            mv.GoToLevelSelect();
        }
    }

    public class GoToThemeChangeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel mv;
        private bool _execute;
        public GoToThemeChangeCommand(MainViewModel mainViewModel)
        {
            mv = mainViewModel;
            _execute = true;
        }
        public bool CanExecute(object param)
        {
            return _execute;
        }
        public void Execute(object param)
        {
            mv.GoToThemeChange();
        }
    }


    //Func commands
    public class QuitCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel mv;
        private bool _execute;
        public QuitCommand(MainViewModel mainViewModel)
        {
            mv = mainViewModel;
            _execute = true;
        }
        public bool CanExecute(object param)
        {
            return _execute;
        }
        public void Execute(object param)
        {
            mv.Quit();
        }
    }

    public class StartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel mv;
        private bool _execute;
        public StartCommand(MainViewModel mainViewModel)
        {
            mv = mainViewModel;
            _execute = true;
        }
        public bool CanExecute(object param)
        {
            return _execute;
        }
        public void Execute(object param)
        {
            mv.Start();
        }
    }

    public class SquareStateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private SquareViewModel _sv;
        private bool _execute;

        public SquareStateCommand(SquareViewModel squareViewModel)
        {
            _sv = squareViewModel;
            _execute = true;
        }
        public bool CanExecute(object param)
        {
            return _execute;
        }
        public void Execute(object param)
        {
            var square = param as IPlayablePuzzleSquare;

            if (square.Contents.Value == Square.FILLED)
            {
                square.Contents.Value = Square.EMPTY;
            }
            else
            {
                square.Contents.Value = Square.FILLED;
            }
        }
    }

    public class ChooseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel mv;
        private bool _execute;
        public ChooseCommand(MainViewModel mainViewModel)
        {
            mv = mainViewModel;
            _execute = true;
        }
        public bool CanExecute(object param)
        {
            return _execute;
        }
        public void Execute(object param)
        {
            var picross = param as Puzzle;
            mv.Choose(picross);
        }
    }
}
