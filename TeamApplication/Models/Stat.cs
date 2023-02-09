using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamApplication.Models
{
    public class Stat
    {
        [Key]
        public int StatID { get; set; }


        //Adding foreign key for PlayerID
        [ForeignKey("Player")]
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }

 

        //Adding foreign key for PlayerID
        [ForeignKey("Team")]
        public int TeamIDScoredAgainst { get; set; }
        public virtual Team Team { get; set; }





    }


    public class StatDto
    {
        public int StatID { get; set; }

        public string PlayerName { get; set; }

        public string TeamScoredAgainst { get; set; }
        
    }


}