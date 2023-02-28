using System;
using AppContact.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.ListView.XForms;
namespace AppContact
{
    public partial class App : Application
    {
        SfListView listView;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new AppShellContact());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
