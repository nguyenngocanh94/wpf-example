using Model.Utilities;
using SimpleIoC;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using ViewModel.Command;

namespace ViewModel
{
    public class MicsViewModel : INotifyPropertyChanged
    {
        private bool isDraging;
        private MediaPlayer media;
        public ICommand SelectFile { get; set; }
        public ICommand Play { get; set; }
        public ICommand Pause { get; set; }
        public ICommand Stop { get; set; }
        public ICommand Seek { get; set; }       
        public ICommand Seeked { get; set; }       
        public IDialogOpenner Open { get; set; }
        public SelectedFileRequest File { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private string status;
        public string Status
        {
            get => status;
            set {
                status = value;
                NotifyPropertyChanged(nameof(Status));
            }
        }
        private int allTime;

        public int AllTime {
            get => allTime;
            set
            {
                allTime = value;
                NotifyPropertyChanged(nameof(AllTime));
            }
        }

        private int currentTime;

        public int CurrentTime
        {
            get => currentTime;
            set {
                
                currentTime = value;
                NotifyPropertyChanged(nameof(CurrentTime));
            }
        }

        public MicsViewModel()
        {
            media = new MediaPlayer();
            File = new SelectedFileRequest();
            // bind commmand
            SelectFile = new Commander(() => {
                media.Open(new Uri(File.FileName));
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();
            });

            Open = DIContainer.Resolve<IDialogOpenner>();

            Play = new Commander(()=> {
                media.Play();
            });

            Stop = new Commander(()=> {
                media.Stop();
            });

            Pause = new Commander(()=> {
                media.Pause();
            });

            Seek = new Commander(()=> {
                isDraging = true;
                
            });

            Seeked = new Commander(() => {
                isDraging = false;
                media.Position = TimeSpan.FromSeconds(CurrentTime);
            });
        }

        void timer_Tick(object sender, EventArgs e)
        {
            

            if (media.Source != null && media.NaturalDuration.HasTimeSpan && !isDraging)
            {
                CurrentTime = (int)media.Position.TotalMilliseconds;
                AllTime = (int)media.NaturalDuration.TimeSpan.TotalMilliseconds;                

                Status = String.Format("{0} / {1}", media.Position.ToString(@"mm\:ss"), media.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
            else
                Status = "No file selected...";
        }

       
    }
}
