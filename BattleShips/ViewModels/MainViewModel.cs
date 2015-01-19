﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using BattleShips.Annotations;

namespace BattleShips.Views
{
    class MainViewModel : INotifyPropertyChanged
    {
        private ICommand _fireMisileCommand;
        private string _statusBarString;

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
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"views\sounds\bomb-falling-and-exploding-01.wav");
            player.Play();

            _mainViewModel.StatusBarString = "BANG!";
            

            //MainWindow.TextBlockStatusBar.Text = "Missile fired: " + e.GetPosition(CanvasMyShots);
            //Missile missile = new Missile();
            //MainWindow.CanvasMyShots.Children.Add(missile);
            //Canvas.SetLeft(missile, (int)(e.GetPosition(CanvasMyShots).X / 40) * 40);
            //Canvas.SetTop(missile, (int)(e.GetPosition(CanvasMyShots).Y / 40) * 40);
        }

        public event EventHandler CanExecuteChanged;
    }
}