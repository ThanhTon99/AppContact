using System;
using System.ComponentModel;
using System.Drawing;

namespace AppContact.ViewModel
{
    public class BookInfo : BaseViewModel
    {
        public int Id { get; set; }
        private string _bookName;
        private string _bookDescription;
        private string _phoneNumber;
        private string _email;
        private Color _bookColor;
        private bool _isDeleted = false;

        public bool IsDeleted
        {
            get => _isDeleted;
            set => SetProperty(ref _isDeleted, value);
        }

        public string BookName
        {
            get => _bookName;
            set => SetProperty(ref _bookName, value);
        }

        public string BookDescription
        {
            get => _bookDescription;
            set => SetProperty(ref _bookDescription, value);
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public Color BookColor
        {
            get => _bookColor;
            set => SetProperty(ref _bookColor, value);
        }
    }
}