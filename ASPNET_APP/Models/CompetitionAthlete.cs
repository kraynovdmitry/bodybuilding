using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_APP.Models
{
    public class CompetitionAthlete
    {
        public int Id { get; set; }
        public int Competition { get; set; }
        public int Athlete { get; set; }
    }
}