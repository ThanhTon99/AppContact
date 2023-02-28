using System;
using System.Collections.Generic;
using System.Drawing;
using AppContact.ViewModel;

namespace AppContact.Storage
{
    public class CacheRepository
    {
        public static CacheRepository Current = new CacheRepository();
        
        /// <summary>
        /// danh sách màu sắc
        /// </summary>
        public static List<Color> ColorArray = new List<Color>()
        {
            Color.Beige, Color.Aqua, Color.Gold, Color.Yellow, Color.PaleVioletRed,
            Color.Red, Color.Green, Color.Cornsilk, Color.Gray, Color.Goldenrod, Color.Chocolate
        };
        
        /// <summary>
        /// lưu thông tin book
        /// </summary>
        public List<BookInfo> BookInfos { get; set; }

        /// <summary>
        /// lấy index màu sắc ngẫu nhiên
        /// </summary>
        /// <returns></returns>
        public static Color GenerateColor()
        {
            var random = new Random();
            return ColorArray[random.Next(ColorArray.Count)];
        }
        
        public static int GenerateId()
        {
            var random = new Random();
            return random.Next(1000000000);
        }

        public void AddBookInfo(BookInfo info)
        {
            BookInfos ??= new List<BookInfo>();
            BookInfos.Add(info);
        }
    }
}