using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_APP.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Judge { get; set; }
        public int Category { get; set; }
        public int Athlete { get; set; }
        public int Place { get; set; }
    }
}