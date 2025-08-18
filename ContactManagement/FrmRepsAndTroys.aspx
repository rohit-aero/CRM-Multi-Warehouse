<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmRepsAndTroys.aspx.cs" Inherits="ContactManagement_FrmReps_Troys" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">   
      <asp:UpdatePanel ID="UpdatePanel11" runat="server"> 
        <ContentTemplate>
        <div class="col-12 pt-2 piDiv position-sticky">
        <div class="row">
            <div class="col-12">
                <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">Search Active Sales</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7 col-md-8 col-lg-8 col-xl">
                <div class="row">
                <div class="col-sm-3 col-md-auto mb-3"><label class="mb-0">Product Line</label></div>
                <div class="col-sm-6 col-md mb-3">
                    <asp:DropDownList ID="ddlProductLineList" CssClass="form-control form-control-sm" runat="server"  DataTextField="Name" DataValueField="Id"  AutoPostBack="True" OnSelectedIndexChanged="ddlProductLineList_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3 col-md-auto mb-3"><label class="mb-0">Rep Group</label></div>
                <div class="col-sm-6 col-md mb-3">
				    <asp:DropDownList ID="ddlSalesRepGroup" CssClass="form-control form-control-sm" runat="server" 
                        DataTextField="Name" DataValueField="Id"  AutoPostBack="True" OnSelectedIndexChanged="ddlSalesRepGroup_SelectedIndexChanged">                  
                    </asp:DropDownList>
               </div>
                    <div class="col-sm-3 col-md-auto mb-3"><label class="mb-0">Sales Rep</label></div>
                    <div class="col-sm-9 col-md mb-3">
					<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSalesRep" runat="server" DataTextField="Name" DataValueField="RepID" AutoPostBack="True" OnSelectedIndexChanged="ddlSalesRep_SelectedIndexChanged"></asp:DropDownList>                   
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg col-xl-auto">
                <div class="row">
                    <div class="col-auto">
					    <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                        <asp:Button ID="btnProposals" runat="server" CssClass="btn btn-info btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Related Proposals" Enabled="false" OnClick="btnProposals_Click"  />
                        <asp:Button ID="btnProjects" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Related Projects" Enabled="false" OnClick="btnProjects_Click"  />
                        <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                    </div>                 
                </div>
            </div>
        </div>
        </div>
        <div class="col-12">
        <div class="row pt-3">
        <div class="col-12"></div>
        <div class="col-12"><h5 class="text-uppercase">Company Information</h5></div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Region</label>
        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRegion" runat="server" DataValueField="RegionID" DataTextField="Region" Enabled="false"></asp:DropDownList>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Branch</label>
        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCompanyBranch" runat="server" DataTextField="Branch" DataValueField="BranchID" OnSelectedIndexChanged="ddlCompanyBranch_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Name</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyName" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Address</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyAddress" runat="server" MaxLength="20" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>City</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" runat="server" MaxLength="25" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>State</label>
        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCompanyState" runat="server" DataTextField="State" DataValueField="StateID" Enabled="false"></asp:DropDownList>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Country</label>
        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCompanyCountry" runat="server" DataTextField="Country" DataValueField="CountryID" Enabled="false"></asp:DropDownList>                             
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Zip Code</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyZipCode" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Telephone</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyTelephone" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Toll Free</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyTollFree" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Fax</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyFax" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        </div>
        <div class="row border-top pt-3">
        <div class="col-12"><h5 class="text-uppercase">Inside Sales Support</h5></div>

        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>FirstName</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtISSFName" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>LastName</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtISSLName" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Address</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtISSSAddress" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Company</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtISSCompany" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>City</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtISSCity" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>State</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtISSState" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Country</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtISSCountry" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Phone</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtISSPhone" MaxLength="25" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Fax</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtISSFax" MaxLength="25" runat="server" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Cellphone</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtISSCellPhone" runat="server" MaxLength="25" Enabled="false"></asp:TextBox>
        </div>
        </div>
        <div class="col-sm-6 col-md-3">
        <div class="form-group">
        <label>Email</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtISSEmail" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
        </div>
        </div>
        </div>
        <div class="row border-top pt-3">
