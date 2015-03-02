using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pzas32driver;
namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileConnection fcon = new FileConnection(@"E:\1.csv");
            FileCommand fcom = new FileCommand(fcon);
            List<String> list = new List<String>();
            list.Add("nico");
            list.Add("");
            list.Add("7889441");
            
            //fcom.add(new Row(list));
            FileResultSet fset = fcom.read();
            Console.WriteLine("Count {0}", fset.count());
            Console.ReadLine();
        }
    }
}
