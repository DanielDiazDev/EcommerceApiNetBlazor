namespace EcommerceNetBlazor.Shared.DTOs
{
    public class SaleDTO
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        public decimal? Total { get; set; }

        public virtual ICollection<SaleDetailDTO> SalesDetailsDTO { get; set; } = new List<SaleDetailDTO>();

    }
}
