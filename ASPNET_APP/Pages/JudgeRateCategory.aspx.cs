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
    public partial class JudgeCategory : System.Web.UI.Page
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

        protected int TypeRate
        {
            get
            {
                int ct;
                return int.TryParse(Request.QueryString["tp"], out ct) ? ct : 0;
            }
        }

        int currentJudge = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookieReq = Request.Cookies["Cookie"];
            string id = cookieReq["UserId"];
            if (string.IsNullOrEmpty(id))
            {
                Response.Redirect("Login.aspx");
                return;
            }
            currentJudge = Convert.ToInt32(id);
            if (TypeRate == 1)
                SubmitChange.Text = "Назад";

            var list = repository.GetAthletesByCategory(CurrentCategory).ToList();
            int n = list.Count();
            int place = 1;
            foreach (ASPNET_APP.Models.Athlete athlete in list)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = athlete.Id.ToString();
                row.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                cell2.Text = athlete.Name;
                row.Cells.Add(cell2);

                int rating = repository.GetRating(CurrentCategory, athlete.Id, currentJudge);
                string str_rating;
                if (rating == -1)
                    str_rating = "";
                else
                    str_rating = rating.ToString();

                TableCell cell3 = new TableCell();
                TextBox x = new TextBox()
                {
                    ID = "athlete" + athlete.Id.ToString(),
                    Text = str_rating
                };
                if (TypeRate == 1)
                    x.Enabled = false;
                cell3.Controls.Add(x);
                row.Cells.Add(cell3);
                TableAthletes.Rows.Add(row);
                place++;
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

        protected void SubmitChange_Click(object sender, EventArgs e)
        {
            if( TypeRate == 1 )
            {
                Response.Redirect("JudgeCompetition.aspx");
                return;
            }

            var list = repository.GetAthletesByCategory(CurrentCategory).ToList();
            foreach (TableRow row in TableAthletes.Rows)
            {
                string id_athlete = row.Cells[0].Text;
                if (id_athlete == "Номер")
                    continue;
                TextBox place = TableAthletes.FindControl("athlete"+id_athlete) as TextBox;


                Rating r = new Rating();
                r.Athlete = Convert.ToInt32( id_athlete );
                r.Category = CurrentCategory;
                r.Judge = currentJudge;
                r.Place = Convert.ToInt32(place.Text);
                repository.SaveRating(r);
            }
            Response.Redirect("JudgeCompetition.aspx");
        }
    }
}