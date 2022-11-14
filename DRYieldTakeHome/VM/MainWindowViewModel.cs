using DRYieldTakeHome.Helpers;
using SideBarNav;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DRYieldTakeHome.VM
{
    class MainWindowViewModel : ViewModelBase
    {
     
        public MainWindowViewModel()
        {
            //this.LoadHomePage(null);
            this.LoadHomePageCommand = new DelegateCommand(o => this.LoadHomePage(o));
            this.LoadSettingsPageCommand = new DelegateCommand(o => this.LoadVisualizationpage(o));
            this.SelectedBtnIndex = 0;
        }
        
        public ICommand LoadHomePageCommand { get; private set; }
        public ICommand LoadSettingsPageCommand { get; private set; }

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                this.OnPropertyChanged("CurrentViewModel");
            }
        }

        public string FilePath { get; set; }

        private int _SelectedBtnIndex;
        public int SelectedBtnIndex
        {
            get { return _SelectedBtnIndex;}
            set
            {
                _SelectedBtnIndex = value;
                this.OnPropertyChanged("SelectedBtnIndex");
            }
        }

        public FilePickerViewModel fpViewModel { get; set; }
        public VisualizationViewModel visViewModel { get; set; }

        private void LoadHomePage(object btn_index)
        {
            CurrentViewModel = new FilePickerViewModel(new Model.FilePicker(), this);
            if(btn_index != null)
            {
                SelectedBtnIndex = (int)btn_index;
            }
        }

        private void LoadVisualizationpage(object visData)
        {
            if (visData != null)
            {
                CurrentViewModel = new VisualizationViewModel(new Model.Visualization(), this, fpViewModel?.FilePath);
                //var xy = ((VisualizationViewModel)CurrentViewModel).FilePath;
                if(fpViewModel?.FilePath != null)
                {
                    List<MIR> mirList = new List<MIR>();
                    List<PTR> ptrList = new List<PTR>();
                    DeserRes deserResult = VisualizationBL.Deserialize(((VisualizationViewModel)CurrentViewModel).FilePath);
                    mirList.Add(deserResult.MIRObj);
                    foreach(var p in deserResult.PIRs)
                    {
                        ptrList.AddRange(p.PTRs);
                    }
                    ((VisualizationViewModel)CurrentViewModel).MIRList = mirList;
                    ((VisualizationViewModel)CurrentViewModel).PTRList = ptrList;
                }
                var vd = (DataForVis)visData;
                SelectedBtnIndex = vd.Index;
            }

        }
    }
}
