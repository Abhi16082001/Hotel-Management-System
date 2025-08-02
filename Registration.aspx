<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Hotel_Management.Registration" %>
<%@ MasterType VirtualPath="~/Site1.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles/Register.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Registration Form </h1>
    <div>
        <form id="regform" runat="server">
            <asp:Label CssClass="lbl" ID="frstname" runat="server" Text="First Name :"></asp:Label>  <br />
            <asp:TextBox CssClass="txtbx" ID="fname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="First Name is Mandatory !!" ForeColor="Red" ControlToValidate="fname"></asp:RequiredFieldValidator>
            <br />
          <asp:Label CssClass="lbl" ID="lstname" runat="server" Text="Last Name :"></asp:Label>  <br>
            <asp:TextBox CssClass="txtbx" ID="lname" runat="server"></asp:TextBox>
            <br />
           <asp:Label CssClass="lbl" ID="username" runat="server" Text="UserName :"></asp:Label> <br>
            <asp:TextBox CssClass="txtbx" ID="usrnm" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="UserName is Mandatory !!" ForeColor="Red" ControlToValidate="usrnm"></asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="lbl" ID="password" runat="server" Text="Password :">  </asp:Label> <br>
            <asp:TextBox CssClass="txtbx" ID="pwd" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage="Creating Password is Mandatory !!" ForeColor="Red" ControlToValidate="pwd"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="pwd" Display="Dynamic" ErrorMessage="Password must contains one digit, one uppercase, one lowercase and one special character without white spaces within 8-16 characters only !!" ForeColor="Red" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,16}$"></asp:RegularExpressionValidator>
            <br />
            <asp:Label CssClass="lbl" ID="cpassword" runat="server" Text="Confirm Password : "> </asp:Label> <br>
            <asp:TextBox CssClass="txtbx" ID="cpwd" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="Confirming Password is Mandatory !!" ForeColor="Red" ControlToValidate="cpwd"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="pwd" ControlToValidate="cpwd" Display="Dynamic" ErrorMessage="Compare Password and Password must be same !!" ForeColor="Red"></asp:CompareValidator>
            <br />
          <asp:Label CssClass="lbl" ID="gender" runat="server" Text="Gender :"> </asp:Label> <br>
            <div class="genderCntr">
            <asp:RadioButton  ID="male" CssClass="gender" runat="server" Text="Male" GroupName="gndr" />
            <asp:RadioButton ID="fmale" CssClass="gender" runat="server" Text="Female" GroupName="gndr" />
                </div>
            <br />
             <asp:Label CssClass="lbl" ID="email" runat="server" Text="Email :"> </asp:Label> <br>
            <asp:TextBox CssClass="txtbx" ID="eml" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ErrorMessage="Email is Mandatory !!" ForeColor="Red" ControlToValidate="eml"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="eml" Display="Dynamic" ErrorMessage="Wrong Email Format !!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <asp:Label CssClass="lbl" ID="Phone" runat="server" Text="Phone :">  </asp:Label> <br>
            <asp:TextBox CssClass="txtbx" ID="phn" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ErrorMessage="Phone is Mandatory !!" ForeColor="Red" ControlToValidate="phn"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="phn" Display="Dynamic" ErrorMessage="Wrong Phone Number Format !!" ForeColor="Red" ValidationExpression="^\+(\d{1,3})[- ]?\d{4,14}$"></asp:RegularExpressionValidator>
            <br />
            <asp:Label CssClass="lbl" ID="address" runat="server" Text="Address :"> </asp:Label> <br>
            <asp:TextBox CssClass="txtbx" ID="addrs" runat="server" Height="98px" TextMode="MultiLine" ></asp:TextBox>
            <br />
            <asp:Label CssClass="lbl" ID="lblage" runat="server" Text="Age :"> </asp:Label> <br>
            <asp:TextBox CssClass="txtbx" ID="age" runat="server" TextMode="Number" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ErrorMessage="Age is Mandatory !!" ForeColor="Red" ControlToValidate="age"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="age" Display="Dynamic" ErrorMessage="Age must be greater than 18 and less than 100" ForeColor="Red" MaximumValue="100" MinimumValue="18" Type="Integer"></asp:RangeValidator>
            <br />
            <asp:Label CssClass="lbl" ID="lang" runat="server" Text="Languages Known :">  </asp:Label> <br>
           <div id="chck" class="txtbx" >
            <div> <asp:CheckBox   ID="eng" runat="server" Text="English" /> </div>
            <div> <asp:CheckBox  ID="hindi" runat="server" Text="Hindi" /> </div>
            <div> <asp:CheckBox  ID="telugu" runat="server" Text="Telugu" /> </div>
               </div>
            <br />
            <asp:Label CssClass="lbl" ID="country" runat="server" Text="Country :">  </asp:Label> <br>
            <asp:DropDownList CssClass="txtbx" ID="cntry" runat="server">
                <asp:ListItem Value="None" Selected="True">Select Country</asp:ListItem>
                <asp:ListItem>India</asp:ListItem>
                <asp:ListItem>USA</asp:ListItem>
                <asp:ListItem>Russia</asp:ListItem>
                <asp:ListItem>Afghanistan</asp:ListItem>
                <asp:ListItem>Myanmar</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ErrorMessage="Country is Mandatory !!" ForeColor="Red" ControlToValidate="cntry"></asp:RequiredFieldValidator>
            <br />
            <asp:Button CssClass="btn" ID="register" runat="server" Text="Register" OnClick="register_Click" />
            <br />
            <asp:Label ID="excpn" runat="server" ForeColor="#FF6600" Text="Label" Visible="False"></asp:Label> 
        </form>
    </div>

</asp:Content>
