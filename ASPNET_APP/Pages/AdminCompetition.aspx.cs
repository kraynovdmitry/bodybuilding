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
    public partial class AdminCompetition : System.Web.UI.Page
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
            {
                Response.Redirect("Login.aspx");
                return;
            }
            foreach (ASPNET_APP.Models.Category category in GetCategories())
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = category.Name;
                row.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                cell2.Text = category.Type.ToString();
                row.Cells.Add(cell2);
                HyperLink link = new HyperLink();
                link.Text = "Просмотр";
                link.NavigateUrl = "AdminCategory.aspx?cp=" + CurrentCompetition.ToString()
                    + "&ct=" + category.Id.ToString();
                TableCell cell3 = new TableCell();
                cell3.Controls.Add(link);
                row.Cells.Add(cell3);
                TableCategories.Rows.Add(row);
            }
        }

        protected IEnumerable<Category> GetCategories()
        {
            return repository.GetCategoriesByCompetition(CurrentCompetition);
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