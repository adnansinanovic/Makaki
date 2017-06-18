using System.Collections.Generic;

namespace Makaki.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
