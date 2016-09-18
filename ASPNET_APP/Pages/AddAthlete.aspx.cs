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
    public partial class AddAthlete : System.Web.UI.Page
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

        protected int CurrentAthlete
        {
            get
            {
                int at;
                return int.TryParse(Request.QueryString["at"], out at) ? at : -1;
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
            if (Page.IsPostBack)
                return;

            if (NewAthleteName.Text == "")
            {
                var cur_athlete = repository.GetAthleteById(CurrentAthlete);
                if (cur_athlete.Id != -1)
                    NewAthleteName.Text = cur_athlete.Name;
            }
            Dictionary<int, bool> m = new Dictionary<int, bool>();
            if (CurrentAthlete > -1)
            {
                foreach (ASPNET_APP.Models.AthleteCategory a in repository.AthleteCategories)
                {
                    if (a.Athlete != CurrentAthlete)
                        continue;
                    m.Add(a.Category, true);
                }
            }

            ListCategories.Items.Clear();
            foreach (ASPNET_APP.Models.Category category in GetCategories())
            {
                ListItem li = new ListItem(category.Name, category.Id.ToString(), true);
                li.Selected = m.ContainsKey(category.Id);

                ListCategories.Items.Add(li);
            }

        }

        protected IEnumerable<Category> GetCategories()
        {
            return repository.GetCategoriesByCompetition(CurrentCompetition);
        }

        protected void AddNewAthlete_Click(object sender, EventArgs e)
        {
            string name = NewAthleteName.Text;

            Athlete a = repository.GetAthleteById(CurrentAthlete);
            a.Name = name;
            repository.SaveAthlete(a);

            repository.SaveCompetitionAthlete( CurrentCompetition, a.Id );

            foreach (ListItem li in ListCategories.Items)
            {
                if( li.Selected )
                    repository.SaveAthleteCategory(a.Id, Convert.ToInt32(li.Value));
                else
                    repository.DeleteAthleteCategory(a.Id, Convert.ToInt32(li.Value));
            }

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