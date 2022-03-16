<%@ Page Title="" Language="C#" MasterPageFile="~/Content/addressBookMaster.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row text-justify">
            <%--<p class="h1 offset-1">City :</p>--%>
            <asp:Label runat="server" ID="lblText" EnableViewState="false" />
        </div>
        <div class="row text-justify">
            <div class="offset-1">
                <asp:HyperLink runat="server" CssClass="btn btn-warning btn-lg" NavigateUrl="~/AdminPanel/City/Add">Add City</asp:HyperLink>
            </div>
        </div>
        <div class="row"><div class="col-md-12">
                <div class="pl-2 h4">
                <asp:GridView runat="server" CssClass="table table-hover overflow-auto" ID="gvCity" AutoGenerateColumns="false" OnRowCommand="gvCity_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CityID" HeaderText="ID" />
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <asp:BoundField DataField="STDCode" HeaderText="STDCode" />
                        <asp:BoundField DataField="PinCode" HeaderText="PinCode" />
                        <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
                        <%--<asp:BoundField DataField="ModificationDate" HeaderText="Modification Date" />--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" SkinID="delete" CommandName="deleteRecord" CommandArgument='<%# Eval("CityID").ToString() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-success btn-lg" NavigateUrl= <%# "~/AdminPanel/City/Edit/" + System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Eval("CityID").ToString())) %> />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

