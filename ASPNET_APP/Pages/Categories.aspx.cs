using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPNET_APP.Models.Repository;
using ASPNET_APP.Models;

namespace ASPNET_APP.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected int CurrentCompetition
        {
            get
            {
                int ct;
                return int.TryParse(Request.QueryString["cp"], out ct) ? ct : 1;
            }
        }

        protected IEnumerable<Category> GetCategories()
        {
            return repository.GetCategoriesByCompetition(CurrentCompetition);
        }

        protected IEnumerable<Judge> GetJudges()
        {
            return repository.GetJudgesByCompetition(CurrentCompetition);
        }

        protected IEnumerable<Athlete> GetAthletes()
        {
            return repository.GetAthletesByCompetition(CurrentCompetition);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookieReq = Request.Cookies["Cookie"];
            string id = cookieReq["UserId"];
            if (string.IsNullOrEmpty(id) || Convert.ToInt32(id) != 1)
            {
                Response.Redirect("Login.aspx");
                return;
            }
        }

        protected void AddCategoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx"+"?cp="+CurrentCompetition.ToString());
        }

        protected void AddJudgeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddJudge.aspx" + "?cp=" + CurrentCompetition.ToString());
        }

        protected void AddAthleteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAthlete.aspx" + "?cp=" + CurrentCompetition.ToString());
        }

        protected void SaveCompetition_Click(object sender, EventArgs e)
        {
            Competition comp = repository.GetCompetitionById(CurrentCompetition);
            comp.State = 1;
            repository.SaveCompetition(comp);
            Response.Redirect("AdminCompetition.aspx" + "?cp=" + CurrentCompetition.ToString());
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