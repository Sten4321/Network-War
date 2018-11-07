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
    struct ClientStruct
    {
        public TcpClient client; // client to write to

        //What team are they on?
        public PlayerTeam? Team { get; set; } //Nullable enum (if it's not assigned, returns null)

        public ClientStruct(TcpClient _client)
        {
            Team = null;
            client = _client;
        }
    }
}
