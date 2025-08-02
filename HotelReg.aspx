<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HotelReg.aspx.cs" Inherits="Hotel_Management.HotelReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles/hotelform.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hotel Room Registration Form</h1>

    <div>
        <form id="Hregform" runat="server">

            <asp:Label CssClass="lbl" ID="usrnm" runat="server" Text="Username : "> </asp:Label>
            <asp:TextBox CssClass="usertxtbx txtbx" ID="username" runat="server" Text="HotelUser" ReadOnly="true"></asp:TextBox>
            <br />
            <asp:Label CssClass="lbl" ID="room" runat="server" Text="Room Type :"> </asp:Label>
            <asp:RadioButtonList CssClass="txtbx" ID="RoomType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" >
                 <asp:ListItem CssClass="radio" >Delux</asp:ListItem>
                 <asp:ListItem CssClass="radio">Ordinary</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RoomType" Display="Dynamic" ErrorMessage="Please Select One Room Type !!" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="lbl" ID="amn" runat="server" Text="Amenities :">  </asp:Label>
            <asp:CheckBoxList CssClass="txtbx" ID="Amenities" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" >
                 <asp:ListItem CssClass="radio">AC</asp:ListItem>
                 <asp:ListItem CssClass="radio">Computer</asp:ListItem>
            </asp:CheckBoxList>
            <br />
            <asp:Button CssClass="btn" ID="Hregister" runat="server" Text="Book Room" OnClick="Hregister_Click" />
            <br />
        <asp:Label ID="excpn" runat="server" ForeColor="#FF6600" Text="Label" Visible="False"></asp:Label>
            <br />
        <asp:Label ID="success" runat="server" ForeColor="#66FF66" Text="Label" Visible="False"></asp:Label>
        </form>
    </div>
</asp:Content>
