using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lezen.Core.Entity
{
    public class Author
    {
        public Author()
        {
            this.Documents = new HashSet<Document>();
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
