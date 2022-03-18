using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Business.Tests
{
    public class ProductTests
    {
        [Fact]
        public void ProductIsCreated()
        {
            var idProduct = 0;
            var EANCode = "8033210744343";
            var productName = "Basilico";
            var expiryDate = DateTime.Now + TimeSpan.FromDays(5);
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));
            var discount = new Discount(5, dateRange);
            var price = new Price(10.0f, dateRange, discount); 
            var product = new Product(idProduct, productName, expiryDate, EANCode, price);

            Assert.NotNull(product);
            Assert.Equal(idProduct, product.ProductId);
            Assert.Equal(price, product.Price);
            Assert.Equal(expiryDate, product.ExpiryDate);
            Assert.Equal(EANCode, product.EANCode);
            Assert.Equal(productName, product.ProductName);
        }

        [Fact]
        public void ProductIsNotCreatedWhenExpiryDateIsMinorThanNow()
        {
            var idProduct = 0;
            var EANCode = "8033210744343";
            var productName = "Basilico";
            var expiryDate = DateTime.Now - TimeSpan.FromDays(1);
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));
            var discount = new Discount(5, dateRange);
            var price = new Price(10.0f, dateRange, discount);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(idProduct, productName, expiryDate, EANCode, price));
        }

        [Fact]
        public void ProductIsExpired()
        {
            var idProduct = 0;
            var EANCode = "8033210744343";
            var productName = "Basilico";
            var expiryDate = DateTime.Now;
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));
            var discount = new Discount(5, dateRange);
            var price = new Price(10.0f, dateRange, discount);
            var product = new Product(idProduct, productName, expiryDate, EANCode, price);

            Assert.True(product.IsExpired());
        }

        [Fact]
        public void ProductIsNotExpired()
        {
            var idProduct = 0;
            var EANCode = "8033210744343";
            var productName = "Basilico";
            var expiryDate = DateTime.Now + TimeSpan.FromDays(1);
            var dateRange = new DateRange(DateTime.Now, DateTime.Now + TimeSpan.FromDays(10));
            var discount = new Discount(5, dateRange);
            var price = new Price(10.0f, dateRange, discount);
            var product = new Product(idProduct, productName, expiryDate, EANCode, price);

            Assert.False(product.IsExpired());
        }
    }
}
