using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SQLite;
using System.Text;

namespace HighScore.Controllers
{
    public class HighscoreController : ApiController
    {
        List<string> highScore;

        // GET: api/Highscore
        public IEnumerable<string> Get()
        {
            Database._Instance.ReadHighScoreList("Select * from HighScore order by score desc");
            highScore = new List<string>();
            highScore.Add("<HighScore list of most winning hero combo>!,");
            foreach (KeyValuePair<string,int> s in Database._Instance.DatabaseData)
            {
                string t = "Wins:  "+s.Value+"... With Combo......<"+s.Key+">";
                highScore.Add(t);
            }
            return highScore;
        }
        //order by score desc

        // GET: api/Highscore/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Highscore
        public void Post([FromBody]string value)
        {
            Database._Instance.CreateDatabase();
            Database._Instance.ReadHighScoreList("Select * from HighScore");
            bool create = true;
            foreach (KeyValuePair<string,int> i in Database._Instance.DatabaseData)
            {

                if (value == i.Key)
                {
                    create = false;
                    int score = i.Value;
                    score++;
                    Database._Instance.UpdateTable("UPDATE Highscore SET score = "+score+" WHERE user = '"+i.Key+"';");
                    break;
                }
            }
            if (create == true)
            {
                Database._Instance.AddHighScore(value, 1);
            }
            
            
        }

        // PUT: api/Highscore/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Highscore/5
        public void Delete(int id)
        {
        }
    }
}
