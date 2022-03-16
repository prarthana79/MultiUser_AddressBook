<%@ Page Title="" Language="C#" MasterPageFile="~/Content/addressBookMaster.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row text-justify offset-1">
            <p class="h3">Contact Category :</p>
            <asp:Label runat="server" ID="lblText" EnableViewState="false" />
        </div>
        <div class="row text-justify offset-1">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
        <div class="offset-3 h2 text-monospace">
            <div class="row"><span>*</span>
                <div class="col-md-4">
                    Contact Category
                </div>
            <div class="col-md-5 float-right">
                <asp:TextBox runat="server" placeHolder="Enter Contact Category" CssClass="text-body" ID="txtContactCategoryName"></asp:TextBox>
            </div></div><br />
            <div class="row text-center">
                <div class="col-md-8">
                <asp:Button runat="server" ID="btnSubmit" Text="Save" OnClick="btnSubmit_Click"></asp:Button>
                <asp:Button runat="server" ID="btnCancel" SkinID="cancel" Text="Cancel" OnClick="btnCancel_Click"></asp:Button>
            </div></div>
        </div>
    </div>
</asp:Content>

