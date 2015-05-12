using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lezen.Core.Entity
{
    public class Document
    {
        public Document()
        {
            this.Authors = new HashSet<Author>();
        }

        public int ID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Author> Authors { get; private set; }
    }
}
