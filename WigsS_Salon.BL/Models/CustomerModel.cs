namespace Wigs_Salon.BL.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }
}
