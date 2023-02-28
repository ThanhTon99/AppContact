using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppContact.Storage;
using Xamarin.Essentials;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace AppContact.ViewModel
{
    public class ContactViewModel : BaseViewModel
    {
        public ContactParam Param { get; set; }
        
        public ObservableCollection<BookInfo> bookInfo;

        private bool _sLRow0 = false;

        public bool SlRow0
        {
            get => _sLRow0;
            set => SetProperty(ref _sLRow0, value);
        }

        private string _textButton = "Xem thêm";

        public string TextButton
        {
            get => _textButton;
            set => SetProperty(ref _textButton, value);
        }

        int _rotation;

        public int Rotation
        {
            get => _rotation;
            set => SetProperty(ref _rotation, value);
        }

        string _textLabel = "\uf107";
        private string _name;
        private string _phone;
        private string _email;
        private string _titleBook;
        public string TextLabel
        {
            get => _textLabel;
            set => SetProperty(ref _textLabel, value);
        }
        
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string TitleBook
        {
            get => _titleBook;
            set => SetProperty(ref _titleBook, value);
        }
        private bool _isShowB = false;

        public bool IsShowB
        {
            get => _isShowB;
            set => SetProperty(ref _isShowB, value);
        }
        public ICommand ShowHiddenRow0Command { get; }
        public ICommand SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command DeletedCommand { get; }
        public ContactViewModel()
        {
            ShowHiddenRow0Command = new Command(async () =>
                {
                    SlRow0 = !SlRow0;
                    if (SlRow0)
                    {
                        TextButton = "Thu gọn";
                        Rotation = 180;
                        TextLabel = "\uf106";
                    }
                    else
                    {
                        TextButton = "Xem thêm";
                        Rotation = 0;
                        TextLabel = "\uf107";
                    }
                }
            );
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            DeletedCommand = new Command(OnDeleted);
        }

        public void UpdateParam(ContactParam param)
        {
            Param = param;
            
            //sửa
            if (param.BookInfo != null)
            {
                Name = param.BookInfo.BookName;
                Phone = param.BookInfo.PhoneNumber;
                Email = param.BookInfo.Email;
            }
        }
        
        private async void OnCancel()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        
        private async void OnSave()
        {

            var bookInfo = Param.BookInfo;
            if (Param.BookInfo != null)
            {
                bookInfo.BookName = Name;
                bookInfo.PhoneNumber = Phone;
                bookInfo.Email = Email;
            }
            else
            {
                bookInfo = new BookInfo()
                {
                    Id = CacheRepository.GenerateId(),
                    BookName = Name,
                    PhoneNumber = Phone,
                    Email = Email,
                    BookColor = CacheRepository.GenerateColor(),
                };
            }
            Param.Callback.Invoke(bookInfo);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private async void OnDeleted()
        {
            var bookInfo = Param.BookInfo;
            bookInfo.IsDeleted = true;
            Param.Callback.Invoke(bookInfo);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(_name);
        }
    }

    public class ContactParam
    {
        /// <summary>
        /// đối tượng được chọn
        /// 1. null: thêm mới
        /// 2. != null: edit, delete
        /// </summary>
        public BookInfo BookInfo { get; set; }

        /// <summary>
        /// xử lý trả về khi lưu, sửa, xóa
        /// </summary>
        public Action<BookInfo> Callback { get; set; }
    }
}