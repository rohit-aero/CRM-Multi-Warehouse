<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmActiveSales.aspx.cs" Inherits="ContactManagement_FrmActiveSales" %>

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
                    <h4 class="title-hyphen position-relative">Search</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7 col-md-8 col-lg-8 col-xl-9">
                <div class="row">
                    <div class="col-sm-3 col-md-2 mb-3"><label class="mb-0">Rep</label></div>
                    <div class="col-sm-9 col-md-10 mb-3">
                     <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlBranch" runat="server" DataTextField="BName" DataValueField="BranchID" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList> 
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg col-xl">
                <div class="row">
                    <div class="col-sm-6">
                        <asp:Button CssClass="btn btn-success btn-sm btn-block" ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" OnClientClick="return confirm('Are you sure.?');" /></div>
                    <div class="col-sm-6">
                        <asp:Button CssClass="btn btn-danger btn-sm btn-block" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>                   
                </div>
            </div>
</div>
</div>
<div class="col-12">
    <div class="row pt-3">
        <div class="col-12"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
        <div class="col-12"><h5 class="text-uppercase">Branch Information</h5></div>
        <div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Region</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRegion" runat="server" DataTextField="Region" DataValueField="RegionID" Enabled="false"></asp:DropDownList>                             
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Branch Name</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlBranchMain" runat="server" DataTextField="HobartBranchName" DataValueField="HobartBranchName" Enabled="false"></asp:DropDownList>                             
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Branch Location</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlBranchLocation" runat="server" DataTextField="BranchLocation" DataValueField="BranchID" AutoPostBack="True" OnSelectedIndexChanged="ddlBranchLocation_SelectedIndexChanged"></asp:DropDownList>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Company Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtBranchCompany" MaxLength="50" AutoComplete="off" runat="server" Enabled="false"></asp:TextBox>                              
</div>
</div>
    </div>
<div class="row border-top pt-3">
<div class="col-12"><h5 class="text-uppercase">Contact Information</h5></div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Street Address</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComStreet" MaxLength="50" AutoComplete="off" runat="server" Enabled="false"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>City</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComCity" MaxLength="50" AutoComplete="off" runat="server" Enabled="false"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>State</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlComState" runat="server" DataTextField="State" DataValueField="StateID" Enabled="false"></asp:DropDownList>                               
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Country</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlComCountry" runat="server" DataTextField="Country" DataValueField="CountryID" Enabled="false"></asp:DropDownList>                             
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Zip Code</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComZip" MaxLength="15" runat="server" AutoComplete="off" Enabled="false"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Telephone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComTel" MaxLength="20" runat="server" AutoComplete="off" Enabled="false"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Toll Free</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComTollFree" MaxLength="20" runat="server" AutoComplete="off" Enabled="false"></asp:TextBox>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Fax Number</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComFax" MaxLength="20" runat="server" AutoComplete="off" Enabled="false"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Toll Fax</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComTollFax" MaxLength="20" runat="server" AutoComplete="off" Enabled="false"></asp:TextBox>                             
</div>
</div>
</div>
<div class="row border-top pt-3">
<div class="col-12"><h5 class="text-uppercase">Inside Sales Support Information</h5></div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtISSName" runat="server" AutoComplete="off" Enabled="false"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Company</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleCompany" MaxLength="50" AutoComplete="off" runat="server" Enabled="false"></asp:TextBox>                             
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Street Address</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleAddress" MaxLength="50" AutoComplete="off" runat="server" Enabled="false"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>City</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleCity" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>State</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSaleState" runat="server" DataTextField="State" DataValueField="StateID" Enabled="false"></asp:DropDownList>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Country</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSaleCountry" runat="server" DataTextField="Country" DataValueField="CountryID" Enabled="false"></asp:DropDownList>                               
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Telephone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleTel" MaxLength="25" runat="server" Enabled="false"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Fax Number</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleFax" MaxLength="25" runat="server" Enabled="false"></asp:TextBox>                           
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Cell Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleCell" MaxLength="25" runat="server" Enabled="false"></asp:TextBox>                        
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Email</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleEmail" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>                              
</div>
</div>
</div>
<div class="row border-top pt-3">
<div class="col-12"><h5 class="text-uppercase">Employee Information</h5></div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>First Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtFirstName" runat="server"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Last Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtLastName" runat="server"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Abbreviation</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlAbbreviation" runat="server" DataTextField="Abbreviation" DataValueField="AbbreviationID" onchange="ChangeJobTitle()"></asp:DropDownList>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Job Title</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlJobTitle" runat="server" DataTextField="JobTitle" DataValueField="AbbreviationID" Enabled="false"></asp:DropDownList>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Email</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" runat="server"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Direct Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtDirectPhone" runat="server"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Cell Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtCellPhone" runat="server"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Direct Fax</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtDirectFax" runat="server"></asp:TextBox>                             
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Phone Mail</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPhoneMail" runat="server"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Status</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server" DataTextField="Status">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>Active</asp:ListItem>
                                                        <asp:ListItem>Retired</asp:ListItem>
                                                        <asp:ListItem>Quit</asp:ListItem>
                                                        <asp:ListItem>Temp Leave</asp:ListItem>
                                                    </asp:DropDownList>                               
</div>
</div>
<div class="col-sm-3 d-flex align-items-center">
<div class="form-group mb-0">
<div class="input-group input-group-sm d-flex align-items-center">                                          
<div class="input-group-prepend pr-3">Mail Sent to Home Office</div>
<asp:CheckBox ID="chkOffMail" runat="server" />
</div>
</div>
</div>
</div>
<div class="row border-top pt-3">
<div class="col-12"><h5 class="text-uppercase">Home Office Information</h5></div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Address</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" runat="server"></asp:TextBox>                              
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Postal Code</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPostalCode" runat="server"></asp:TextBox>                           
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>City</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCity" runat="server" DataTextField="CityName" DataValueField="CityID"></asp:DropDownList>                               
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" runat="server"></asp:TextBox>                                
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>State</label>   
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" runat="server" DataTextField="State" DataValueField="StateID"></asp:DropDownList>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Fax</label> 
<asp:TextBox CssClass="form-control form-control-sm" ID="txtFax" runat="server"></asp:TextBox>                              
</div>
</div>
</div>
</div>
            <script type="text/javascript">
                function ChangeJobTitle() {
                       var e = document.getElementById("ctl00_ContentPlaceHolder1_ddlAbbreviation");
                        var strUser = e.options[e.selectedIndex].value;
                        document.getElementById('<%=ddlJobTitle.ClientID%>').value = strUser;
          
          
                }

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
            $('#<%=ddlAbbreviation.ClientID%>').chosen();  
            $('#<%=ddlBranch.ClientID%>').chosen();  
            $('#<%=ddlBranchLocation.ClientID%>').chosen();  
            $('#<%=ddlBranchMain.ClientID%>').chosen();  
            $('#<%=ddlCity.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
            $('#<%=ddlComCountry.ClientID%>').chosen();
            $('#<%=ddlComState.ClientID%>').chosen();
            $('#<%=ddlJobTitle.ClientID%>').chosen();
            $('#<%=ddlRegion.ClientID%>').chosen();
            $('#<%=ddlSaleCountry.ClientID%>').chosen();
            $('#<%=ddlSaleState.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
            
        }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>