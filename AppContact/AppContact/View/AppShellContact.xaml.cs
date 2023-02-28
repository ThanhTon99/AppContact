using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppContact.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.ListView.XForms;


namespace AppContact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShellContact : ContentPage
    {
        public AppShellContact()
        {
            InitializeComponent();
            
        }
    }
    
}