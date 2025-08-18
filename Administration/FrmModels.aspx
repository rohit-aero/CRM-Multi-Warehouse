<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmModels.aspx.cs" Inherits="Administration_FrmModels" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <asp:UpdatePanel ID="UploadPanel12" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfCusId" runat="server" />
        <div class="col-12 pt-2 piDiv position-sticky">
        <div class="row">
        <div class="col-12">
            <div class="d-flex align-items-center mb-2">
                <button type="button" class="btn btn-info btn-sm mr-3" id="btnback" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                <h4 class="title-hyphen position-relative">Conveyor Model Information</h4>
            </div>
        </div>
    </div>
        <div class="row">
    <div class="col-md-7 col-lg-6 col-sm-7">
            <div class="row">
                <div class="col-sm-auto"><label class="mb-0">Model</label>
                </div>
                <div class="col-sm mb-3">
                    <asp:DropDownList ID="ddlModels" CssClass="form-control form-control-sm" DataTextField="Model" DataValueField="ModelID" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlModels_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    <div class="col-sm col-md col-lg-auto">
        <div class="row">
            <div class="col-sm">
                <asp:Button ID="btnSave" CssClass="btn btn-success btn-sm" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
    </div>
    </div>
    <div class="col-12">
        <div class="row pt-3">
            <div class="col-12"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
            <div class="col-12"><h5 class="text-uppercase"> Model Information</h5></div>
            <div class="col-sm-8 col-md-6">
            <div class="form-group">
            <label>Name</label>
            <asp:TextBox CssClass="form-control form-control-sm" ID="txtName" MaxLength="50" runat="server"></asp:TextBox>
            </div>
            </div>
            <div class="col-sm-6 col-md-6">
            <div class="form-group">
            <label>Model Description</label>
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
            $('#<%=ddlModels.ClientID%>').chosen();
       }
    </script>
</asp:Content>