<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmRepBranches.aspx.cs" Inherits="ContactManagement_FrmRepBranches" %>

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
            <div class="col-sm-7 col-md-8 col-lg-6">
                <div class="row">
                    <div class="col-sm-auto mb-3"><label class="mb-0">Branch</label></div>
                    <div class="col-sm mb-3">
					   <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlBranch" runat="server" DataTextField="Branch" DataValueField="BranchID" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList>                
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg-auto">
                <div class="row">
                    <div class="col-sm">
					    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" OnClick="btnSave_Click" OnClientClick="return confirm('Are you sure.?');" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
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
<label>Branch Location</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtLocation" runat="server" MaxLength="50"></asp:TextBox>
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Branch Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtBranchName" MaxLength="50" runat="server"></asp:TextBox>                            
</div>
</div>
<div class="col-sm-6 col-md-3 d-flex align-items-center">
<div class="d-flex">
<div class="form-check pr-4">
  <asp:CheckBox CssClass="form-check-input" ID="chkHobart" runat="server" />
  <label class="form-check-label" for="defaultCheck1">
    Hobart Group
  </label>
</div>
<div class="form-check">
  <asp:CheckBox CssClass="form-check-input" ID="chkStero" runat="server" />
  <label class="form-check-label">
    Stero Group
  </label>
</div>
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Region</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRegion" runat="server" DataTextField="Region" DataValueField="RegionID"></asp:DropDownList>                             
</div>
</div>
</div>
<div class="row border-top pt-3">
<div class="col-12"><h5 class="text-uppercase">Company Information</h5></div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComName" MaxLength="50" runat="server"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Street Address</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComStreet" runat="server" MaxLength="50"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>City</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComCity" MaxLength="50" runat="server"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>State</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlComState" runat="server" DataTextField="State" DataValueField="StateID"></asp:DropDownList>                               
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Country</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlComCountry" runat="server" DataTextField="Country" DataValueField="CountryID"></asp:DropDownList>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Zip Code</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComZip" MaxLength="15" runat="server"></asp:TextBox>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Telephone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComTel" MaxLength="20" runat="server"></asp:TextBox>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Toll Free</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComTollFree" MaxLength="20" runat="server"></asp:TextBox>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Fax Number</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComFax" MaxLength="20" runat="server"></asp:TextBox>                            
</div>
</div>
<div class="col-sm-6 col-md-3">
<div class="form-group">
<label>Toll Fax</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtComTollFax" MaxLength="20" runat="server"></asp:TextBox>                            
</div>
</div>
</div>
<div class="row border-top pt-3">
<div class="col-12"><h5 class="text-uppercase">Inside Sales Support Information</h5></div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Name</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSaleName" runat="server" DataTextField="ISSName" DataValueField="RepID" AutoPostBack="True" OnSelectedIndexChanged="ddlSaleName_SelectedIndexChanged"></asp:DropDownList>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Company</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleCompany" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Street Address</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleAddress" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>City</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleCity" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>State</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSaleState" runat="server" DataTextField="State" DataValueField="StateID" Enabled="false"></asp:DropDownList>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Country</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSaleCountry" runat="server" DataTextField="Country" DataValueField="CountryID" Enabled="false"></asp:DropDownList>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Telephone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleTel" MaxLength="25" runat="server" Enabled="false"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Fax Number</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleFax" MaxLength="25" runat="server" Enabled="false"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Cell Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleCell" MaxLength="25" runat="server" Enabled="false"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Email</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleEmail" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>                               
</div>
</div>
</div>
<div class="row border-top pt-3">
<div class="col-12"><h5 class="text-uppercase">Member Details</h5></div>
<div class="col-12">
<div class="table-responsive">
<asp:GridView CssClass="table mainGridTable table-sm" ID="gvMember" runat="server" AutoGenerateColumns="False" 
                                    AllowPaging="True"
                                    EmptyDataText="No Member has been added." EnableModelValidation="True" 
                                        OnPageIndexChanging="gvMember_PageIndexChanging" 
                                        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                                        ForeColor="Black" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Sales Rep Name" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ext" HeaderText="Extension" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CellPhone" HeaderText="Cell Phone" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
</div></div>



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
           $('#<%=ddlBranch.ClientID%>').chosen();
           $('#<%=ddlComCountry.ClientID%>').chosen();
           $('#<%=ddlComState.ClientID%>').chosen();
           $('#<%=ddlRegion.ClientID%>').chosen();
           $('#<%=ddlSaleCountry.ClientID%>').chosen();
           $('#<%=ddlSaleName.ClientID%>').chosen();
           $('#<%=ddlSaleState.ClientID%>').chosen();
          
          
       }
    </script>
</asp:Content>