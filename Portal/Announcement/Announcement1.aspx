<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Announcement1.aspx.cs" Inherits="Portal.Announcement.Announcement1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            height: 199px;
        }
        .auto-style11 {
        height: 295px;
        margin-top: 0em;
            width: 1400px;
        }
        .auto-style12 {
            text-align: center;
        }
    .auto-style13 {
        width: 238px;
    }
    .auto-style14 {
        width: 298px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
    <table class="auto-style11">
        <tr>
            <td class="auto-style13"></td>
            <td class="auto-style12">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"/>

                        <asp:Label ID="Label1" runat="server" text=" " ForeColor="#CC9900" Font-Bold="True" Font-Size="Medium" ></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" text=" " ForeColor="#CC9900" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        <br></br>
                        
                   </ContentTemplate>
                    
                    </asp:UpdatePanel>
                
            </td>
            <td class="auto-style14" ></td>
        </tr>
        <tr>
            <td class="auto-style13" ></td>
            <td class="auto-style12" >
            <asp:Button ID="Button1" runat="server" BackColor="#CC9900" BorderColor="#CC6600" BorderStyle="Outset" BorderWidth="3px" ForeColor="White" Height="40px" OnClick="Button1_Click" Text="New" Width="208px" />
            </td>
            <td class="auto-style14"></td>
        </tr>
        
    </table>
</asp:Content>
