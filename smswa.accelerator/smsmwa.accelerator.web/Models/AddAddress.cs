using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smsmwa.accelerator.web.Models
{
    public class AddAddress
    {
        public int Id { get; set; }
        public int AddressTypeId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}