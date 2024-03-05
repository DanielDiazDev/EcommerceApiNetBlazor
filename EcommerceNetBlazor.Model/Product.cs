namespace EcommerceNetBlazor.Model
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceOffer { get; set; }
        public int? Quantity { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<SaleDetail> SalesDetails { get; set; } = new List<SaleDetail>();
        public virtual Category? Category { get; set; }
    }
}