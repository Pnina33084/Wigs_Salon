namespace Wigs_Salon.BL.Models
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
    }
}
