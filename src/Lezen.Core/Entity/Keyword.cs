using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lezen.Core.Entity
{
    public class Keyword
    {
        public Keyword()
        {
            this.Documents = new HashSet<Document>();
        }

        public int ID { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
