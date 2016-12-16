using System;
using System.Linq;
using System.Text;

namespace smswa.accelerator.sample.model
{
    public class Contact
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public string Value { get; set; }

        public bool Inactive { get; set; }

        public virtual Person Person { get; set; }
        public virtual ContactType ContactType { get; set; }

    }
}
