using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibraryManagement.Views.AdminPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBook : ContentPage
    {

        public AddBook()
        {

            BindingContext = new AddBookViewModel();
            InitializeComponent();
        }
        public AddBook(BooksResponse book)
        {

            BindingContext = new AddBookViewModel(book);
            InitializeComponent();
        }
    }
}