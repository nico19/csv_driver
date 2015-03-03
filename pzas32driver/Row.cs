using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pzas32driver
{
    /// <summary>
    /// Describe element of data model. /// </summary>
    public class Row
    {
        List<String> cols;

        /// <summary>
        /// The class constructor. </summary>
        /// <param name="cols"> List of type string items. </param>
        public Row(List<String> cols)
        {
            this.cols = cols;
        }

        /// <summary>
        /// Method to get column. </summary>
        /// <returns> Return list of type string items</returns>
        public List<String> getCols()
        {
            return this.cols;
        }

        /// <summary>
        /// Method that convert list items to string. </summary>
        /// <returns> Return result string </returns>
        public String ToString()
        {
            String res = "";
            int i = 0;
            this.cols.ForEach(delegate(String col)
            {
                res += col;
                if(i != cols.Count - 1)
                    res += ",";
                i++;
            });
            
            return res;
        }

        /// <summary>
        /// Method to add item to the row. </summary>
        /// <param name="col"> String with some text. </param>
        public void Add(String col)
        {
            this.cols.Add(col);
        }
    }
}
