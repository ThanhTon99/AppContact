using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AppContact.Storage;
using AppContact.View;
using Syncfusion.DataSource.Extensions;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace AppContact.ViewModel
{
    public class BookInfoRepository: BaseViewModel
    {
        private ObservableCollection<BookInfo> _bookInfo;
        public ObservableCollection<BookInfo> BookInfo
        {
            get => _bookInfo ??= new ObservableCollection<BookInfo>();
            set => SetProperty(ref _bookInfo, value);
        }
        public string BookName { get; set; }
        public ICommand AddContactCommand { get; }
        public ICommand DemoShareCommand { get; }
        public Command ItemTapped { get; }
        
        public BookInfoRepository()
        {
            GenerateBookInfo();
            AddContactCommand = new Command(o =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new AddContact(new ContactParam()
                {
                    Callback = info =>
                    {
                        CacheRepository.Current.AddBookInfo(info);
                        BookInfo.Add(info); //= CacheRepository.Current.BookInfos?.ToObservableCollection();
                    }
                }));
            });
            DemoShareCommand = new Command(o =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new DemoShare());
            });
            ItemTapped = new Command(o =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new AddContact(new ContactParam()
                {
                    BookInfo = (BookInfo)o,
                    Callback = info =>
                    {
                        if (info.Id > 0)
                        {
                            var first = BookInfo?.FirstOrDefault(bookInfo =>
                                bookInfo.Id == info.Id);
                            if (first != null && info.IsDeleted != true)
                            {                            
                                var index = BookInfo.IndexOf(first);
                                BookInfo.Remove(first);
                                BookInfo.Insert(index, info);
                            }
                            if (first != null && info.IsDeleted == true)
                            {                            
                                var index = BookInfo.IndexOf(first);
                                BookInfo.Remove(first);
                            }
                        }
                    }
                }));
            });
        }
        public void GenerateBookInfo()
        {
            var set = new ObservableCollection<BookInfo>
            {
                new BookInfo() { BookName = "\" Object-Oriented Programming in C#", PhoneNumber = "123", Email = "tonnt@gmail.com"},
                new BookInfo() { BookName = " \t C# Code Contracts", PhoneNumber = "123", Email = "tonnt@gmail.com"},
                new BookInfo() { BookName = "Machine Learning Using C#", PhoneNumber = "123", Email = "tonnt@gmail.com"},
                new BookInfo() { BookName = "Neural Networks Using C#", PhoneNumber = "123", Email = "tonnt@gmail.com"},
                new BookInfo() { BookName = "Visual Studio Code", PhoneNumber = "123", Email = "tonnt@gmail.com"},
                new BookInfo() { BookName = "Android Programming", PhoneNumber = "123",Email = "tonnt@gmail.com"},
                new BookInfo() { BookName = "iOS Succinctly",PhoneNumber = "123", Email = "tonnt@gmail.com"},
                new BookInfo() { BookName = "Visual Studio 2015", PhoneNumber = "123", Email = "tonnt@gmail.com"},
                new BookInfo() { BookName = "Xamarin.Forms", PhoneNumber = "123", Email = "tonnt@gmail.com"},
                new BookInfo() { BookName = "Windows Store Apps", PhoneNumber = "123", Email = "tonnt@gmail.com"}
            };
            
            foreach (var info in set)
            {
                info.Id = CacheRepository.GenerateId();
                info.BookColor = CacheRepository.GenerateColor();
            }
            
            CacheRepository.Current.BookInfos = set.ToList();
            BookInfo = set;
        }
    }
}