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
    public partial class JudgeCompetition : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        int currentJudge = 0;
        int currentCompetition = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookieReq = Request.Cookies["Cookie"];
            string id = cookieReq["UserId"];
            if (string.IsNullOrEmpty(id))
            {
                Response.Redirect("Login.aspx");
                return;
            }
            currentJudge = Convert.ToInt32( id );
            currentCompetition = repository.GetCompetitionByJudge(currentJudge);

            var list = repository.GetCategoriesByCompetition(currentCompetition).ToList();
            foreach (ASPNET_APP.Models.Category category in list)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = category.Name;
                row.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                cell2.Text = category.Type.ToString();
                row.Cells.Add(cell2);
                HyperLink link = new HyperLink();

                int tp = 0;
                if (repository.GetRating(category.Id, currentJudge))
                {
                    link.Text = "Просмотр";
                    tp = 1;
                }
                else
                {
                    link.Text = "Оценить";
                    tp = 0;
                }
                link.NavigateUrl = "JudgeRateCategory.aspx?cp=" + currentCompetition.ToString()
                    + "&ct=" + category.Id.ToString() + "&tp=" + tp.ToString();
                TableCell cell3 = new TableCell();
                cell3.Controls.Add(link);
                row.Cells.Add(cell3);
                TableCategories.Rows.Add(row);
            }
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