<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCategory.aspx.cs" Inherits="ASPNET_APP.Pages.AdminCategories" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Просмотр категории</title>
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

    <div style="text-align: center" CssClass="center">
                <div align=right style="margin: 10px" >
                <asp:LinkButton ID="Exit" runat="server" Text="Выйти" Click="Exit_Click" 
                        onclick="Exit_Click" />
                </div>
            <b>Просмотр результатов в категории</b><br />
        <asp:Table ID="TableRating" runat="server"  CssClass="center"  Visible="true" style="width:80%" border="0" cellpadding="1" cellspacing="1"></asp:Table>
    </div>
    </form>
</body>
</html>
