using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FirstSemesterExamProject
{
    /// <summary>
    /// Struct that contains information and the client who sent it.
    /// </summary>
    struct Data
    {
        public TcpClient client;
        public string information;

        /// <summary>
        /// Creates a Struct that contains information and the client who sent it.
        /// </summary>
        /// <param name="_data"> the information sent from the client</param>
        /// <param name="_sender">the client who sent the infornation</param>
        public Data (string _data, TcpClient _sender)
        {
            client = _sender;
            information = _data;
        }
    }
}
