﻿using System;
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
        public Discount? discount { get; set; }

        public Price(float price, DateRange range, Discount? discount)
        { 
            ArgumentNullException.ThrowIfNull(price, nameof(price));
            ArgumentNullException.ThrowIfNull(range, nameof(range));            

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price));
            }

            value = price;
            dateRange = range;
            this.discount = discount;
        }

        public float GetDiscountedPrice()
        {
            if (discount != null)
            {
                return value * (1.0f - (discount.value / 100.0f));
            }
            else
            {
                return value;
            }
        }
    }

    public class Discount
    {
        public const int minValue = 5;
        public const int maxValue = 50;
        public const int step = 5;

        public int value { get; set; }
        public DateRange dateRange { get; set; }

        public Discount(int value, DateRange range)
        {            
            ArgumentNullException.ThrowIfNull(range, nameof(range));

            if (value < minValue || value > maxValue || value % step != 0)
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
            if (fromDate.Date.CompareTo(toDate.Date) > 0 )
            {
                throw new ArithmeticException(nameof(fromDate) + nameof(toDate));
            }

            from = fromDate;
            to = toDate;
        }
    }
}
