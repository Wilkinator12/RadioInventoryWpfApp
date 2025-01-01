using Microsoft.Extensions.DependencyInjection;
using RadioInventoryWpfUI.ViewModels;
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

namespace RadioInventoryWpfUI.Views
{
    /// <summary>
    /// Interaction logic for ViewRadiosView.xaml
    /// </summary>
    public partial class ViewRadiosView : UserControl
    {
        public ViewRadiosView()
        {
            InitializeComponent();


            var viewModel = App.GlobalServiceProvider.GetService<ViewRadiosViewModel>();
            DataContext = viewModel;
        }

        private void DepartmentRadioTemplateListView_Loaded(object sender, RoutedEventArgs e)
        {
            ((ViewRadiosViewModel)DataContext).LoadRadios();
        }
    }
}
