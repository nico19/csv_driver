using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pzas32driver
{
    public class FileConnection
    {
        string path;
        public FileStream fstream;
        public FileConnection(string path)
        {
            this.path = path;
        }
        public bool Open(FileMode fmode, FileAccess faccess){
            if(File.Exists(this.path))
            {
                this.fstream = new FileStream(this.path, fmode, faccess);
                return true;
            }
            else
                throw new Exception("Файл "+ this.path +" не існує");
        }
        public void Close()
        {
            this.fstream.Close();
        }
    }
}
