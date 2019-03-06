using System;
using System.Windows.Forms;
using Model.Utilities;

namespace ViewModel.Command
{
    public class OpenFileDialogCommand : IDialogOpenner
    {
        public event EventHandler CanExecuteChanged;

        public SelectedFileRequest SelectedFile { get; set; }       

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ((SelectedFileRequest)parameter).FileName = openFileDialog.FileName;
            }
        }
    }
}
