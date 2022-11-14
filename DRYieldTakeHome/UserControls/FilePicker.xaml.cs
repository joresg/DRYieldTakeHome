using DRYieldTakeHome.VM;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DRYieldTakeHome.Model;
using DRYieldTakeHome.Helpers;

namespace DRYieldTakeHome.UserControls
{
    /// <summary>
    /// Interaction logic for FilePicker.xaml
    /// </summary>
    public partial class FilePicker : UserControl
    {
        string FilePath { get; set; }
        
        public FilePicker()
        {
            InitializeComponent();
        }

        private void rect_Drop(object sender, DragEventArgs e)
        {
            Rectangle ellipse = sender as Rectangle;
            if (ellipse != null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    // Note that you can have more than one file.
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    //MessageBox.Show(files[0]);
                    FilePath = files[0];
                    //go to visualization control
                    var viewModel = (FilePickerViewModel)DataContext;
                    if (viewModel != null)
                    {
                        var parentViewModel = (MainWindowViewModel)viewModel.ParentModel;
                        if (parentViewModel != null)
                        {
                            //if (parentViewModel.LoadSettingsPageCommand.CanExecute(null))
                            //    parentViewModel.LoadSettingsPageCommand.Execute(Helpers.Helpers.createDataForVis(1, FilePath));
                            viewModel.FilePath = FilePath;
                            parentViewModel.fpViewModel = viewModel;
                            parentViewModel.SelectedBtnIndex = 1;
                        }

                    }
                }
            }
        }

        private void UploadFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            bool? answer = dlg.ShowDialog();
            if (answer.HasValue && answer.Value)
            {
                string filePath;
                filePath = dlg.FileName;
                //MessageBox.Show(fileName);
                FilePath = filePath;
                //go to visualization control
                var viewModel = (FilePickerViewModel)DataContext;
                if(viewModel != null)
                {
                    var parentViewModel = (MainWindowViewModel)viewModel.ParentModel;
                    if (parentViewModel != null)
                    {
                        /*
                        if (parentViewModel.LoadSettingsPageCommand.CanExecute(null))
                        {
                            parentViewModel.LoadSettingsPageCommand.Execute(Helpers.Helpers.createDataForVis(1, FilePath));
                        }
                        */
                        viewModel.FilePath = FilePath;
                        parentViewModel.fpViewModel = viewModel;
                        parentViewModel.SelectedBtnIndex = 1;
                    }
                }
            }
        }
    }
}
