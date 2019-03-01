
using System.Collections.ObjectModel;
using Model;

namespace ModelView
{
    class ModelView
    {
        ObservableCollection<Student> students;

        public ObservableCollection<Student> Students
        {
            get;
            set;
        }

        public ModelView()
        {
            Students = new ObservableCollection<Student>();
            Students.Add(new Student(){Id = 1, Name = "sinbad 2", Point = 9});
            Students.Add(new Student(){Id = 2, Name = "javas2e", Point = 9});
            Students.Add(new Student(){Id = 3, Name = "Pehesa3", Point = 9});
            Students.Add(new Student(){Id = 4, Name = "Cersss7", Point = 7});
        }
    }
}
