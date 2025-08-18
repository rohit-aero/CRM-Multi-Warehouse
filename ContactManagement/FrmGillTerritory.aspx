<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmGillTerritory.aspx.cs" Inherits="ContactManagement_FrmGillTerritory" %>

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
                    <h4 class="title-hyphen position-relative">Territory Information</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                <div class="row">
                    <div class="col-sm-auto col-md-auto mb-3"><label class="mb-0">Territory</label></div>
                    <div class="col-sm col-md mb-3 chosenFullWidth">
					   <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTerr" runat="server" 
                                DataTextField="TerritoryName" DataValueField="TerritoryId" 
                                AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged"></asp:DropDownList>                
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg col-xl-auto">
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
        <div class="col-12"><h5 class="text-uppercase">Gill&#39;s Territory Information</h5></div>
        <div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Territory Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtTerrName" runat="server" MaxLength="50"></asp:TextBox>
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Belong to Employee</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlEmployee" runat="server" DataTextField="Name" DataValueField="EmployeeId"></asp:DropDownList>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Street Address</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" runat="server" MaxLength="50"></asp:TextBox>                              
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
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="Country"></asp:DropDownList>                            
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
<label>Primary Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPrimaryPhone" onblur="phoneMask(this)" MaxLength="25" runat="server"></asp:TextBox>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Secondary Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSecondPhone" onblur="phoneMask(this)" MaxLength="25" runat="server"></asp:TextBox>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Fax</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtFax" MaxLength="50" runat="server"></asp:TextBox>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Email</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" oninput="emailMask(this)" runat="server"></asp:TextBox>                            
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
           $('#<%=ddlTerr.ClientID%>').chosen();
           $('#<%=ddlCountry.ClientID%>').chosen();
           $('#<%=ddlEmployee.ClientID%>').chosen();
           $('#<%=ddlState.ClientID%>').chosen();
       }
    </script>
</asp:Content>