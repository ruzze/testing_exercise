using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business
{
    public class Price
    {
        public float value { get; set; }
        public DateRange dateRange { get; set; }

        public Price(float price, DateRange range)
        { 
            ArgumentNullException.ThrowIfNull(price, nameof(price));
            ArgumentNullException.ThrowIfNull(range, nameof(range));
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price));
            }


            value = price;
            dateRange = range;
        }
    }

    public class Discount
    {
        public int value { get; set; }
        public DateRange dateRange { get; set; }

        public Discount(int value, DateRange range)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            ArgumentNullException.ThrowIfNull(range, nameof(range));

            if (value < 5 || value > 50 || value % 5 != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            this.value = value;
            this.dateRange = range;
        }

        public override string ToString()
        {
            return String.Format("{0}%", value);
        }
    }

    public class DateRange
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }

        public DateRange(DateTime fromDate, DateTime toDate)
        {
            ArgumentNullException.ThrowIfNull(fromDate, nameof(fromDate));
            ArgumentNullException.ThrowIfNull(toDate, nameof(toDate));
            if (fromDate.Date > toDate.Date)
            {
                throw new ArithmeticException(nameof(fromDate) + nameof(toDate));
            }

            from = fromDate;
            to = toDate;
        }
    }
}
