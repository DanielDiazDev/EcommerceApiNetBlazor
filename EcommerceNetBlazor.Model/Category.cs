namespace EcommerceNetBlazor.Model
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}