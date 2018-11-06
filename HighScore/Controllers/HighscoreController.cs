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
        // GET: api/Highscore
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Highscore/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Highscore
        public void Post([FromBody]string value)
        {
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
