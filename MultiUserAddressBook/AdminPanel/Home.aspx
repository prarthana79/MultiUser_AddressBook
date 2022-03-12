<%@ Page Title="" Language="C#" MasterPageFile="~/Content/addressBookMaster.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="AdminPanel_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <p class="h1 offset-1">Your Data :</p>
            </div>
            <asp:Table runat="server">
                <asp:TableRow></asp:TableRow>
            </asp:Table>
        </div>
    </div>
</asp:Content>

