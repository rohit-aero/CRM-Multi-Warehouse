<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmCompetitor.aspx.cs" Inherits="ContactManagement_FrmCompetitor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="UpdatePanel11" runat="server">
 <ContentTemplate>
    <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
    <div class="col-12 pt-2 piDiv position-sticky">
    <div class="row">
    <div class="col-12">
        <div class="d-flex align-items-center mb-2">
            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
            <h4 class="title-hyphen position-relative">Competitor Details</h4>
        </div>
    </div>
</div>
    <div class="row">
    <div class="col-sm-7 col-md-8 col-lg-6">
        <div class="row">
            <div class="col-sm-auto mb-3"><label class="mb-0">Search Competitor</label></div>
            <div class="col-sm mb-3">
                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCompetitor" runat="server" DataTextField="CompetitorName" DataValueField="CompetitorID" AutoPostBack="True" OnSelectedIndexChanged="ddlCompetitor_SelectedIndexChanged"></asp:DropDownList> 
            </div>
        </div>
    </div>
    <div class="col-sm col-md col-lg-auto">
        <div class="row">
            <div class="col-sm">
                <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>                 
        </div>
    </div>
</div>
</div>
    <div class="col-12 pt-3">
<div class="row">
<div class="col-12"><h5 class="text-uppercase mb-3">Competitor Details</h5></div>
<div class="col-12"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
<div class="col-md-6">
    <div class="form-group">
        <label>Competitor Name</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtName" MaxLength="30" runat="server"></asp:TextBox>
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
            BindDrp();
        }
        $.when.apply($, PageLoaded).then(function () {
            BindDrp();
        });
        function BindDrp() {
            $('#<%=ddlCompetitor.ClientID%>').chosen();
        }
    </script>
</asp:Content>