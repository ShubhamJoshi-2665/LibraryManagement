using LibraryManagement.Model;
using LibraryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Internals.Profile;

namespace LibraryManagement.Views.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IssueBookPage : ContentPage
    {
        private const string Format = "MM-dd-yyyy HH':'mm':'ss";

        public IssueBookPage(BooksResponse book)
        {
            InitializeComponent();
            BindingContext = new IssueBookViewModel(book);
        }

        private void ReturnDateSelected(object sender, DateChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            var returndate = picker.Date;
            DateTime issuedate = DateTime.Now.Date;


            (BindingContext as IssueBookViewModel).BookIssueDate = issuedate;
              (BindingContext as IssueBookViewModel).BookReturnDate = returndate;
        }

        
    }
}