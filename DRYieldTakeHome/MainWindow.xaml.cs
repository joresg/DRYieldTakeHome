using DRYieldTakeHome.UserControls;
using DRYieldTakeHome.VM;
using Microsoft.Win32;
using SideBarNav;
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

namespace DRYieldTakeHome
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = sidebar.SelectedItem as NavButton;
            var vm = (MainWindowViewModel)this.DataContext;
            if(vm != null)
            {
                switch (selected?.Page)
                {
                    case "file_picker":
                        if (vm.LoadHomePageCommand.CanExecute(null))
                        {
                            vm.LoadHomePageCommand.Execute(null);
                            this.Title = $"{this.Title.Split(':')[0]}: File Picker";
                        }
                    break;
                    case "visualization":
                        if (vm.LoadSettingsPageCommand.CanExecute(null))
                        {
                            vm.LoadSettingsPageCommand.Execute(Helpers.Helpers.createDataForVis(1, ""));
                            this.Title = $"{this.Title.Split(':')[0]}: Visualization";
                        }
                        break;
                }
            }
            
        }
    }
}
