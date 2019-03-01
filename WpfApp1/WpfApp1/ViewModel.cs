using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    class ViewModel : Bindable
    {
        private List<Task> todoList;
        public List<Task> TodoList
        {
            get;
            set;
        }

        private Task selectedItem;

        private ObservableCollection<Task> tabItems;

        public Task SelectedItem
        {
            get; 
            set;
          
        }

        public ObservableCollection<Task> TabItems
        {
            get => this.tabItems;
            set
            {
                this.tabItems = value;
                this.NotifyPropertyChanged(nameof(TabItems));
            }
        }

        public ICommand AddTab { get; set; }
        public ICommand SaveTab { get; set; }

        private void AddTabAction()
        {
            TabItems.Add(new Task() {Name="untittle item" });
        }

        private void SaveTabAction()
        {
            Diaglog saveDialog = new Diaglog();
            if(saveDialog.ShowDialog() == true)
            {
                var temp = (Task)saveDialog.GetTask();
                int current = TabItems.IndexOf(SelectedItem);
                temp.Decription = SelectedItem.Decription;
                TabItems.RemoveAt(current);
                TabItems.Add(temp);
                SelectedItem = temp;
            }
        }

        public ViewModel()
        {
            TabItems = new ObservableCollection<Task>();
            this.AddTab = new BasicCommand(action: AddTabAction);
            this.SaveTab = new BasicCommand(action: SaveTabAction);
        }
    }
}
