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
    public partial class AddJudge : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookieReq = Request.Cookies["Cookie"];
            string id = cookieReq["UserId"];
            if (string.IsNullOrEmpty(id) || Convert.ToInt32(id) != 1)
                Response.Redirect("Login.aspx");
        }

        protected void AddJudgeButton_Click(object sender, EventArgs e)
        {
            string name = NewJudgeName.Text;
            string login = NewJudgeLogin.Text;
            string password = NewJudgePassword.Text;

            Judge a = new Judge();
            a.Name = name;
            a.Login = login;
            a.Password = password;
            repository.SaveJudge(a);

            repository.SaveCompetitionJudge(CurrentCompetition, a.Id);

            Response.Redirect("Categories.aspx" + "?cp=" + CurrentCompetition.ToString());
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