using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pzas32driver
{
    public class FileCommand
    {
        FileConnection fcon;
        public FileCommand(FileConnection fcon)
        {
            this.fcon = fcon;
        }

        public void add(Row row)
        {
            this.fcon.Open(FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fcon.fstream))
            {
                sw.WriteLine(row.ToString());
            }
            this.fcon.Close();
        }
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
}
