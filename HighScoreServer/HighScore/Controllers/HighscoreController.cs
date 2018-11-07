using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HighScore.Controllers
{
    public class HighscoreController : ApiController
    {
        List<string> Score = new List<string>();

        // GET: api/Highscore
        public IEnumerable<string> Get()
        {
            return Score;
        }

        // GET: api/Highscore/5
        public string Get(int id)
        {
            return Score.ElementAt(id);
        }

        // POST: api/Highscore
        public void Post([FromBody]string value)
        {
            Score.Add(value);
        }

        // PUT: api/Highscore/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Highscore/5
        public void Delete(int id)
        {
            Score.Remove(Score.ElementAt(id));
        }
    }
}
