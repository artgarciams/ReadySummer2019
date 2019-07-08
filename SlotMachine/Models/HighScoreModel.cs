using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlotMachine.Models
{
    public class HighScoreModel
    {
        public int HighScore { get; set; }

        public string HighUserName { get; set; }

        public string Ipaddress { get; set; }

        public string  City { get; set; }
    }
}