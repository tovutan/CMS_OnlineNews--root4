using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Datetime
    {
        public static string GetBackDate(DateTime date)
        {
            //TuNT13: Đề nghị đặt tên biến đủ ngữ nghĩa, không chung chung
            var result = string.Empty;

            var day = (DateTime.Now - date).Days;
            var hour = (DateTime.Now - date).Hours;
            var minute = (DateTime.Now - date).Minutes;
            var second = (DateTime.Now - date).Seconds;

            result = second + " giây trước";

            if (minute > 0)
            {
                result = minute + " phút trước";
            }

            if (hour > 0)
            {
                result = hour + " giờ trước";
            }

            if (day > 0)
            {
                result = day + " ngày trước";
            }

            if (day > 30)
            {
                result = "vào ngày " + date.ToString("dd/MM/yyyy");
            }

            return result;
        }
    }
}
