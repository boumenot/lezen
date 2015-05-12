using System;
using System.Data.Entity;

namespace Lezen.Core.Entity
{
    public interface ILezenContext : IDisposable
    {
        IDbSet<Author> Authors { get; set; }
        IDbSet<Document> Documents { get; set; }
        IDbSet<Organization> Organizations { get; set; }

        int SaveChanges();
    }
}
