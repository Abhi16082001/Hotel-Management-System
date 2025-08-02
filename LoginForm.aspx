<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Hotel_Management.LoginForm" %>
<%@ MasterType VirtualPath="~/Site1.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles/login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="LoginPage">
        <h1>Login Page</h1>
    </div>

    <div>
        <form id="lgfrm" runat="server">
            <asp:Label ID="usrnm" runat="server" Text="Username : "> </asp:Label> <br />
            <asp:TextBox CssClass="txtbx" ID="username" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username" Display="Dynamic" ErrorMessage="Username is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="pwd" runat="server" Text="Password :">  </asp:Label><br />
            <asp:TextBox CssClass="txtbx" ID="password" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password" Display="Dynamic" ErrorMessage="Password is Required !" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Button CssClass="btn" ID="Login" runat="server" Text="Login" OnClick="Login_Click" />
            <br />
            <br />
        <asp:Label ID="excpn" runat="server" ForeColor="#FF6600" Text="Label" Visible="False"></asp:Label>
        </form>
    </div>

</asp:Content>
