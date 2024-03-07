namespace BrowserRentalCar.Domain.Entities
{
    public class Vehicle : BaseDomainModel
    {
        public Vehicle()
        {
            TravelHistories = new HashSet<TravelHistory>();
        }

        public string Description { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public bool Avaible { get; set; } = true;
        public Guid LocationId { get; set; } = Guid.Empty;


        public virtual ICollection<TravelHistory>? TravelHistories { get; set; }
        public virtual Location? LocationNavigation { get; set; }
    }
}