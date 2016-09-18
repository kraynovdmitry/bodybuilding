<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCompetition.aspx.cs" Inherits="ASPNET_APP.Pages.AddCompetition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Добавить соревнование</title>
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

            <asp:Panel ID="MainPanel" runat="server" Width="450px" CssClass="center" 
                BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                <div align=right style="margin: 10px" >
                <asp:LinkButton ID="Exit" runat="server" Text="Выйти" Click="Exit_Click" 
                        onclick="Exit_Click" />
                </div>
            <b>Добавление нового соревнования</b><br />
                                <br />
                <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="height: 43px; width:30%">Название:</td>
                        <td style="height: 43px; width: 70%">
                            <asp:TextBox ID="CompetitionText" runat="server" Width="80%" />
                            <asp:RequiredFieldValidator ID="UsernameRequiredValidator"  ValidationGroup='valGroup1' runat="server"
                                ErrorMessage="*" ControlToValidate="CompetitionText" ForeColor="Red" />
                            <br />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="CompetitionAddButton" ValidationGroup='valGroup1' runat="server" OnClick="CompetitionAddButton_Click" Text="Добавить соревнование" /><br />
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
