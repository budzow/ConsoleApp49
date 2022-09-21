using System;
using System.IO;


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
            this.fs.Dispose(); //S2952 triggered calling to
                               //"Move this 'Dispose' call into this class' own 'Dispose' method.",
                               //but 'Dispose' is already in class' own 'Dispose' method
        }

        public void CleanUpWithCheck1()
        {
            this.fs?.Dispose(); // S2952 not triggered
        }

        public void CleanUpWithCheck2()
        {
            if (this.fs != null)
            {
                this.fs.Dispose(); //S2952 trggered although the checks seems equivalent to the one in CleanUpWithCheck1()
            }
        }

        public void Dispose()
        {
            this.fs.Dispose();
        }
    }
}
