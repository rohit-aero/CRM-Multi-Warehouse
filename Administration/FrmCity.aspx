<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmCity.aspx.cs" Inherits="Administration_FrmCity" %>

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
                    <h4 class="title-hyphen position-relative">City Information</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7 col-md-7 col-lg-6">
                <div class="row">
                    <div class="col-sm-auto mb-3"><label class="mb-0">City</label></div>
                    <div class="col-sm mb-3">
					    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCity" runat="server" DataTextField="CityName" DataValueField="CityID" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>              
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg-auto">
                <div class="row">
                    <div class="col-sm">
					<asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    <asp:Button CssClass="btn btn-secondary btn-sm" ID="btnBack" runat="server" Text="Proposal Page" OnClick="btnBack_Click" />           
                    </div>
                                    
                </div>
            </div>
</div>
</div>
<div class="col-12">
<div class="row pt-3">
<div class="col-12"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
<div class="col-12"><h5 class="text-uppercase">City Information</h5></div>
<div class="col-sm-6 col-md-6">
<div class="form-group">
<label>Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtName" MaxLength="50" runat="server"></asp:TextBox>
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
            $('#<%=ddlCity.ClientID%>').chosen();          
       }
    </script>
</asp:Content>