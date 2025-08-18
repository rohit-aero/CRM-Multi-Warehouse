<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmCategory.aspx.cs" Inherits="Administration_frmCategory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCategoryID" runat="server" Value="-1" />
<div class="col-12 pt-2 piDiv position-sticky">
        <div class="row">
            <div class="col-12">
                <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">Category Details</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7 col-md-8 col-lg-6">
                <div class="row">
                    <div class="col-sm-auto mb-3"><label class="mb-0">Category</label></div>
                    <div class="col-sm mb-3">
					    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCategory" runat="server" DataTextField="Category" DataValueField="CategoryID" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>              
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg-auto">
                <div class="row">
                    <div class="col-sm">
					    <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  />
                        <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"  />
                    </div>                                      
                </div>
            </div>
</div>
</div>
<div class="col-12">
<div class="row pt-3">
<div class="col-12"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
<div class="col-12"><h5 class="text-uppercase">Category Details</h5></div>
<div class="col-sm-6 col-md-6">
<div class="form-group">
<label>Category Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
</div>
</div>
<div class="col-sm-6 col-md-6">
<div class="form-group">
<label>Category Description</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtDescription" runat="server" TextMode="MultiLine" MaxLength="50"></asp:TextBox><br />
<asp:RegularExpressionValidator ID="regexDesc" runat="server" ErrorMessage="Maximum of 50 Characters Allowed" ControlToValidate="txtDescription" Display="Dynamic"  ValidationExpression=".{0,50}" ValidationGroup="NewValidationGroup"/>
</div>
</div>
</div>
</div>
          
    </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
          Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
       });
       function PageLoaded(sender, args) {
           
           DDL();
           
       }
       $.when.apply($, PageLoaded).then(function () {
           DDL();
          
       });
       function DDL() {
            $('#<%=ddlCategory.ClientID%>').chosen();
          
       }
    </script>
</asp:Content>