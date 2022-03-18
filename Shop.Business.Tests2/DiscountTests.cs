using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Business.Tests
{
    public class DiscountTests
    {
        [Fact]
        public void DiscountIsCreated()
        {
            var value = 10;
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));
            var disc = new Discount(value, dateRange);

            Assert.NotNull(disc);
            Assert.Equal(value, disc.value);
            Assert.Equal(dateRange, disc.dateRange);
        }

        [Fact]
        public void DiscountIsNotCreated_WhenValueIsNotMultipleOf5()
        {
            var value = 6;
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Discount(value, dateRange));
        }

        [Fact]
        public void DiscountIsNotCreated_WhenValueIsNegative()
        {
            var value = -10;
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Discount(value, dateRange));
        }

        [Fact]
        public void DiscountIsNotCreated_WhenValueExceedsMaxValue()
        {
            var value = Discount.maxValue + 1;
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Discount(value, dateRange));
        }

        [Fact]
        public void DiscountIsNotCreated_WhenValueExceedsMinValue()
        {
            var value = Discount.minValue - 1;
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Discount(value, dateRange));
        }

        [Fact]
        public void DiscountToStringTest()
        {
            int startValue;
            var endValue = Discount.maxValue;
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));
            for (startValue = Discount.minValue; startValue <= endValue; startValue += Discount.step)
            {
                var discount = new Discount(startValue, dateRange);
                Assert.Equal($"{startValue.ToString()}%", discount.ToString());
            }
        }
    }
}
