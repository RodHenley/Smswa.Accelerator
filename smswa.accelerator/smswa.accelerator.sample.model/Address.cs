namespace smswa.accelerator.sample.model
{
    public class Address
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AddressTypeId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        
        public bool Inactive { get; set; }

        public virtual Person Person { get; set; }
        public virtual AddressType AddressType { get; set; }
    }
}