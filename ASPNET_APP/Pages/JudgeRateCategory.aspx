<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JudgeRateCategory.aspx.cs" Inherits="ASPNET_APP.Pages.JudgeCategory" %>

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
<body vlink="#000000">
    <form id="form2" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="MainPanel" runat="server" Width="450px" CssClass="center" 
                BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
               <div align=right style="margin: 10px" >
                <asp:LinkButton ID="Exit" runat="server" Text="Выйти" Click="Exit_Click" 
                        onclick="Exit_Click" />
                </div>
        <asp:Label ID="Label1" runat="server" Text="Оценить категорию:"></asp:Label>
        <br />
            <asp:Table ID="TableAthletes" runat="server" Width="100%" > 
                <asp:TableRow>
                    <asp:TableCell>Номер</asp:TableCell>
                    <asp:TableCell>Спортсмен</asp:TableCell>
                    <asp:TableCell>Место</asp:TableCell>
                </asp:TableRow>
            </asp:Table>  
            <br />
            <asp:Button ID="SubmitChange" runat="server" OnClick="SubmitChange_Click" Text="Оценить категорию" /><br />
            <br />
            </asp:Panel>
        </div>
        <br /><br />


    </form>
</body>
</html>
