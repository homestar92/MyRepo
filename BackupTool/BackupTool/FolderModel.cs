using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupTool
{
    public class FolderModel : INotifyPropertyChanged
    {
        private string _folder { get; set;  }

        public string Folder
        {
            get { return _folder; }
            set
            {
                _folder = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Folder"));
                }
            }
        }

        public FolderModel(string folder)
        {
            this.Folder = folder;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
