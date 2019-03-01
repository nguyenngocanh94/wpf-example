namespace WpfApp1
{

    enum TaskType { Home, Work }

    class Task : Bindable
    {
        string name;
        string decription;
        int priority;
        TaskType type;
        int completePercent;

        public string Name { get; set; }
        public string Decription {
            get => this.decription;
            set
            {
                this.decription = value;
                this.NotifyPropertyChanged(nameof(Decription));
            }
        }
        public int CompletePercent { get; set; }
        public int Priority { get; set; }
        public TaskType Type { get; set; }
    }
}
