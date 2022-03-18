namespace Shop.Database.Entities
{
    public class PriceEntity
    {
        public float value { get; set; }
        public DateRangeEntity range { get; set;}
        public DiscountEntity? discount { get; set; }
    }
}