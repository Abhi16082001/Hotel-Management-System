<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Hotel_Management.Home" %>

<%@ MasterType VirtualPath="~/Site1.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles/home.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="welcome">

        <p>Welcome to HOTEL MANAGEMENT SYSTEM !!</p>
        <p>Enter ADMIN details and Login !</p>

    </div>

    <div>
        <form id="loginform" runat="server">
            <div id="lgfrm">
                <asp:Label  ID="usrnm" runat="server" Text="Username : "> </asp:Label><br />
                <asp:TextBox CssClass="txtbx" ID="username" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username" Display="Dynamic" ErrorMessage="Username is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:Label  ID="pwd" runat="server" Text="Password :">  </asp:Label><br />
                <asp:TextBox CssClass="txtbx" ID="password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password" Display="Dynamic" ErrorMessage="Password is Required !" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:Button CssClass="btn" ID="Login" runat="server" Text="Login" OnClick="Login_Click" />
                <br />
                <br />
                <asp:Label ID="excpn" runat="server" ForeColor="#FF6600" Text="Label" Visible="False"></asp:Label>
            </div>
            <div class="reg">
                <p>Don't have an account ? No Problem !</p>
                <asp:Button CssClass="btnreg" ID="Register" runat="server" Text="Register Here" CausesValidation="False" OnClick="Register_Click" />
            </div>
        </form>
    </div>

</asp:Content>
