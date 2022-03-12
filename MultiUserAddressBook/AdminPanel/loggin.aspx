<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loggin.aspx.cs" Inherits="AdminPanel_loggin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddressBook Log In</title>
    <link href="~/Content/css/bootstrap.min.css" rel="stylesheet"/>
    <style>
        body{
            background-color:#C3CAD2;
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
            <div class="row">
                    <div class="col-md-10 offset-1 mt-5">
                    <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
                </div></div>
                <div class="text-center m-4 h2">
                    <div class="row">
                        <div class="col-md-3 offset-2">
                            UserName
                        </div>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUserName"></asp:TextBox>
                    </div></div><br />
                    <div class="row">
                        <div class="col-md-3 offset-2">
                            Password
                        </div>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password"></asp:TextBox>
                    </div></div><br />
                    <div class="col-md-10 offset-1">
                        <asp:Button runat="server" ID="btnSubmit" Text="Log In" OnClick="btnSubmit_Click"></asp:Button>
                        <asp:Button runat="server" ID="btnSignUp" SkinID="cancel" Text="Sign Up" OnClick="btnSignUp_Click"></asp:Button>
                    </div>
                </div>
            </div>
        
    </form>

</body>
</html>
