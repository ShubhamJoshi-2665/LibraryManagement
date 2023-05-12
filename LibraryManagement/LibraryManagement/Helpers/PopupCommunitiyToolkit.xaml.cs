using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibraryManagement.Helpers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupCommunitiyToolkit:Popup
	{
        private ObservableCollection<ReturnAlert> _ReturnAlertBooks;
        
        public ObservableCollection<ReturnAlert> ReturnAlertBooks
        {
            get
            {
                return _ReturnAlertBooks;
            }
            set
            {
                _ReturnAlertBooks = value;
                OnPropertyChanged(nameof(ReturnAlertBooks));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public PopupCommunitiyToolkit (ObservableCollection<ReturnAlert> data)
		{
            InitializeComponent();
            demo.ItemsSource = data;
         
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Dismiss("Data From Popup");
        }
    }
}