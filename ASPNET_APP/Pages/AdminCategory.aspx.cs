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
    public partial class AdminCategories : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected int CurrentCompetition
        {
            get
            {
                int cp;
                return int.TryParse(Request.QueryString["cp"], out cp) ? cp : -1;
            }
        }

        protected int CurrentCategory
        {
            get
            {
                int ct;
                return int.TryParse(Request.QueryString["ct"], out ct) ? ct : -1;
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

            bool not_end = false;

            var arr_j = repository.GetJudgesByCompetition(CurrentCompetition).ToList();
            var arr_a = repository.GetAthletesByCategory(CurrentCategory).ToList();

            //Add the Headers
            TableRow row = new TableRow();
            TableHeaderCell first = new TableHeaderCell();
            first.Text = "ФИО спортсмена";
            row.Cells.Add(first);
            foreach (Judge j in arr_j)
            {
                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.Text = "Оценка судьи: " + j.Name;
                row.Cells.Add(headerCell);
            }
            TableHeaderCell h_sum = new TableHeaderCell();
            h_sum.Text = "Сумма - max - min";
            row.Cells.Add(h_sum);
            TableHeaderCell h_place = new TableHeaderCell();
            h_place.Text = "Место";
            row.Cells.Add(h_place);
            row.Height = 30;
            TableRating.Rows.Add(row);

            foreach (Athlete a in arr_a)
            {
                row = new TableRow();
                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.Text = a.Name;
                row.Cells.Add(headerCell);
                foreach (Judge j in arr_j)
                {
                    TableCell cell = new TableCell();
                    int rating = repository.GetRating( CurrentCategory, a.Id, j.Id);
                    if (rating == -1)
                    {
                        cell.Text = "-";
                        not_end = true;
                    }
                    else
                        cell.Text = rating.ToString();
                    row.Cells.Add(cell);
                }
                TableHeaderCell sum = new TableHeaderCell();
                sum.Text = "-";
                row.Cells.Add(sum);
                TableHeaderCell place = new TableHeaderCell();
                place.Text = "-";
                row.Cells.Add(place);
                row.Height = 30;
                TableRating.Rows.Add(row);
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