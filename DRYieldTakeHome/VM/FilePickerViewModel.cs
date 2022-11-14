using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DRYieldTakeHome.Model;

namespace DRYieldTakeHome.VM
{
    class FilePickerViewModel : ViewModelBase
    {
        public FilePickerViewModel(FilePicker model, MainWindowViewModel parentModel)
        {
            this.Model = model;
            this.ParentModel = parentModel;
        }

        public FilePicker Model { get; private set; }
        public MainWindowViewModel ParentModel { get; private set; }

        public string FilePath
        {
            get
            {
                return this.Model.FilePath;
            }
            set
            {
                this.Model.FilePath = value;
                this.OnPropertyChanged("FilePath");
            }
        }
    }
}
