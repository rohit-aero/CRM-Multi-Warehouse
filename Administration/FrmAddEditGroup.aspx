<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmAddEditGroup.aspx.cs" Inherits="Administration_FrmAddEditGroup" %>

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
                    <h4 class="title-hyphen position-relative">Group Information</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7 col-md-8 col-lg-6">
                <div class="row">
                    <div class="col-sm-auto mb-3"><label class="mb-0">Group Name</label></div>
                    <div class="col-sm mb-3 chosenFullWidth">
					    <asp:DropDownList CssClass="form-control form-control-sm"  ID="ddlGroup" runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"></asp:DropDownList>               
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg-auto">
                <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
</div>
</div>

<div class="col-12">
<div class="row pt-3">
<div class="col-12"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
<div class="col-12"><h5 class="text-uppercase">Group Information</h5></div>
<div class="col-sm-6 col-md-4">
<div class="form-group">
<label>Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
</div>
</div>
<div class="col-sm-6 col-md-4">
<div class="form-group">
<label>Description</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtDescription" runat="server" MaxLength="50" TextMode="MultiLine"></asp:TextBox>                            
</div>
</div>
<div class="col-sm-6 col-md-4">
<div class="form-group">
<label>Status</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
<asp:ListItem></asp:ListItem>
<asp:ListItem Value="1">Active</asp:ListItem>
<asp:ListItem Value="2">In Active</asp:ListItem>
</asp:DropDownList>                              
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
        $('#<%=ddlGroup.ClientID%>').chosen();
        $('#<%=ddlStatus.ClientID%>').chosen();          
    }
    </script>
</asp:Content>