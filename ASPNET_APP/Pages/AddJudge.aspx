<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddJudge.aspx.cs" Inherits="ASPNET_APP.Pages.AddJudge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Добавить судью</title>
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
            <b>Новый судья</b><br />
                                <br />
                <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="height: 43px; width:30%">Фио:</td>
                        <td style="height: 43px; width: 70%">
                            <asp:TextBox ID="NewJudgeName" runat="server" Width="80%" />
                            <asp:RequiredFieldValidator ValidationGroup='valGroup1' ID="UsernameRequiredValidator" runat="server"
                                ErrorMessage="*" ControlToValidate="NewJudgeName" ForeColor="Red" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 43px; width:30%">Логин:</td>
                        <td style="height: 43px; width: 70%">
                            <asp:TextBox ID="NewJudgeLogin" runat="server" Width="80%" />
                            <asp:RequiredFieldValidator ValidationGroup='valGroup1' ID="RequiredFieldValidator1" runat="server"
                                ErrorMessage="*" ControlToValidate="NewJudgeLogin" ForeColor="Red" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 43px; width:30%">Пароль:</td>
                        <td style="height: 43px; width: 70%">
                            <asp:TextBox ID="NewJudgePassword" runat="server" Width="80%" />
                            <asp:RequiredFieldValidator ValidationGroup='valGroup1' ID="RequiredFieldValidator2" runat="server"
                                ErrorMessage="*" ControlToValidate="NewJudgePassword" ForeColor="Red" />
                            <br />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="AddJudgeButton" ValidationGroup='valGroup1' runat="server" OnClick="AddJudgeButton_Click" Text="Добавить судью" /><br />
                <br /><br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
