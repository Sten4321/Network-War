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
            
        }

        //Get
        static string url = "http://localhost:59787/api/Highscore";

        private static List<string> resultList;

        public static List<string> ResultList { get => resultList; set => resultList = value; }

        public static List<string> GetAllEventData() //Get All Events Records  
        {
            ResultList = new List<string>();
            using (var client = new System.Net.WebClient()) //WebClient  
            {
                client.Headers[System.Net.HttpRequestHeader.ContentType] ="application/json"; //Content-Type  
                var result = client.DownloadString(url);
                foreach (string s in result.Split(','))
                {
                    ResultList.Add(s);
                }
            }
            return ResultList;
        }

        public static void SetAllEventData(string myParameters) //Get All Events Records  
        {
            using (var client = new System.Net.WebClient()) //WebClient  
            {
                client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json";
                var serialize = JsonConvert.SerializeObject(myParameters);
                string response = client.UploadString(url, serialize);
                var result = JsonConvert.DeserializeObject(response);
            }
        }
    }
}
