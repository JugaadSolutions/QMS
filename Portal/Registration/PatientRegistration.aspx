<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientRegistration.aspx.cs" Inherits="Portal.Registration.PatientRegistration" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
     <%-- <script type="text/javascript">
          $("#Button1").click(function RegisterPatient() {
              $.ajax({
                  Type: "POST",
                  url: "~/Services/QMSWebService.asmx/RegisterPatient",
                  data: { name: "<%= TextBox1.Text%>", id: "<%= TextBox1.Text%>" },
                  Success: function (data) {
                      $("#ShowToken").html(data);
                  },
                  datatype:"Text",
                  error: onerror
              });
          
          });
          
                

          function ShowToken(data) {
              
              var tokenNo = '<%= Token%>';
              alert('Patient Registration Successful. \n Token No-' + tokenNo);
              
          };
     </script>--%>
    <table class="auto-style3">
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style4" colspan="2" style="color: #CC9900"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Patient Registration</strong></td>
        <td class="auto-style12">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/AdminLogin.aspx" CssClass="auto-style15" Font-Bold="True" ForeColor="#009933">AdminLogin</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="auto-style9"></td>
        <td class="auto-style7">
            <strong>Patient Name:</strong></td>
        <td class="auto-style10">
            <asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator" ValidateRequestMode="Enabled"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style13"> <strong>Id:</strong></td>
        <td class="auto-style11">
            <asp:TextBox ID="TextBox2" runat="server" Width="180px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style12" colspan="2">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" BackColor="#CC9900" BorderColor="#CC6600" BorderStyle="Outset" BorderWidth="3px"
                 ForeColor="White" Height="40px"  Text="Register" Width="208px" OnClick="Button1_Click" />
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td class="auto-style11">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
    
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
    .auto-style3 {
        width: 100%;
        border-collapse: collapse;
        height: 144px;
        margin-top: 0em;
        background-color: #FFFFCC;
    }
        .auto-style4 {
            text-align: center;
            font-size: xx-large;
        }
        .auto-style5 {
            width: 192px;
        }
        .auto-style6 {
            height: 47px;
        }
        .auto-style7 {
            width: 1155px;
            height: 47px;
        color: #000000;
        font-size: large;
        text-align: right;
    }
        .auto-style8 {
            width: 271px;
        }
        .auto-style9 {
            width: 271px;
            height: 47px;
        }
        .auto-style10 {
            height: 47px;
            width: 22px;
        }
        .auto-style11 {
            width: 22px;
        }
        .auto-style12 {
            text-align: center;
        }
    .auto-style13 {
        width: 1155px;
        color: #000000;
        font-size: large;
        text-align: right;
    }
        .auto-style14 {
            width: 1155px;
            height: 300px;
        }
        .auto-style15 {
            font-size: small;
            color: #CC9900;
        }
    </style>

</asp:Content>

