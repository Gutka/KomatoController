using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomatoController.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KomatoController.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnvironmentPage : ContentPage
    {
        readonly EnvironmentViewModel _viewModel;
        public EnvironmentPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new EnvironmentViewModel();

            chartTempView.Chart = _viewModel.tempChart;
            chartHumidityView.Chart = _viewModel.humidityChart;
            chartLightView.Chart = _viewModel.lightChart;
        }
    }
}