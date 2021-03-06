﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ASPNET_APP.Pages.Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Войти в систему</title>
    <style>
        .center {
            margin: 0 auto;
            margin-top:15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <b>Пожалуйста, войдите в систему</b><br />
            <asp:Panel ID="MainPanel" runat="server" Width="450px" CssClass="center" 
                BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                <br />
                <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="height: 43px; width:30%; vertical-align: top">Имя пользователя:</td>
                        <td style="height: 43px; width: 70%">
                            <asp:TextBox ID="UsernameText" runat="server" Width="80%" />
                            <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server"
                                ErrorMessage="*" ControlToValidate="UsernameText" ForeColor="Red" />
                            <br />
                            <asp:RegularExpressionValidator
                                ID="UsernameValidator" runat="server"
                                ControlToValidate="UsernameText"
                                ErrorMessage="Некорректное имя пользователя"
                                ValidationExpression="[\w| ]*"
                                ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 30%; vertical-align: top">Пароль:</td>
                        <td style="height: 26px; width: 70%">
                            <asp:TextBox ID="PasswordText" runat="server" Width="80%" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="PwdRequiredValidator"
                                runat="server" ErrorMessage="*"
                                ControlToValidate="PasswordText" ForeColor="Red" />
                            <br />
                            <asp:RegularExpressionValidator ID="PwdValidator"
                                runat="server" ControlToValidate="PasswordText"
                                ErrorMessage="Некорректный пароль"
                                ValidationExpression='[\w| !"§$%&amp;/()=\-?\*]*'
                                ForeColor="Red" />
                        </td>
                    </tr>
                </table>

                <asp:Button ID="LoginAction" runat="server" OnClick="LoginAction_Click" Text="Войти" /><br />
                <asp:Label ID="LegendStatus" runat="server" EnableViewState="false" Text="" />
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>