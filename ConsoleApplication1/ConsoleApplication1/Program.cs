using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleClient client = new SimpleClient();
            client.Connect("eb-cas.cloudapp.net");

            client.CreateIDSpace();
            //client.QuerySchema();


            client.Close();
        }
    }
}
