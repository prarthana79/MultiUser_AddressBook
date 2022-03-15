<%@ Page Title="" Language="C#" MasterPageFile="~/Content/addressBookMaster.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row text-justify">
            <p class="h1 offset-1">Contact :</p>
            <asp:Label runat="server" ID="lblText" EnableViewState="false" />
        </div>
        <div class="row text-justify">
            <div class="offset-1">
                <asp:HyperLink runat="server" CssClass="btn btn-warning btn-lg" NavigateUrl="~/AdminPanel/Contact/Add">Add</asp:HyperLink>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="pl-2 overflow-auto">
                <asp:GridView runat="server" CssClass="table table-hover table-responsive" AutoGenerateColumns="false" ID="gvContact" OnRowCommand="gvContact_RowCommand" OnRowDataBound="gvContact_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lbImg" >
                                    <asp:Image runat="server" ID="imgContactPhotoPath" ClientIDMode="Static" ImageUrl='<%# Eval("ContactPhotoPath") %>' CommandArgument='<%# Eval("ContactPhotoPath") %>' Height="70" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblImgData" Text='<%# Eval("ContactPhotoPath") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ContactID" HeaderText="ID" />
                        <asp:BoundField DataField="ContactName" HeaderText="Name" />
                        <%--<asp:BoundField DataField="ContactPhotoPath" HeaderText="ImagePath" />--%>
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                        <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsApp No" />
                        <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField DataField="EmailID" HeaderText="EmailID" />
                        <asp:BoundField DataField="Age" HeaderText="Age" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="ContactCategoryNames" HeaderText="ContactCategory" />
                        <asp:BoundField DataField="BloodGroupName" HeaderText="BloodGroup" />
                        <asp:BoundField DataField="FaceBookID" HeaderText="FaceBookID" />
                        <asp:BoundField DataField="LinkedInID" HeaderText="LinkedInID" />
                        <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
                        <asp:BoundField DataField="ModificationDate" HeaderText="Modification Date" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" SkinID="delete" CommandName="deleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-success btn-lg" NavigateUrl= <%# "~/AdminPanel/Contact/Edit/" + System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Eval("ContactID").ToString())) %> />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
                </div>
        </div>
    </div>
    <script>
        <%--var path = document.getElementById("imgContactPhotoPath").imageUrl;--%>
        var path1 = document.getElementById("#imgContactPhotoPath");
        console.log(path1);
        function imgPop() {
            //Swal.fire({
            //    imageUrl: path1,
            //    imageHeight: 500,
            //    imageAlt: 'An image'
            //})
            Swal.fire({
                title: 'Sweet!',
                text: path1,
                imageUrl: 'https://unsplash.it/400/200',
                imageWidth: 400,
                imageHeight: 200,
                imageAlt: 'Custom image',
            })
        }
    </script>
</asp:Content>

