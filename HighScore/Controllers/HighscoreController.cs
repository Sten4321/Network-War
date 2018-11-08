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
        int number;
        List<string> highScore;
        int addScoreToString;

        // GET: api/Highscore
        public IEnumerable<string> Get()
        {
            addScoreToString = 0;
            Database._Instance.ReadHighScoreList("Select * from HighScore order by score desc");
            highScore = new List<string>();
            highScore.Add("<HighScore list of most winning hero combo>!,");
            foreach (string s in Database._Instance.User)
            {
                string t = "Wins:  "+Database._Instance.Score.ElementAt(addScoreToString)+"... With Combo......<"+s+">";
                addScoreToString++;
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
            bool breaker = false;
            foreach (int i in Database._Instance.Score)
            {
                number = i;
                number++;
                foreach (string s in Database._Instance.User)
                {
                    if (s == value)
                    {
                        breaker = true;
                        Database._Instance.UpdateTable("UPDATE Highscore SET score = "+number+" WHERE user = '"+s+"';");
                        break;
                    }
                    
                }
                
                if (breaker)
                {
                    break;
                }
            }
            if (breaker == false)
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
