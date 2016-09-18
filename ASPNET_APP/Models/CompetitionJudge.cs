using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_APP.Models
{
    public class CompetitionJudge
    {
        public int Id { get; set; }
        public int Competition { get; set; }
        public int Judge { get; set; }
    }
}