using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lezen.Core.Entity
{
    public class LezenContext : DbContext, ILezenContext
    {
        public LezenContext(string nameOfConnectionFactory)
            : base(nameOfConnectionFactory)
        {
        }

        public IDbSet<Document> Documents { get; set; }
    }
}
