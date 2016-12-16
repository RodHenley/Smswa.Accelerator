using System.Collections.Generic;

namespace smswa.accelerator.sample.model
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        
        public virtual List<Address> Addresses { get; set; }
        public virtual List<Contact> Contacts { get; set; }
    }
}