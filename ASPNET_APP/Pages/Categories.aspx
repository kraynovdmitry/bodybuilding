<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="ASPNET_APP.Pages.Listing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Соревнование</title>
    <style>
        .center {
            margin: 0 auto;
            margin-top:15px;
        }
       A {
        color: #0000FF; /* Цвет обычной ссылки */
       }
       A:visited {
        color: #0000FF; /* Цвет посещенной ссылки */
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">

       <div style="text-align: center">

            <asp:Panel ID="MainPanel" runat="server" Width="750px" CssClass="center" 
                BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                <div align=right style="margin: 10px" >
                <asp:LinkButton ID="Exit" runat="server" Text="Выйти" Click="Exit_Click" 
                        onclick="Exit_Click" />
                </div>
            <b>Добавление нового соревнования</b><br />
                                <br />
                <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="height: 43px; width:33%">
                            <asp:Button ID="AddCategoryButton" runat="server" onclick="AddCategoryButton_Click" 
                                Text="Добавить новую категорию" Width="220px" />
                        </td>
                        <td style="height: 43px; width: 33%">
                            <asp:Button ID="AddJudgeButton" runat="server" onclick="AddJudgeButton_Click" 
                                Text="Добавить нового судью" Width="220px" />
                        </td>
                        <td style="height: 43px; width: 33%">
                            <asp:Button ID="AddAthleteButton" runat="server" onclick="AddAthleteButton_Click" 
                                Text="Добавить нового спортсмена" Width="220px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 43px; width:33%">
                            Список категорий:
                        </td>
                        <td style="height: 43px; width: 33%">
                            Список судей:
                        </td>
                        <td style="height: 43px; width: 33%">
                            Список спортсменов:
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 43px; width:33%">
                        <%
                            foreach (ASPNET_APP.Models.Category category in GetCategories())
                            {
                                Response.Write(String.Format(@"
                                    <div class='item'>
                                        {0},
                                        {1},
                                        {2}
                                    </div>",
                                    category.Name, category.Type, category.N));
                            }
                        %>    
                        </td>
                        <td style="height: 43px; width:33%">
                            <%
                                foreach (ASPNET_APP.Models.Judge judge in GetJudges())
                                {
                                    Response.Write(String.Format(@"
                                        <div class='item'>
                                            {0},
                                            {1},
                                            {2}
                                        </div>",
                                        judge.Name, judge.Login, judge.Password));
                                }
                            %>    
                        </td>
                        <td style="height: 43px; width:33%">
                            <%
                                foreach (ASPNET_APP.Models.Athlete athlete in GetAthletes())
                                {
                                    Response.Write(String.Format(@"
                                        <div class='item'>
                                            <a href='AddAthlete.aspx?cp={1}&at={2}'>{0}</a>
                                        </div>",
                                        athlete.Name, CurrentCompetition, athlete.Id));
                                }
                            %>   
                        </td>
                    </tr>
                </table>
                <asp:Button ID="SaveCompetition" runat="server" onclick="SaveCompetition_Click" 
                                Text="Начать соревнование" Width="220px" />
                <br /><br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
