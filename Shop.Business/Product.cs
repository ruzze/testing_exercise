namespace Shop.Business
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public DateTime ExpiryDate { get; set; }
        public string EANCode { get; set; }

        public Product(int id, string name, DateTime expiry, string eancode)
        { 
            ArgumentNullException.ThrowIfNull(id, nameof(id));
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            ArgumentNullException.ThrowIfNull(expiry, nameof(expiry));
            ArgumentNullException.ThrowIfNull(eancode, nameof(eancode));

            if (expiry < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(nameof(expiry));
            }

            //TODO: validation eancode

            ProductId = id; 
            ProductName = name;
            ExpiryDate = expiry;
            EANCode = eancode;
        }
    }
}