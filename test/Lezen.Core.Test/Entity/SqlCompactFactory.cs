using Lezen.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lezen.Core.Test.Entity
{
    public class SqlCompactFactory : IDisposable
    {
        private readonly string filename;
        private readonly string nameOrConnectionString;

        static SqlCompactFactory()
        {
            Database.SetInitializer(
                new CreateDatabaseIfNotExists<LezenContext>());
        }

        public SqlCompactFactory()
            : this(Path.ChangeExtension(Path.GetRandomFileName(), "sdf"))
        {
        }

        public SqlCompactFactory(string filename)
        {
            this.filename = filename;
            this.nameOrConnectionString = string.Format("Data Source={0}", filename);
        }

        public ILezenContext Create()
        {
            return new LezenContext(this.nameOrConnectionString);
        }

        public void Dispose()
        {
            if (File.Exists(this.filename))
            {
                File.Delete(this.filename);
            }
        }
    }
}
