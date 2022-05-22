using System;
using System.Windows.Forms;
using WheatherApp.ViewModels;

namespace WheatherApp
{
    public partial class WheatherLatestView : Form
    {
        private WheatherLatestViewModel _viewModel = new WheatherLatestViewModel();
        public WheatherLatestView()
        {
            InitializeComponent();

            this.AreaIdTextBox.DataBindings.Add("Text", _viewModel, nameof(_viewModel.AreaIdText));
            this.DataDateLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.DataDateText));
            this.ConditionLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.ConditionText));
            this.TemperatureLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.TemperatureText));
        }

        private void WeatherLatestView_Load(object sender, EventArgs e)
        {

        }

        private void LatestButton_Click(object sender, EventArgs e)
        {

            _viewModel.Search();
                
        }
    }
}
