using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SetAllEventData();
            GetAllEventData();
            Console.ReadLine();
        }

        //Get
        static string urlGet = "http://localhost:52788/api/Highscore";
        //Set
        static string urlSet = "http://localhost:52788/api/Highscore";
        static string myParameters = "Test";

        public static void Testc()
        {
            string insertLine = "http://localhost:52788//api/Highscore";
            var client = new HttpClient();
            var result = client.GetStringAsync(insertLine);
            Console.WriteLine(result);
        }

        public static void GetAllEventData() //Get All Events Records  
        {
            using (var client = new System.Net.WebClient()) //WebClient  
            {
                client.Headers[System.Net.HttpRequestHeader.ContentType] ="application/json"; //Content-Type  
                var result = client.DownloadString(urlGet);  
                Console.WriteLine(Environment.NewLine + result);
            }
        }

        public static void SetAllEventData() //Get All Events Records  
        {
            using (var client = new System.Net.WebClient()) //WebClient  
            {
                client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json";
                var serialize = JsonConvert.SerializeObject(myParameters);
                string response = client.UploadString(urlSet, serialize);
                var result = JsonConvert.DeserializeObject(response);
                Console.WriteLine(result);
            }
        }
    }
}
