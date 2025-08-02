<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegSuccess.aspx.cs" Inherits="Hotel_Management.RegSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles/Regsuccess.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="welcome">
        <p>Successful Registration !!</p>
    </div>

    <form  id="regsucc" runat="server">
        <div class="regsuc">
 <p>Congratulations Registration Successfull !!</p> 
  <p>Now Login to your DashBoard and Enjoy the Services !!</p> 
    <asp:Button CssClass="btn" Text="Login Here " ID="login" runat="server" OnClick="login_Click" />
            </div>
        </form>
</asp:Content>
