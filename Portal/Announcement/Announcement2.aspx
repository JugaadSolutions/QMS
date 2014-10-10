<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Announcement2.aspx.cs" Inherits="Portal.Announcement.Announcement2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style7 {
            width: 1400px;
            height: 300px;
            margin-top: 0.2em;
        }
        .auto-style8 {
            text-align: center;
        }
        .auto-style9 {
            width: 389px;
        }
        .auto-style10 {
            text-align: left;
        }
        .auto-style11 {
            font-size: large;
        }
        .auto-style12 {
            font-size: medium;
            text-align: right;
            width: 160px;
        }
        .auto-style13 {
            width: 160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <table class="auto-style7">
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td colspan="2" class="auto-style10"><strong style="color: #CC9900">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style11">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Announcement</span></strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style12"><strong>Token No.</strong></td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9" >&nbsp;</td>
                <td class="auto-style12"><strong>Patient ID:</strong></td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9" >&nbsp;</td>
                <td class="auto-style12"><strong>Patient Name:</strong></td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9" >&nbsp;</td>
                <td class="auto-style12"><strong>Type:</strong></td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="4" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" BackColor="#CC9900" BorderStyle="Outset" BorderWidth="3px" Text="CALL" OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" BackColor="#CC9900" BorderStyle="Outset" BorderWidth="3px" Text="MISSED" OnClick="Button2_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" BackColor="#CC9900" BorderStyle="Outset" BorderWidth="3px" Text="DONE" OnClick="Button3_Click" />
                </td>
            </tr>
            
        </table>
    
</asp:Content>
