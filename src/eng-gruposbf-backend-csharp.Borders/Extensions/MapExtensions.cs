using eng_gruposbf_backend_csharp.Borders.Dtos.Bacen;
using eng_gruposbf_backend_csharp.Borders.Utils;
using System;
using System.Linq;

namespace eng_gruposbf_backend_csharp.Borders.Extensions
{
    public static class MapExtensions
    {
        public static string TodayIsUtil(this DateTime date)
        {
            if (new Holidays().GetHolidaysByCurrentYear(date.Year).Any(f => f == date.Date))
            {
                date = date.AddDays(-1);
            }

            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                return date.AddDays(-1).ToString("MM-dd-yyyy");
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return date.AddDays(-2).ToString("MM-dd-yyyy");
            }
            else if (date.Hour >= 0 && date.Hour < 11)
            {
                return date.AddDays(-1).ToString("MM-dd-yyyy");
            }
            else
            {
                return date.ToString("MM-dd-yyyy");
            }

        }

        public static decimal GetLastValue(this BacenQuotation bacenQuotation)
        {
            return bacenQuotation.Value.OrderByDescending(c => c.DataHoraCotacao).First().CotacaoCompra;
        }
    }
}
