using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DRYieldTakeHome.Model;
using ExtensionMethods;

namespace DRYieldTakeHome.VM
{
    class VisualizationViewModel : ViewModelBase
    {
        public VisualizationViewModel(Visualization model, MainWindowViewModel parentModel, string fp)
        {
            this.Model = model;
            this.FilePath = fp;
            IsWarning = fp.IsNullOrEmpty();
        }
        public Visualization Model { get; private set; }
        public MainWindowViewModel ParentModel { get; private set; }

        public List<MIR> MIRList { get; set; } = new List<MIR>();
        public List<PTR> PTRList { get; set; } = new List<PTR>();

        public string VisText
        {
            get
            {
                return IsWarning ? "NO DATA, PLEASE UPLOAD ADTF FILE" : "Visualization of the MIR Tags";
            }
        }

        public string paramText
        {
            get
            {
                return IsWarning ? "NO DATA, PLEASE UPLOAD ADTF FILE" : "Display of a Parameter Summary";
            }
        }

        private string _FilePath;
        public string FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                _FilePath = value;
                this.OnPropertyChanged("FilePath");
            }
        }
        private bool _IsWarning;
        public bool IsWarning
        {
            get
            {
                return _IsWarning;
            }
            set
            {
                _IsWarning = value;
                this.OnPropertyChanged("IsWarning");
            }
        }
        public Visibility Visibility
        {
            get
            {
                return IsWarning ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
