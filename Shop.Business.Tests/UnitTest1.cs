using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var toDate = fromDate +TimeSpan.FromDays(1);

            var dateRange = new DateRange(fromDate, toDate);
            Assert.IsNotNull(dateRange);
        }
    }
}