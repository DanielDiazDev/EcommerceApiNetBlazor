namespace EcommerceNetBlazor.Model
{
    public class SaleDetail : BaseEntity
    {
        public int? SaleId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Total { get; set; }

        public virtual Product? Product { get; set; }

        public virtual Sale? Sale { get; set; }
    }
}