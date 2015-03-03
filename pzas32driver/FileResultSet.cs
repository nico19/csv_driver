using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pzas32driver
{
    /// <summary>
    /// This class contains the file splitted into rows. /// </summary>
    public class FileResultSet
    {
        /// <summary>
        /// Create list of Row type items. /// </summary>
        List<Row> rows = new List<Row>();

        /// <summary>
        /// Method that gets rows index. /// </summary>
        /// <param name="index"> Index of item in row-type list. </param>
        /// <returns> Return number of row position. </returns>
        public Row getRow(int index)
        {
            return this.rows[index];
        }

        /// <summary>
        /// Method that gets rows list. /// </summary>
        /// <returns> Return rows list. </returns>
        public List<Row> getRows()
        {
            return this.rows;
        }

        /// <summary>
        /// Method that add new row to the rows collection. /// </summary>
        /// <param name="row"> Row that will be added to the row collection. </param>
        public void addRow(Row row)
        {
            this.rows.Add(row);
        }

        /// <summary>
        /// Method that returns count of rows in collection. /// </summary>
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
