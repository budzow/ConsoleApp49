using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49
{
    public class ResourceHolder : IDisposable
    {
        private System.IO.FileStream fs;
        public void OpenResource(string path)
        {
            this.fs = new FileStream(path, FileMode.Open);
        }
        public void CloseResource()
        {
            this.fs.Close();
        }

        public void CleanUp()
        {
            this.fs.Dispose(); 
        }

        public void CleanUpWithCheck1()
        {
            this.fs?.Dispose();
        }

        public void CleanUpWithCheck2()
        {
            if (this.fs != null)
            {
                this.fs.Dispose();
            }
        }

        public void Dispose()
        {
            this.fs.Dispose();
        }
    }
}
