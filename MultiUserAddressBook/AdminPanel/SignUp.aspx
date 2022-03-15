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
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
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
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" CssClass="h6" ControlToValidate="txtPassword" Display="Dynamic" ValidationGroup="submitData" ErrorMessage="Password must contain : <br/> a capital letter, a small letter, a digit <br/>and must be of 4 to 8 characters" ForeColor="Red" ValidationExpression="^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{4,8}$"></asp:RegularExpressionValidator>
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
                    <asp:RegularExpressionValidator ID="revEmailID" runat="server" CssClass="h6" ControlToValidate="txtEmailID" Display="Dynamic" ErrorMessage="Not A Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="submitData"></asp:RegularExpressionValidator>
            </div></div><br />
            <div class="row"><span>&nbsp;</span>
                <div class="col-md-4">
                    Mobile Number
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" placeholder="Enter Mobile Number" ID="txtMobileNo" TextMode="Number"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revContactNo" runat="server" CssClass="h6" ControlToValidate="txtMobileNo" Display="Dynamic" ValidationGroup="submitData" ErrorMessage="Not A Valid Mobile Number<br/>(should contain 10 digits)" ForeColor="Red" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
            </div></div><br />
            <div class="col-md-4 offset-2">
                <asp:Button runat="server" ID="btnSubmit" Text="Create User" OnClick="btnSubmit_Click" ValidationGroup="submitData" OnClientClick="accountCreated()"></asp:Button>
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click"></asp:Button>
            </div>
        </div></div>
        </div>
    </form>
    <script>
        function accountCreated() {
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 2000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.addEventListener('mouseenter', Swal.stopTimer)
                    toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
            })

            Toast.fire({
                icon: 'success',
                title: 'Account is creating...<br>wait for few seconds'
            })
        }
    </script>
</body>
</html>
