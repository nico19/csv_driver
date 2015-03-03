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
        /// Store the file path. </summary>
        string path; 

        /// <summary>
        /// Using for opening and closing the file. </summary>
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
        /// <param name="fmode"> Specifies how the file should be opened. </param>
        /// <param name="faccess"> Defines constants for the access to the file. </param>
        /// <returns> Return true if the file exist. </returns>
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
