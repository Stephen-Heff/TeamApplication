using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamApplication.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string TeamCity { get; set; }
        public string TeamCoachName { get; set; }
    }


    public class TeamDto
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string TeamCity { get; set; }
        public string TeamCoachName { get; set; }
    }





}