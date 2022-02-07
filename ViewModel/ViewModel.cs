
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;
using keyboard_emulator_windows.ViewModel;
using keyboard_emulator_windows.Library;

namespace keyboard_emulator_windows.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {


        private bool? allSucceeded = null;

        private ImageSource windowIcon;

        public TaskbarItemProgressState progressState = TaskbarItemProgressState.None;

        public ObservableCollection<TextToType> TextsToType { get; set; } = new ObservableCollection<TextToType>();


        private int _DefaultDelayBeforeStart = 2000;
        public int DefaultDelayBeforeStart
        {
            get { return _DefaultDelayBeforeStart; }
            set
            {
                if (!(_DefaultDelayBeforeStart == value))
                {
                    _DefaultDelayBeforeStart = value;
                    NotifyPropertyChanged(nameof(DefaultDelayBeforeStart));
                }
            }
        }

        private int _DefaultIntervalBetweenKeystrokes = 20;
        public int DefaultIntervalBetweenKeystrokes
        {
            get { return _DefaultIntervalBetweenKeystrokes; }
            set
            {
                if (!(_DefaultIntervalBetweenKeystrokes == value))
                {
                    _DefaultIntervalBetweenKeystrokes = value;
                    NotifyPropertyChanged(nameof(DefaultIntervalBetweenKeystrokes));
                }
            }
        }

        public bool AllSucceeded
        {
            get { return allSucceeded ?? false; }
            set
            {
                if (allSucceeded != value)
                {
                    allSucceeded = value;
                    NotifyPropertyChanged("AllSucceeded");
                    ChangeIcon();
                }
            }
        }

        public ImageSource WindowIcon
        {
            get { return windowIcon; }
            private set
            {
                windowIcon = value;
                NotifyPropertyChanged("WindowIcon");
            }
        }

        public TaskbarItemProgressState ProgressState
        {
            get { return progressState; }
            set
            {
                progressState = value;
                NotifyPropertyChanged("ProgressState");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ViewModel()
        {
            LoadTextsCommand = new RelayCommand(delegate { LoadTexts_Click(this); });
            SaveTextsCommand = new RelayCommand(delegate { SaveTexts_Click(this); });
            ResetTextsCommand = new RelayCommand(delegate { ResetTexts_Click(this); });
            CancelCommand = new RelayCommand(delegate { Cancel_Click(this); });
            windowIcon = new DrawingImage();
        }

        private void ChangeIcon()
        {
        }

        public ICommand ResetTextsCommand { get; set; }
        private void ResetTexts_Click(ViewModel sender)
        {
            MessageBoxResult res = MessageBoxResult.Yes;
            if (sender.TextsToType.Count > 0)
            {
                res = MessageBox.Show("Do you really like to delete all of the texts?", "Delete texts", MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            if (res != MessageBoxResult.Yes)
            {
                return;
            }
            sender.TextsToType.Clear();
        }

        public ICommand CancelCommand { get; set; }
        private void Cancel_Click(ViewModel sender)
        {
            MessageBox.Show("Not Implemented!");
            
            foreach (TextToType item in sender.TextsToType)
            {
                // if (item.ResetCountersCommand?.CanExecute(item) ?? false)
                // {
                //     item.ResetCountersCommand?.Execute(item);
                // }
            }
        }

        public ICommand LoadTextsCommand { get; set; }
        private void LoadTexts_Click(ViewModel sender)
        {
            MessageBox.Show("Not Implemented!");
        }

        public ICommand SaveTextsCommand { get; set; }
        private void SaveTexts_Click(ViewModel sender)
        {
            MessageBox.Show("Not Implemented!");
        }

    }

}