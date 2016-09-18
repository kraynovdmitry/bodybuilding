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
    public partial class AddCategory : System.Web.UI.Page
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

        protected void AddNewCategory_Click(object sender, EventArgs e)
        {
            string name = NewCategoryName.Text;
            int type = (Type1.Checked ? 1 : 2);
            Category a = new Category();
            a.Name = name;
            a.Type = type;
            a.N = 0;
            repository.SaveCategory(a);

            repository.SaveCompetitionCategory(CurrentCompetition, a.Id);

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