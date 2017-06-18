namespace Makaki.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }
    }
}
