<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Competitions.aspx.cs" Inherits="ASPNET_APP.Pages.Competitions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Соревнования</title>
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
<body  vlink="#000000">
    <form id="form2" runat="server">

        <div style="text-align: center">

            <asp:Panel ID="MainPanel" runat="server" Width="450px" CssClass="center" 
                BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                <div align=right style="margin: 10px" >
                <asp:LinkButton ID="Exit" runat="server" Text="Выйти" Click="Exit_Click" 
                        onclick="Exit_Click" />
                </div>
            <b>Пожалуйста выберете или создайте соревнование</b><br />
                <br />
        <asp:Button ID="AddCompetitionButton" runat="server" 
            Text="Добавить новое соревнование" OnClick="AddCompetitionButton_Click" /><br /> <br />
        <asp:Label ID="Label1" runat="server" Text="Список соревнований:"></asp:Label>
        <br />
            <%
                foreach (ASPNET_APP.Models.Competition c in GetCompetitions())
                {
                    if (c.State == 0)
                    {
                        Response.Write(String.Format(@"
                            <div class='item'>
                                <a href='Categories.aspx?cp={1}'>{0}</a>
                            </div>",
                            c.Name, c.Id));
                    }
                    else
                    {
                        Response.Write(String.Format(@"
                            <div class='item'>
                                <a href='AdminCompetition.aspx?cp={1}'>{0}</a>
                            </div>",
                            c.Name, c.Id));                            
                    }
                }
            %>    
            <br /> 
            </asp:Panel>
        </div>
        <br /><br />


    </form>
</body>







</html>
