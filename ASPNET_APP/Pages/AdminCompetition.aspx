<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCompetition.aspx.cs" Inherits="ASPNET_APP.Pages.AdminCompetition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
<body vlink="#000000">
    <form id="form2" runat="server">
        <div style="text-align: center">

            <asp:Panel ID="MainPanel" runat="server" Width="450px" CssClass="center" 
                BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                <div align=right style="margin: 10px" >
                <asp:LinkButton ID="Exit" runat="server" Text="Выйти" Click="Exit_Click" 
                        onclick="Exit_Click" />
                </div>
            <b>Просмотр категорий соревнования</b><br />
        <br />
            <asp:Table ID="TableCategories" runat="server" Width="100%" > 
                <asp:TableRow>
                    <asp:TableCell>Категория</asp:TableCell>
                    <asp:TableCell>Тур</asp:TableCell>
                    <asp:TableCell>Ссылка</asp:TableCell>
                </asp:TableRow>
            </asp:Table>  
            <br />
            </asp:Panel>
        </div>
        <br /><br />


    </form>
</body>
</html>
