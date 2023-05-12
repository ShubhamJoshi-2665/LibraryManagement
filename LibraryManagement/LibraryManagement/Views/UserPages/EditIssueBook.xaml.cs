using LibraryManagement.Model;
using LibraryManagement.ViewModel;
using LibraryManagement.ViewModel.LibraryManagement.ViewModel;
using LibraryManagement.Views.AdminPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibraryManagement.Views.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditIssueBook : ContentPage
    {
        public EditIssueBook()
        {
            InitializeComponent();
        }

        
        public EditIssueBook(IssueBookModel book)
        {
            BindingContext = new EditPageViewModel(book);
            InitializeComponent();
        }

        private void ReturnDateSelected(object sender, DateChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            var returndate = picker.Date;
            DateTime issuedate = DateTime.Now.Date;
        (BindingContext as EditPageViewModel).BookReturnDate = returndate;
        }
    }
}