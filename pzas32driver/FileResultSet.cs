using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pzas32driver
{
    /// <summary>
    /// This class contain file splited into rows. /// </summary>
    public class FileResultSet
    {
        /// <summary>
        /// Create list of type Row items. /// </summary>
        List<Row> rows = new List<Row>();

        /// <summary>
        /// Method that get rows index. /// </summary>
        /// <param name="index"> Index of item in row-type list. </param>
        /// <returns> Return number of row position. </returns>
        public Row getRow(int index)
        {
            return this.rows[index];
        }

        /// <summary>
        /// Method that get rows list. /// </summary>
        /// <returns> Return rows list. </returns>
        public List<Row> getRows()
        {
            return this.rows;
        }

        /// <summary>
        /// Method that add new row to rows collection. /// </summary>
        /// <param name="row"> Row that be added to row collection. </param>
        public void addRow(Row row)
        {
            this.rows.Add(row);
        }

        /// <summary>
        /// Method that return count of rows in collection. /// </summary>
        /// <returns> Return count of rows in collection. </returns>
        public int count()
        {
            return this.rows.Count;
        }

        /// <summary>
        /// Method that return index of last item in collection. /// </summary>
        /// <returns> Return index of last item in collection. </returns>
        public int lastIndex()
        {
            return this.count() - 1;
        }

        /// <summary>
        /// Method that remove row with some index from rows collection. /// </summary>
        /// <param name="index"> Index of row that need to be removed. </param>
        public void removeByIndex(int index)
        {
            this.rows.RemoveAt(index);
        }

        /// <summary>
        /// Method that update row in collection. /// </summary>
        /// <param name="index"> Number of row that wiil be update. </param>
        /// <param name="row"> New row that replace old row in collection </param>
        public void update(int index, Row row)
        {
            rows[index] = row;
        }
    }
}
