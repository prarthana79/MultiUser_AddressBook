<%@ Page Title="" Language="C#" MasterPageFile="~/Content/addressBookMaster.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid h3">
        <div class="row text-justify offset-1">
            <p class="h3">Contact :</p><br /><br />
            <asp:Image runat="server" CssClass="m-3 mt-5" ID="imgUrl" EnableViewState="false" />
            <asp:Label runat="server" ID="lblText" EnableViewState="false" />
        </div>
        <div class="row text-justify offset-1">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
        <div class="offset-3 h2 text-monospace">
            <div class="row"><span>*</span>
                <div class="col-md-4">
                    Country
                </div>
                <div class="col-md-5 float-right dropdown">
                <asp:DropDownList runat="server" CssClass="dropdown dropdown-item" ID="ddlCountryID" AutoPostBack="true" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged"></asp:DropDownList>
                    </div>
            </div><br />
            <div class="row"><span>*</span>
                <div class="col-md-4">
                    State
                </div>
                <div class="col-md-5 float-right dropdown">
                <asp:DropDownList runat="server" CssClass="dropdown dropdown-item" ID="ddlStateID" AutoPostBack="true" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged"></asp:DropDownList>
                    </div>
            </div>
            <br /><div class="row"><span>*</span>
                <div class="col-md-4">
                    City
                </div>
                <div class="col-md-5 float-right dropdown">
                <asp:DropDownList runat="server" CssClass="dropdown dropdown-item" ID="ddlCity"></asp:DropDownList>
                    </div>
            </div>
            <br /><div class="row"><span>* </span>
                <div class="col-md-4">
                    Contact Category
                </div>
                <div class="col-md-5 float-right dropdown">
                <asp:CheckBoxList runat="server" CssClass="dropdown dropdown-item" ID="cblContactCategory"></asp:CheckBoxList>
            </div></div><br />
            <div class="row"><span>* </span>
                <div class="col-md-4">
                    Name
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" placeHolder="Enter Name" ID="txtContactName"></asp:TextBox>
            </div></div><br />
            <div class="row"><span>* </span>
                <div class="col-md-4">
                    Image
                </div>
                <div class="col-md-5 float-right ">
                <asp:FileUpload runat="server" ID="fuFile" />
                <asp:HiddenField ID="hfImagePath" runat="server" />
                
            </div></div><br />
            <div class="row"><span>* </span>
                <div class="col-md-4">
                    Contact Number
                </div>
                <div class="col-md-5 float-right">
                <asp:TextBox runat="server" placeHolder="Enter Contact Number" ID="txtContactNo" TextMode="Number"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revContactNo" runat="server" CssClass="h6" ControlToValidate="txtContactNo" Display="Dynamic" ValidationGroup="submitData" ErrorMessage="Not A Valid Mobile Number<br/>(should contain 10 digits)" ForeColor="Red" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
            </div></div><br />
            <div class="row"><span>&nbsp;</span>
                <div class="col-md-4">
                    WhatsApp Number
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" placeHolder="Enter WhatsApp Number" ID="txtWhatsAppNo" TextMode="Number"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revWhatsAppNo" runat="server" CssClass="h6" ControlToValidate="txtWhatsAppNo" Display="Dynamic" ValidationGroup="submitData" ErrorMessage="Not A Valid Mobile Number<br/>(should contain 10 digits)" ForeColor="Red" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
            </div></div><br />
            <div class="row"><span>* </span>
                <div class="col-md-4">
                    BirthDate
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" ID="txtBirthDate" TextMode="Date"></asp:TextBox>
            </div></div><br />
            <div class="row"><span>* </span>
                <div class="col-md-4">
                    Email
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" placeHolder="Enter Email ID" ID="txtEmailID"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revEmailID" runat="server" CssClass="h6" ControlToValidate="txtEmailID" Display="Dynamic" ErrorMessage="Not A Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="submitData"></asp:RegularExpressionValidator>
            </div></div><br />
            <div class="row"><span>&nbsp;</span>
                <div class="col-md-4">
                    Age
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" placeHolder="Enter Age" ID="txtAge"></asp:TextBox>
            </div></div><br />
            <div class="row"><span>* </span>
                <div class="col-md-4">
                    Address
                </div>
                <div class="col-md-5 float-right">
                <asp:TextBox runat="server" placeHolder="Enter Address" ID="txtAddress" Rows="3" TextMode="MultiLine"></asp:TextBox>
            </div></div><br />
            <div class="row"><span>* </span>
                <div class="col-md-4">
                    BloodGroup
                </div>
                <div class="col-md-5 float-right dropdown">
                <asp:DropDownList runat="server" CssClass="dropdown dropdown-item" ID="ddlBloodGroup"></asp:DropDownList>
            </div></div><br />
            <div class="row"><span>&nbsp;</span>
                <div class="col-md-4">
                    FaceBookID
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" placeHolder="Enter Facebook ID" ID="txtFacebookID"></asp:TextBox>
            </div></div><br />
            <div class="row"><span>&nbsp;</span>
                <div class="col-md-4">
                    LinkedInID
                </div>
                <div class="col-md-5 float-right ">
                <asp:TextBox runat="server" placeHolder="Enter LinkedIn ID" ID="txtLinkedInID"></asp:TextBox>
            </div></div><br />
            <div class="row text-center">
                <div class="col-md-8">
                    <asp:Button runat="server" ID="btnSubmit" Text="Save" OnClick="btnSubmit_Click" ValidationGroup="submitData"></asp:Button>
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click"></asp:Button>
                </div>
            </div>
        </div></div>
</asp:Content>

