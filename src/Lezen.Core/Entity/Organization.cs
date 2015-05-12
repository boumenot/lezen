using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lezen.Core.Entity
{
    public class Organization
    {
        public int ID { get; set; }

        public string Institution { get; set; }
        public string Department { get; set; }
        public string PostalCode { get; set; }
        public string Settlement { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
    }
}
