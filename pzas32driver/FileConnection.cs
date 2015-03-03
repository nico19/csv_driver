using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pzas32driver
{
    /// <summary>
    /// This class organizes connection to the file. </summary>
    public class FileConnection
    {
        /// <summary>
        /// Store for the file path. </summary>
        string path; 

        /// <summary>
        /// Using for open and close file. </summary>
        public FileStream fstream;

        /// <summary>
        /// The class constructor. </summary>
        /// <param name="path"> Path to the file. </param>
        public FileConnection(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Method to open the file. </summary>
        /// <param name="fmode"> Specifies how should opening a file. </param>
        /// <param name="faccess"> Defines constants for access to a file. </param>
        /// <returns> Return true if file exist. </returns>
        public bool Open(FileMode fmode, FileAccess faccess){
            if (File.Exists(this.path))
            {
                this.fstream = new FileStream(this.path, fmode, faccess);
                return true;
            }
            else
            {
                throw new Exception("Файл " + this.path + " не існує");
            }
        }

        /// <summary>
        /// Method to close the file. </summary>
        public void Close()
        {
            this.fstream.Close();
        }
    }
}
