<%@ Page Title="" Language="C#" MasterPageFile="~/Content/addressBookMaster.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row text-justify">
            <%--<p class="h1 offset-1">Contact Category :</p>--%>
            <asp:Label runat="server" ID="lblText" EnableViewState="false" />
        </div>
        <div class="row text-justify">
            <div class="offset-1">
                <asp:HyperLink runat="server" CssClass="btn btn-warning btn-lg" NavigateUrl="~/AdminPanel/ContactCategory/Add">Add Contact Category</asp:HyperLink>
            </div>
        </div>
        <div class="row"><div class="col-md-12">
                <div class="pl-2 h4">
                <asp:GridView runat="server" CssClass="table table-hover table-responsive" ID="gvContactCategory" AutoGenerateColumns="false" OnRowCommand="gvContactCategory_RowCommand">
                    <Columns>
                        
                        <asp:BoundField DataField="ContactCategoryID" HeaderText="ID" />
                        <asp:BoundField DataField="ContactCategoryName" HeaderText="Category" />
                        <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
                        <%--<asp:BoundField DataField="ModificationDate" HeaderText="Modification Date" />--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" SkinID="delete" OnClientClick="return confirm('Are you sure you want to delete?')" CommandName="deleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-success btn-lg" NavigateUrl= <%# "~/AdminPanel/ContactCategory/Edit/" + System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Eval("ContactCategoryID").ToString())) %> />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            </div>
        </div>
        <script>
            $(function ans() {
                //OnClientClick="return confirm('Are you sure you want to delete?')"
            //    $("#dialog-confirm").dialog({
            //        resizable: false,
            //        height: "auto",
            //        width: 400,
            //        modal: true,
            //        buttons: {
            //            "Delete all items": function () {
            //                $(this).dialog("close");
            //            },
            //            Cancel: function () {
            //                $(this).dialog("close");
            //            }
            //        }
            //    });
            //});
            //    $("#btnDelete").dialog({
            //        buttons: {
            //            "Yes": return true {},
            //        "No": return false { }
            //    }
            //})
        </script>
        <%--<script>
            //OnClientClick = "deleteConfirmation(); return false"
            function deleteConfirmation() {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                    footer: '<a href="">Why do I have this issue?</a>'
                })
            }
            //function deleteCC() {
                // OnClientClick="deleteCC(); return false"
                //const swalWithBootstrapButtons = Swal.mixin({
                //    customClass: {
                //        confirmButton: 'btn btn-success',
                //        cancelButton: 'btn btn-danger'
                //    },
                //    buttonsStyling: false
                //})

                //swalWithBootstrapButtons.fire({
                //    title: 'Are you sure?',
                //    text: "You won't be able to revert this!",
                //    icon: 'warning',
                //    showCancelButton: true,
                //    confirmButtonText: 'Yes, delete it!',
                //    cancelButtonText: 'No, cancel!',
                //    reverseButtons: true
                //}).then((result) => {
                //    if (result.isConfirmed) {
                //        swalWithBootstrapButtons.fire(
                //            'Deleted!',
                //            'Your file has been deleted.',
                //            'success'
                //        )
                //    } else if (
                //        /* Read more about handling dismissals below */
                //        result.dismiss === Swal.DismissReason.cancel
                //    ) {
                //        swalWithBootstrapButtons.fire(
                //            'Cancelled',
                //            'Your imaginary file is safe :)',
                //            'error'
                //        )
                //    }
                //})
            //}
        </script>--%>
    </div>
</asp:Content>

