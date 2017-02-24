using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlob
{
    class Program
    {
        static void Main(string[] args)
        {
            dbConnection con = new dbConnection();

            //Console.WriteLine("Enter name of container:");
            //string name = Console.ReadLine();
            con.retrieveContainers();
            Console.Read();
        }
    }
}
