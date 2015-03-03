using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pzas32driver
{
    /// <summary>
    ///  This class implements basic file operations (CRUD). </summary>
    public class FileCommand
    {
        /// <summary>
        /// Create new file connection. </summary>
        FileConnection fcon;

        /// <summary>
        /// The class constructor. </summary>
        /// <param name="fcon"> File connection </param>
        public FileCommand(FileConnection fcon)
        {
            this.fcon = fcon;
        }

        /// <summary>
        /// Method that add new row into the file. </summary>
        /// <param name="row"> Row that will be added to the file </param>
        public void add(Row row)
        {
            try
            {
                this.fcon.Open(FileMode.Append, FileAccess.Write);
                using (StreamWriter sw = new StreamWriter(fcon.fstream))
                {
                    sw.WriteLine(row.ToString());
                }
                this.fcon.Close();
            }
            catch (Exception e) 
            {
                Console.WriteLine("Exception : " + e.Message);
            }
           
        }

        /// <summary>
        /// Method that add new row into the file. </summary>
        /// <param name="rows">  </param>
        public void addRows(List<Row> rows)
        {
            this.fcon.Open(FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fcon.fstream))
            {
                foreach (Row row in rows)
                {
                    sw.WriteLine(row.ToString());
                }
            }
            this.fcon.Close();
        }

        /// <summary>
        /// Method that read file. </summary>
        /// <returns> Return file splited into rows. </returns>
        public FileResultSet read()
        {
            this.fcon.Open(FileMode.Open, FileAccess.Read);
            FileResultSet fset = new FileResultSet();
            using (StreamReader sr = new StreamReader(fcon.fstream))
            {                
                String line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] tempCols = line.Split(',');
                    List<String> cols = new List<String>();
                    foreach (String col in tempCols)
                    {
                        cols.Add(col);
                    }
                    Row row = new Row(cols);
                    if (row != null)
                    {
                        fset.addRow(row);
                    }
                        
                }
            }
            this.fcon.Close();
            return fset;
        }

        /// <summary>
        /// Method that delete row from file by row index. </summary>
        /// <param name="index"> Row index in the file. </param>
        /// <returns> Return true if row successfully deleted. </returns>
        public bool deleteByIndex(int index)
        {
            if (index > 0)
            {
                FileResultSet fset = this.read();
                if (fset.lastIndex() >= index)
                {
                    fset.removeByIndex(index);
                    fcon.Open(FileMode.Truncate, FileAccess.Write);
                    fcon.Close();
                    this.addRows(fset.getRows());
                    return true;
                }
                else
                    throw new Exception("В колекції не існує елемента з індексом " + index);
                
            }
            else
                throw new Exception("Індекс [" + index + "] повинен бути більшим від 0");
        }

        /// <summary>
        /// Method that update row in the file. /// </summary>
        /// <param name="index"> Row index in the file. </param>
        /// <param name="row"> New row that replace old row in the file. </param>
        /// <returns> Return true if row successfully deleted. </returns>
        public bool update(int index, Row row)
        {
            if (index > 0)
            {
                FileResultSet fset = this.read();
                if (fset.lastIndex() >= index)
                {
                    fset.update(index, row);
                    fcon.Open(FileMode.Truncate, FileAccess.Write);
                    fcon.Close();
                    this.addRows(fset.getRows());
                    return true;
                }
                else
                    throw new Exception("В колекції не існує елемента з індексом " + index);
            }
            else
                throw new Exception("Індекс [" + index + "] повинен бути більшим від 0");
        }
    }
    public Row ReadByIndex(int index)
    {
        if (index >= 0)
        {
            this.fcon.Open(FileMode.Open, FileAccess.Read);
            FileResultSet fset = new FileResultSet();
            using (StreamReader sr = new StreamReader(fcon.fstream))
            {
                String line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] tempCols = line.Split(',');
                    List<String> cols = new List<String>();
                    foreach (String col in tempCols)
                    {
                        cols.Add(col);
                    }
                    Row row = new Row(cols);
                    if (row != null)
                    {
                        fset.addRow(row);
                    }
                }
            }
            this.fcon.Close();
            return fset.getRow(index);
        }
        else
        {
            throw new Exception("Індекс [" + index + "] не повинен бути від'ємним");
        }
    }

    public void Delete()
    {
        Row temp = ReadByIndex(0);
        fcon.Open(FileMode.Truncate, FileAccess.Write);
        fcon.Close();
        add(temp);
    }
    
}
