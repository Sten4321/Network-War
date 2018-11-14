using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FirstSemesterExamProject
{

    /// <summary>
    /// Contains the necessary information required for each client
    /// </summary>
    public class ClientObject
    {
        public TcpClient tcpClient; // client to write to

        //is client ready to start a game?
        public bool ready;

        public bool isAlive = true;

        //What team are they on?
        public PlayerTeam? Team { get; set; } //Nullable enum (if it's not assigned, returns null)
        public bool clientsTurn;

        public ClientObject(TcpClient _client)
        {
            Team = null;
            tcpClient = _client;
            ready = false;
            clientsTurn = false;
        }

        public void SetReady()
        {
            ready = true;
        }
    }
}
