using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FirstSemesterExamProject
{
    class HighscoreConnection
    {
        //Get
        string serverUrl = "http://localhost:59787/api/Highscore";

        private List<string> resultList;

        private static HighscoreConnection DB_instance;

        private HighscoreConnection()
        {
        }

        //Singleton
        static public HighscoreConnection _Instance
        {
            get
            {
                if (DB_instance == null)
                {
                    DB_instance = new HighscoreConnection();
                }
                return DB_instance;
            }
        }

        //<summary>
        //Do a Foreach to get the entire list
        //</summary>
        public List<string> GetAllEventData() //Get All Events Records  
        {
            try
            {
                resultList = new List<string>();
                using (var client = new System.Net.WebClient()) //WebClient  
                {
                    client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json"; //Content-Type  
                    var result = client.DownloadString(serverUrl);
                    foreach (string s in result.Split(','))
                    {
                        resultList.Add(s);
                    }
                }
                
            }
            catch (Exception e){ Console.WriteLine("No connection to the database, the highscore wont be shown!"); }

            return resultList;
        }

        //<summary>
        //Put the classes used string as input
        //</summary>
        public void SetAllEventData(string myParameters) //Get All Events Records  
        {
            try
            {
                using (var client = new System.Net.WebClient()) //WebClient  
                {
                    client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json";
                    var serialize = JsonConvert.SerializeObject(myParameters);
                    string response = client.UploadString(serverUrl, serialize);
                    var result = JsonConvert.DeserializeObject(response);
                }
            }
            catch (Exception e){ Console.WriteLine("No database is connected!");}
            
        }

        public void SetTest()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(serverUrl);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            string sContentType = "application/json";

            JObject oJsonObject = new JObject();

            oJsonObject.Add("ReferenceId", "a123");

            HttpClient oHttpClient = new HttpClient();
            var oTaskPostAsync = oHttpClient.PostAsync(serverUrl, new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType));
        }
    }
}
