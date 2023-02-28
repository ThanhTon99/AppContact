using AppContact.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppContact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContact : ContentPage
    {
        public AddContact(ContactParam param)
        {
            InitializeComponent();
            var vm = (ContactViewModel)BindingContext;
            vm.UpdateParam(param);
            vm.TitleBook = param.BookInfo == null ? "Thêm danh sách" : "Sửa danh sách";
            vm.IsShowB = param.BookInfo != null;
        }
    }
}