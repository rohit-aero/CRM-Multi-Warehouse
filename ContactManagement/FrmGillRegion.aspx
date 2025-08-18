<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmGillRegion.aspx.cs" Inherits="ContactManagement_FrmGillRegion" %>

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
                    <h4 class="title-hyphen position-relative">Region Information</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                <div class="row">
                    <div class="col-sm-auto col-md-auto mb-3"><label class="mb-0">Region</label></div>
                    <div class="col-sm col-md mb-3">
					     <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRegion" runat="server" DataTextField="Region" DataValueField="RegionId" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged"></asp:DropDownList>               
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg-auto col-xl-auto">
                <div class="row">
                    <div class="col-auto">
					    <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>                  
                </div>
            </div>
</div>
</div>
<div class="col-12">
<div class="row pt-3">
        <div class="col-12"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
        <div class="col-12"><h5 class="text-uppercase">Gill&#39;s Marketing Region Office Information</h5></div>
        <div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Region</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtRegion" MaxLength="30" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Company Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComapnyName" MaxLength="50" runat="server"></asp:TextBox>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Street Address</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" MaxLength="50" runat="server"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>City</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" MaxLength="20" runat="server"></asp:TextBox>                             
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>State</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" runat="server" DataTextField="State" DataValueField="Sabb"></asp:DropDownList>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Country</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryID"></asp:DropDownList>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Zip Code</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtZipCode" MaxLength="6" runat="server"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Toll Free</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtTollFree" onblur="phoneMask(this)" MaxLength="25" runat="server"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" onblur="phoneMask(this)" MaxLength="25" runat="server"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Fax</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtFax" MaxLength="50" runat="server"></asp:TextBox>                              
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
           $('#<%=ddlCountry.ClientID%>').chosen();
           $('#<%=ddlRegion.ClientID%>').chosen();
           $('#<%=ddlState.ClientID%>').chosen();
           
          
          
       }
    </script>
</asp:Content>