<%@ Page Title="" Language="C#" MasterPageFile="~/Content/addressBookMaster.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row text-justify offset-1">
            <p class="h2 ml-5">City :</p>
            <asp:Label runat="server" ID="lblText" EnableViewState="false" />
        </div>
        <div class="row text-justify offset-1">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
        <div class="offset-3 h2 text-monospace">
            <div class="row">
                <div class="col-md-4"><span>*</span>
                    Country
                </div>
                <div class="col-md-5 float-right dropdown">
                <asp:DropDownList runat="server" CssClass="dropdown dropdown-item" ID="ddlCountryID" AutoPostBack="true" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged"></asp:DropDownList>
                    </div>
            </div><br />
            <div class="row">
                <div class="col-md-4"><span>*</span>
                    State
                </div>
                <div class="col-md-5 float-right dropdown">
                    <asp:DropDownList runat="server" CssClass="dropdown dropdown-item" ID="ddlStateID"></asp:DropDownList>
                </div>
                </div>
            <br />
            <div class="row">
                <div class="col-md-4"><span>*</span>
                    City Name
                </div>
            <div class="col-md-5 float-right">
                <asp:TextBox runat="server" placeHolder="Enter City Name" CssClass="text-body" ID="txtCityName"></asp:TextBox>
            </div></div>
        <br />
        <div class="row">
                <div class="col-md-4"><span>&nbsp;</span>
                    STD Code
                </div>
            <div class="col-md-5 float-right">
                <asp:TextBox runat="server" placeHolder="Enter STD Code" CssClass="text-body" ID="txtSTDCode"></asp:TextBox>

            </div></div><br />
            <div class="row">
                <div class="col-md-4"><span>&nbsp;</span>
                    Pin Code
                </div>
            <div class="col-md-5 float-right">
                <asp:TextBox runat="server" placeHolder="Enter Pin Code" CssClass="text-body" ID="txtPinCode"></asp:TextBox>
            </div></div>
            <br />
            <div class="row text-center">
                <div class="col-md-8">
                <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-dark btn-lg" Text="Save" OnClick="btnSubmit_Click"></asp:Button>
            
                <asp:Button runat="server" ID="btnCancel" SkinID="cancel" Text="Cancel" OnClick="btnCancel_Click"></asp:Button>
            </div></div></div>
        
    </div>
</asp:Content>