<div class="col-12"><h5 class="text-uppercase">Employee Information</h5></div>
<div class="col-12"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>First Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtFirstName" runat="server" MaxLength="50"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Last Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtLastName" runat="server" MaxLength="50"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Abbreviation ID</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlAbbreviation" runat="server" DataValueField="AbbreviationID" DataTextField="AbbreviationName" AutoPostBack="True"></asp:DropDownList>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Phone Mail</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPhoneMail" runat="server" MaxLength="20"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" runat="server" MaxLength="25"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Cell Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtCellPhone" runat="server" MaxLength="25"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3" style="display:none;">
<div class="form-group">
<label>Fax</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtDirectFax" runat="server" MaxLength="25"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Email</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-6 col-md-3 mt-3">
<div class="form-group">
<label>Status</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
<asp:ListItem></asp:ListItem>
<asp:ListItem Value="Active">Active</asp:ListItem>
<asp:ListItem Value="Quit">Quit</asp:ListItem>
<asp:ListItem Value="Retired">Retired</asp:ListItem>
<asp:ListItem Value="Temp. Leave">Temp. Leave</asp:ListItem>
</asp:DropDownList>                               
</div>
</div>

<div class="col-sm-6 col-md-3 mt-3 d-flex align-items-center">
<div class="form-check">
  <asp:CheckBox CssClass="form-check-input" ID="ChkHomeOffice" runat="server" />
  <label class="form-check-label" for="defaultCheck1">
    Mail Sent to Home Office
  </label>
</div>
</div>

</div>
        <div class="row border-top pt-3">
        <div class="col-12"><h5 class="text-uppercase">Home Office Information</h5></div>
        <div class="col-sm-6 col-md-3 mt-3">
        <div class="form-group">
        <label>Address</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" runat="server" MaxLength="50"></asp:TextBox>                               
        </div>
        </div>
        <div class="col-sm-6 col-md-3 mt-3">
        <div class="form-group">
        <label>City</label>
        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCity" runat="server" AutoPostBack="True" DataTextField="CityName" DataValueField="CityName"></asp:DropDownList>                               
        </div>
        </div>
        <div class="col-sm-6 col-md-3 mt-3">
        <div class="form-group">
        <label>State</label>
        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" runat="server" AutoPostBack="True" DataTextField="State" DataValueField="StateID"></asp:DropDownList>                               
        </div>
        </div>
        <div class="col-sm-6 col-md-3 mt-3">
        <div class="form-group">
        <label>Postal Code</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtPostCode" runat="server" MaxLength="20"></asp:TextBox>                               
        </div>
        </div>
        <div class="col-sm-6 col-md-3 mt-3">
        <div class="form-group">
        <label>Telephone</label>
        <asp:TextBox CssClass="form-control form-control-sm"  ID="txtTelephone" runat="server" MaxLength="25"></asp:TextBox>                               
        </div>
        </div>
        <div class="col-sm-6 col-md-3 mt-3">
        <div class="form-group">
        <label>Fax</label>
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtFax" runat="server" MaxLength="25"></asp:TextBox>                               
        </div>
        </div>
        </div>
        </div>
        </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger ControlID="btnProjects"></asp:PostBackTrigger>
        <asp:PostBackTrigger ControlID="btnProposals"></asp:PostBackTrigger>
        </Triggers>
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
           $('#<%=ddlSalesRepGroup.ClientID%>').chosen();
           $('#<%=ddlAbbreviation.ClientID%>').chosen();
           $('#<%=ddlCity.ClientID%>').chosen();
           $('#<%=ddlCompanyBranch.ClientID%>').chosen();
           $('#<%=ddlCompanyCountry.ClientID%>').chosen();
           $('#<%=ddlCompanyState.ClientID%>').chosen();
           $('#<%=ddlRegion.ClientID%>').chosen();
           $('#<%=ddlSalesRep.ClientID%>').chosen();
           $('#<%=ddlState.ClientID%>').chosen();
           $('#<%=ddlStatus.ClientID%>').chosen();
           $('#<%=ddlProductLineList.ClientID%>').chosen(); 
       }
    </script>
</asp:Content>