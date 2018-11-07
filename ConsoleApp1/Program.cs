using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;

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


        //Set
        static string url = "http://localhost:59787/api/Highscore";
        static string myParameters = "Test";

        public static void Testc()
        {
            string insertLine = "http://localhost:51286/api/Highscore";
            var client = new HttpClient();
            var result = client.GetStringAsync(insertLine);
            Console.WriteLine(result);
        }

        public static void GetAllEventData() //Get All Events Records  
        {
            using (var client = new System.Net.WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:59787/api/Highscore"); //URI  
                Console.WriteLine(Environment.NewLine + result);
            }
        }

        public static void SetAllEventData() //Get All Events Records  
        {
            using (var client = new System.Net.WebClient()) //WebClient  
            {
                client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = client.UploadString(url,"Post", myParameters);
            }
        }
    }
}
