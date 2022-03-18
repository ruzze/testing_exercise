using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Business.Tests
{
    public class PriceTests
    {
        [Fact]
        public void PriceIsCreated()
        {
            var priceValue = 15.0f;
            var discountValue = 10;
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));
            var discount = new Discount(discountValue, dateRange);

            var price = new Price(priceValue, dateRange, discount);

            Assert.NotNull(price);
            Assert.NotNull(price.discount);

            Assert.Equal(priceValue, price.value);
            Assert.Equal(discount, price.discount);
            Assert.Equal(dateRange, price.dateRange);
        }

        [Fact]
        public void PriceIsCreated_WhenDiscountIsNull()
        {
            var priceValue = 15.0f;            
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));            

            var price = new Price(priceValue, dateRange, null);

            Assert.NotNull(price);
            Assert.Null(price.discount);

            Assert.Equal(priceValue, price.value);            
            Assert.Equal(dateRange, price.dateRange);
        }
    }
}
