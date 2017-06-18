namespace Makaki.Model
{
    public class Guardian
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Personal Identificatin Number
        /// USA = Security Social Number
        /// Bosnia = JMBG
        /// Croatia = OIB
        /// </summary>
        public string PID { get; set; }
    }
}
