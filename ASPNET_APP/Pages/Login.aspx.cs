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
    public partial class Login1 : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        HttpCookie cookie = new HttpCookie("Cookie");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginAction_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid) 
                return;
            int num = -1;
            string error = repository.LoginUser(UsernameText.Text, PasswordText.Text, ref num);
            if (!string.IsNullOrEmpty(error))
            {
                LegendStatus.Text = "Вы неправильно ввели имя пользователя или пароль!";
                return;
            }
            cookie["UserId"] = num.ToString();
            Response.Cookies.Add(cookie);

            string url = "";
            string absolute_url = Request.Url.AbsoluteUri;
            if( absolute_url.IndexOf("Pages") == -1 )
                url = "Pages/";
            if (num == 1)
                Response.Redirect(url+"Competitions.aspx");
            else
                Response.Redirect(url+"JudgeCompetition.aspx");
        }
    }
}