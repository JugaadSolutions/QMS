<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Portal.Admin.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style7 {
            width: 100%;
            border-collapse: collapse;
        }
        .auto-style8 {
            height: 48px;
        }
        .auto-style9 {
            height: 48px;
            text-align: center;
            width: 321px;
        }
        .auto-style11 {
            width: 450px;
        }
        .auto-style12 {
            height: 48px;
            width: 450px;
        }
        .auto-style13 {
            width: 321px;
        }
        .auto-style14 {
            color: #CC9900;
            font-weight: bold;
        }
        .auto-style15 {
            width: 321px;
            color: #CC9900;
            font-size: medium;
            font-weight: bold;
        }
        .auto-style16 {
            color: #CC9900;
            font-size: medium;
            font-weight: bold;
        }
        .auto-style17 {
            width: 321px;
            font-size: medium;
            font-weight: bold;
        }
        .auto-style18 {
            text-align: center;
            height: 23px;
        }
        .auto-style19 {
            color: #CC9900;
            font-size: medium;
            font-weight: bold;
            margin-bottom: 0px;
        }
        .auto-style20 {
            color: #CC9900;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="auto-style7">
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style15">Welcome to Admin...</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style17"><span class="auto-style14">Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style16" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12"></td>
            <td class="auto-style9">
                <asp:Button ID="Button1" runat="server" Text="Submit" BackColor="White" BorderColor="#CC9900" BorderStyle="Outset" BorderWidth="3px" CssClass="auto-style16" OnClick="Button1_Click" Width="222px" />
            </td>
            <td class="auto-style8">
            </td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style18" colspan="3"></td>
           
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style20"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Token No:</strong></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style19" Height="20px" Width="100px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" BackColor="White" BorderColor="#CC9900" BorderStyle="Outset" BorderWidth="3px" CssClass="auto-style19"  Text="Save" Width="89px" OnClick="Button2_Click" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
