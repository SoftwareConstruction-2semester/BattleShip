using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using BattleShips.Annotations;
using Point = System.Windows.Point;

namespace BattleShips.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private ICommand _fireMisileCommand;
        private string _statusBarString;
        private ObservableCollection<Ship> _shipsOnGrid;
        private ObservableCollection<Ship> _shipsOutsideGrid;

        public ObservableCollection<Ship> ShipsOnGrid
        {
            get { return _shipsOnGrid; }
            set { _shipsOnGrid = value; }
        }

        public ObservableCollection<Ship> ShipsOutsideGrid
        {
            get { return _shipsOutsideGrid; }
            set { _shipsOutsideGrid = value; }
        }

        public String StatusBarString
        {
            get { return _statusBarString; }
            set
            {
                _statusBarString = value;
                OnPropertyChanged();
            }
        }

        public ICommand FireMisile
        {
            get { return _fireMisileCommand; }
            set { _fireMisileCommand = value; }
        }

        public MainViewModel()
        {
            _fireMisileCommand = new FireMisileCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    internal class FireMisileCommand : ICommand
    {
        private readonly MainViewModel _mainViewModel;

        public FireMisileCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Canvas canvas = (Canvas) parameter;
            Point point = Mouse.GetPosition(canvas);
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"views\sounds\bomb-falling-and-exploding-01.wav");
            player.Play();

            _mainViewModel.StatusBarString = "CLICK " + point;
            

            //MainWindow.TextBlockStatusBar.Text = "Missile fired: " + e.GetPosition(CanvasMyShots);
            //Missile missile = new Missile();
            //MainWindow.CanvasMyShots.Children.Add(missile);
            //Canvas.SetLeft(missile, (int)(e.GetPosition(CanvasMyShots).X / 40) * 40);
            //Canvas.SetTop(missile, (int)(e.GetPosition(CanvasMyShots).Y / 40) * 40);
        }

        public event EventHandler CanExecuteChanged;
    }
}
