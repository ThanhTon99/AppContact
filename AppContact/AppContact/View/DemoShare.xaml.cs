using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace AppContact.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemoShare : ContentPage
    {
        public DemoShare()
        {
            InitializeComponent();
        }

        private async void ButtonShare_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = EntryShare.Text,
                Title = "Share!!!",
                
            });
        }
    }
    
}