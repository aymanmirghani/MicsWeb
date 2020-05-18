using Mics.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mics.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DownloadPage : ContentPage
    {
        DownloadDataViewModel viewModel;
        
        public DownloadPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new DownloadDataViewModel();
        }

        private void buttonDownloadData_Clicked(object sender, EventArgs e)
        {
            try
            {
                var data = DownloadDataViewModel.GetCustomersFromLocalDb();
                progressBarDownload.Progress = 0.1;
                if (toggleDownloadCustomers.IsToggled)
                    viewModel.DownloadCustomers();

                progressBarDownload.Progress = 0.30;

                if (toggleDownloadProducts.IsToggled)
                {
                    viewModel.DownloadProducts();
                }
                int cnt = viewModel.products.Count;
                progressBarDownload.Progress = 0.70;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}