using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using keyboard_emulator_windows.Library;
// using keyboard_emulator_windows.Util;

namespace keyboard_emulator_windows.ViewModel
{
    public class TextToType : INotifyPropertyChanged
    {

        private bool KeyStrokerBusy = false;

        #region Properties
        private string _TextContent = "";
        public string TextContent
        {
            get { return _TextContent; }
            set
            {
                if (_TextContent != value)
                {
                    _TextContent = value;
                    NotifyPropertyChanged(nameof(TextContent));
                }
            }
        }

        private int _DelayBeforeStart = 2000;
        public int DelayBeforeStart
        {
            get { return _DelayBeforeStart; }
            set
            {
                if (_DelayBeforeStart != value)
                {
                    _DelayBeforeStart = value;
                    NotifyPropertyChanged(nameof(DelayBeforeStart));
                }
            }
        }

        private int _IntervalBetweenKeystrokes = 20;
        public int IntervalBetweenKeystrokes
        {
            get { return _IntervalBetweenKeystrokes; }
            set
            {
                if (_IntervalBetweenKeystrokes != value)
                {
                    _IntervalBetweenKeystrokes = value;
                    NotifyPropertyChanged(nameof(IntervalBetweenKeystrokes));
                }
            }
        }

        #endregion Properties

        #region Commands

        public ICommand? EditContentCommand { get; set; }
        public void EditContent_Click(TextToType sender)
        {
            MessageBox.Show("Not Implemented!");
        }

        public ICommand? SendKeysCommand { get; set; }
        public void SendKeys_Click(TextToType sender)
        {
            MessageBox.Show("Not Implemented!");
            // throw new NotImplementedException();
            // if (null == sender || string.IsNullOrWhiteSpace(sender.Host)) return;
            // var proc = new Process();
            // proc.StartInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\mstsc.exe");
            // proc.StartInfo.Arguments = $"/v \"{sender.Host}\" /prompt";
            // proc.Start();
        }

        public ICommand? ToggleLockCommand { get; set; }
        public void ToggleLock_Click(TextToType sender)
        {
            MessageBox.Show("Not Implemented!");
            // if (null == sender || string.IsNullOrWhiteSpace(sender.Host)) return;
            // var proc = new Process();
            // proc.StartInfo.FileName = BrowserUtils.GetDefaultBrowserPath();
            // proc.StartInfo.Arguments = $"http://{sender.Host}";
            // proc.Start();
        }

        #endregion Commands

        #region Methods

        public void ResolveHost()
        {
            KeyStrokerBusy = true;
            try
            {
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ResolveHost: " + ex.Message + "\r\nStack: " + ex.StackTrace);
            }
            KeyStrokerBusy = false;
        }

        public void ResolveHostAsync()
        {
            try
            {
                if (!KeyStrokerBusy)
                {
                    // Task t = Task.Factory.StartNew(delegate { ResolveHost(); });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("PingAsync: " + ex.Message + "\r\nStack: " + ex.StackTrace);
            }
        }

        #endregion Methods

        #region Constructors

        public TextToType()
        {
            EditContentCommand = new RelayCommand(delegate { EditContent_Click(this); });
            SendKeysCommand = new RelayCommand(delegate { SendKeys_Click(this); });
            ToggleLockCommand = new RelayCommand(delegate { ToggleLock_Click(this); });
        }

        public TextToType(string textContent) : this()
        {
            TextContent = textContent;
        }

        #endregion Constructors

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged

    }
}