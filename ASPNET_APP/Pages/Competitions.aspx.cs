using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPNET_APP.Models;
using ASPNET_APP.Models.Repository;

namespace ASPNET_APP.Pages
{
    public partial class Competitions : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookieReq = Request.Cookies["Cookie"];
            string id = cookieReq["UserId"];
            if( string.IsNullOrEmpty(id) || Convert.ToInt32(id) != 1 )
                Response.Redirect("Login.aspx");
        }

        protected IEnumerable<Competition> GetCompetitions()
        {
            return repository.Competitions;
        }

        protected void AddCompetitionButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCompetition.aspx");
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            var cookie = new HttpCookie("UserId")
            {
                Expires = DateTime.Now.AddDays(-1d)
            };
            Response.Cookies.Add(cookie);
            Response.Redirect("Login.aspx");
        }


    }
}