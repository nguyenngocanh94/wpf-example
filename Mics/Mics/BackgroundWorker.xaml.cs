using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Mics
{
    /// <summary>
    /// Interaction logic for BackGroundWorker.xaml
    /// </summary>
    public partial class BackGroundWorker : Window, INotifyPropertyChanged
    {

        private BackgroundWorker worker;
        private int sum;
        private string theDirectory;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string TheDirectory {
            get => theDirectory;
            set { theDirectory = value; OnPropertyChanged("TheDirectory"); }
        }

        public BackGroundWorker()
        {
            InitializeComponent();
            DataContext = this;
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            //indicate that the worker can report progress
            worker.WorkerReportsProgress = true;
            // += for subscribing, and -= for unsubcribing
            // DoWork event sẽ đc chạy khi RunWorkerAsync call
            worker.DoWork += worker_DoWork;
            // Đc gọi khi ReportProgress đc call
            worker.ProgressChanged += worker_ProgressChanged;
            // khi BackgroundWorker chạy xong thì sẽ đc call
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            
        }

       

        private void ASync_Click(object sender, RoutedEventArgs e)
        {
            progress.Value = 0;
            result.Items.Clear();
            if(!worker.IsBusy)
            worker.RunWorkerAsync(TheDirectory);
        }


        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string location = (string)e.Argument;
            sum = Directory.GetFiles(location, "*", SearchOption.AllDirectories).Length;
            var fileCount = 0;
            GetAllChild(location, e, ref fileCount);
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
            if (e.UserState != null)
                result.Items.Add(e.UserState);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Stoped, counted file in directory is: "+ e.Result);
            }
            else
            {
                MessageBox.Show("the number of file in directory is: " + e.Result);
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
        }

        private void GetAllChild(string location, DoWorkEventArgs e, ref int filesCount)
        {
            
            try
            {
                foreach (string f in Directory.GetFiles(location))
                {

                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        e.Result = filesCount;
                        return;
                    }

                    filesCount = filesCount + 1;
                    var tempCount = filesCount;
                    System.Threading.Thread.Sleep(1);
                    Dispatcher.Invoke(()=> {
                        result.Items.Add(f);                       
                        progress.Value = Convert.ToInt32(((double)tempCount / sum) * 100);
                    });
                }

                foreach (string d in Directory.GetDirectories(location))
                {

                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        e.Result = filesCount;
                        return;
                    }
                    GetAllChild(d, e,ref filesCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if(e.Result == null || (int)e.Result < filesCount)
            {
                e.Result = filesCount;
            }
        }

        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
            DialogResult result = openFileDialog.ShowDialog();
            
            // i cant not compact this include
            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.SelectedPath))
            {
                TheDirectory = openFileDialog.SelectedPath;
            }

        }
    }
}
