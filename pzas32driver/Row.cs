using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pzas32driver
{
    public class Row
    {
        List<String> cols;
        public Row(List<String> cols)
        {
            this.cols = cols;
        }
        public List<String> getCols()
        {
            return this.cols;
        }
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
        public void Add(String col)
        {
            this.cols.Add(col);
        }
    }
}
