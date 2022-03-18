using System;
using Xunit;

namespace Shop.Business.Tests
{
    public class DateRangeTest
    {
        [Fact]
        public void DateRangeIsCreated()
        {
            var fromDate = DateTime.Now;
            var toDate = fromDate + TimeSpan.FromDays(1);

            var dateRange = new DateRange(fromDate, toDate);            
            Assert.NotNull(dateRange);
            Assert.Equal(fromDate, dateRange.from);
            Assert.Equal(toDate, dateRange.to);
        }

        [Fact]
        public void DateRangeIsNotCreated_IfFromDateIsGreaterThanToDate()
        { 
            var fromDate = DateTime.Now;
            var toDate = fromDate - TimeSpan.FromDays(1);

            Assert.Throws<ArithmeticException>(() => new DateRange(fromDate, toDate));
        }
    }
}