using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class Client
    {
        public TcpClient SerClient { get; set; }
        public string RegiNum { get; set; }
        public int RoomNum { get; set; }

        public Boolean Main { get; set; }

        public Boolean Room { get; set; }
    }
}
