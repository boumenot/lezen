using System;
using System.Data.Entity;

namespace Lezen.Core.Entity
{
    public interface ILezenContext : IDisposable
    {
        IDbSet<Document> Documents { get; set; }
        int SaveChanges();
    }
}
