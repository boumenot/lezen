using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lezen.Core.Test
{
    public class TempDirectory : IDisposable
    {
        private readonly string path;

        public TempDirectory(string root)
        {
            if (!System.IO.Path.IsPathRooted(root))
            {
                var msg = String.Format("The path '{0}' is not rooted!", root);
                throw new ArgumentException(msg);
            }
            
            this.path = System.IO.Path.Combine(root, System.IO.Path.GetRandomFileName());
            Directory.CreateDirectory(this.path);
        }

        public string Path { get { return this.path; } }

        public void Dispose()
        {
            if (Directory.Exists(this.path))
            {
                Directory.Delete(this.path, true);
            }
        }
    }
}
