namespace Shop.Business
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public DateTime ExpiryDate { get; set; }
        public string EANCode { get; set; }
        public Price Price { get; set; }

        public Product(int id, string name, DateTime expiry, string eancode, Price price)
        { 
            ArgumentNullException.ThrowIfNull(id, nameof(id));
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            if (name.Trim() == String.Empty)
            {
                throw new ArgumentException();
            }
            ArgumentNullException.ThrowIfNull(expiry, nameof(expiry));
            ArgumentNullException.ThrowIfNull(eancode, nameof(eancode));
            ArgumentNullException.ThrowIfNull(price, nameof(price));

            if (expiry.Date < DateTime.Now.Date)
            {
                throw new ArgumentOutOfRangeException(nameof(expiry));
            }

            //TODO: validation eancode

            ProductId = id; 
            ProductName = name;
            ExpiryDate = expiry;
            EANCode = eancode;
            Price = price;
        }

        public bool IsExpired()
        { 
            return ExpiryDate.Date <= DateTime.Now.Date;
        }
    }
}