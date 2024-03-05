namespace EcommerceNetBlazor.Model
{
    public class Sale : BaseEntity
    {
        public string? UserId { get; set; }

        public decimal? Total { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<SaleDetail> SalesDetails { get; set; } = new List<SaleDetail>();

        public virtual User? User { get; set; }
    }
}