<%@ Page Title="" Language="C#" MasterPageFile="~/Content/addressBookMaster.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row text-justify offset-1">
            <p class="h3">Country Add Edit :</p>
            <asp:Label runat="server" ID="lblText" EnableViewState="false" />
        </div>
        <div class="row text-justify offset-1">
            <div class="col-md-10 offset-1"></div>
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>

        <div class="offset-3 h2 text-monospace">
            <div class="row"><span>*</span>
                <div class="col-md-4">
                    Country Name
                </div>
            <div class="col-md-5 float-right">
                <asp:TextBox runat="server" placeHolder="Enter Country Name" CssClass="form-control" ID="txtCountryName"></asp:TextBox>
            </div></div><br />
            <div class="row"><span>&nbsp;</span>
                <div class="col-md-4">
                    Country Code
                </div>
            <div class="col-md-5 float-right">
                <asp:TextBox runat="server" placeHolder="Enter Country Code" CssClass="form-control" ID="txtCountryCode"></asp:TextBox>
            </div></div><br />

            <div class="col-md-10 offset-1">
                <asp:Button runat="server" ID="btnSubmit" Text="Save" OnClick="btnSubmit_Click"></asp:Button>
                <asp:Button runat="server" ID="btnCancel" SkinID="cancel" Text="Cancel" OnClick="btnCancel_Click"></asp:Button>
            </div>
        </div>
    </div>
</asp:Content>

