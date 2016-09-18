using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_APP.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        public string Name { get; set; }

        static public void AddAthlete(string s)
        {
            Athlete a = new Athlete();
            a.Name = s;

        }
    }
}