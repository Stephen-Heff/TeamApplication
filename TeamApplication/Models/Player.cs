using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TeamApplication.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }

        public string PlayerName { get; set; }

        public string PlayerPosition { get; set; }
    }
}