
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.MVVM.Models
{
    public class ItemDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private string detailed;

        public string Detailed
        {
            get { return detailed; }
            set { detailed = value; OnPropertyChanged("Detailed"); }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }

        //private string todoId;
        //public string TodoId
        //{
        //    get { return todoId; }
        //    set { todoId = value; OnPropertyChanged("TodoId"); }
        //}

    }
}
