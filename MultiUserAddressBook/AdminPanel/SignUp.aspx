<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddressBook SignUp</title>
    <link href="~/Content/css/bootstrap.min.css" rel="stylesheet"/>
    <style>
        body{
            background-color:#C3CAD2;
        }
        span{
            color:red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row bg-dark">
                <div class="text-center col-md-12 p-3 pb-4">
                    <h1 class="display-3 font-italic text-light font-weight-bolder"><u>ADDRESS BOOK</u></h1>
                </div>
            </div>
            <div class="h3 container-fluid">
        <div class="row text-justify offset-1">
            <p class="h3 mt-4">Sign Up yourself :</p>
            <asp:Label runat="server" ID="lblText" EnableViewState="false" />
        </div>
        <div class="row text-justify offset-1">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
        <div class="offset-3 h2 text-monospace">
            <div class="row"><span>*</span>
                <div class="col-md-4">
                    Name
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" placeholder="Enter Name" ID="txtUserName"></asp:TextBox>
            </div></div><br />
            <div class="row"><span>*</span>
                <div class="col-md-4">
                    Password
                </div>
                <div class="col-md-5 float-right">
                <asp:TextBox runat="server" placeholder="Enter Password" ID="txtPassword" TextMode="Password"></asp:TextBox>
            </div></div><br />
            <div class="row"><span>*</span>
                <div class="col-md-4">
                    Display Name
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" placeholder="Enter DisplayName" ID="txtDisplayName"></asp:TextBox>
            </div></div><br />
            <div class="row"><span>&nbsp;</span>
                <div class="col-md-4">
                    Email
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" placeholder="Enter Email ID" ID="txtEmailID"></asp:TextBox>
            </div></div><br />
            <div class="row"><span>&nbsp;</span>
                <div class="col-md-4">
                    Mobile Number
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" placeholder="Enter Mobile Number" ID="txtMobileNo"></asp:TextBox>
            </div></div><br />
            <div class="col-md-3 offset-1">
                <asp:Button runat="server" ID="btnSubmit" Text="Create User" OnClick="btnSubmit_Click"></asp:Button>
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click"></asp:Button>
            </div>
        </div></div>
        </div>
    </form>

</body>
</html>
