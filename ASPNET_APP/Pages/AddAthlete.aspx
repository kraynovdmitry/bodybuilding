﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAthlete.aspx.cs" Inherits="ASPNET_APP.Pages.AddAthlete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Добавить спротсмена</title>
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
            <b>Новый спортсмен</b><br />
                                <br />
                <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="height: 43px; width:30%">Фио:</td>
                        <td style="height: 43px; width: 70%">
                            <asp:TextBox ID="NewAthleteName" runat="server" Width="80%" />
                            <asp:RequiredFieldValidator ValidationGroup='valGroup1' ID="UsernameRequiredValidator" runat="server"
                                ErrorMessage="*" ControlToValidate="NewAthleteName" ForeColor="Red" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 43px; width:50%">Категории:</td>
                        <td style="height: 43px; width:50%">


                        <asp:CheckBoxList runat="server" ID="ListCategories" RepeatDirection="Vertical" TextAlign="Left">
                        </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="AddNewAthlete" ValidationGroup='valGroup1' runat="server" OnClick="AddNewAthlete_Click" Text="Добавить спортсмена" /><br />
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
