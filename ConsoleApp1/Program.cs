using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        public static void Testc()
        {
            string insertLine = "http://localhost:51286/api/Highscore/5";
            var client = new HttpClient();
            var result = await client.GetStringAsync(insertLine);
        }
    }
}
