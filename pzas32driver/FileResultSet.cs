using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pzas32driver
{
   public class FileResultSet
    {
        List<Row> rows = new List<Row>();
        public Row getRow(int index)
        {
            return this.rows[index];
        }
        public void addRow(Row row)
        {
            this.rows.Add(row);
        }
        public int count()
        {
            return this.rows.Count;
        }
    }
}
