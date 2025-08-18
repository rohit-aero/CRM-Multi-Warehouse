<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmEmployees.aspx.cs" Inherits="ContactManagement_FrmEmployees" %>

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
                    <h4 class="title-hyphen position-relative">Employee Information</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                <div class="row">
                    <div class="col-sm-3 col-md-auto mb-3"><label class="mb-0">Employee</label></div>
                    <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                     <asp:DropDownList ID="ddlEmployee" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID"  AutoPostBack="True" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg col-xl-auto">
                <div class="row">
                    <div class="col-auto">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />                       
                    </div>                  
                </div>
            </div>
</div>
</div>
<div class="col-12">
<div class="row pt-3">
<div class="col-12"><h5 class="text-uppercase">Employee Information</h5></div>
<div class="col-12"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>First Name</label>
<asp:TextBox ID="txtFName" MaxLength="30" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>Department</label>
<asp:DropDownList ID="ddlDep" runat="server" DataTextField="CompetitorName" DataValueField="CompetitorID" CssClass="form-control form-control-sm">
                                                        <asp:ListItem Value="0"> </asp:ListItem>
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>EI</asp:ListItem>
                                                        <asp:ListItem>EC</asp:ListItem>
                                                        <asp:ListItem>IT</asp:ListItem>
                                                        <asp:ListItem>O</asp:ListItem>
                                                        <asp:ListItem>M</asp:ListItem>
                                                        <asp:ListItem>P</asp:ListItem>
                                                        <asp:ListItem>S</asp:ListItem>
                                                        <asp:ListItem>C</asp:ListItem>
                                                        <asp:ListItem>Q</asp:ListItem>
                                                    </asp:DropDownList>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>Last Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtLName" MaxLength="30" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>User Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtUserName" MaxLength="10" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>Street Address</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" MaxLength="50" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>Password</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPassword" MaxLength="10" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>City</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" MaxLength="30" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>Email Prefix</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPref" MaxLength="10" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>State</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtState" MaxLength="30" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>Country</label>
<asp:DropDownList CssClass="form-control form-control-sm" DataTextField="Country" DataValueField="CountryID" ID="ddlCountry" runat="server"></asp:DropDownList>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>Postal Code</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtZipCode" MaxLength="10" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>Telephone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" MaxLength="15" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>Cell Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtCell" MaxLength="15" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>Office Extension</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtExt" MaxLength="3" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group">
<label>Status</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server" DataTextField="Name" DataValueField="RepID">
<asp:ListItem></asp:ListItem>
<asp:ListItem Value="1">Active</asp:ListItem>
<asp:ListItem Value="0">Left</asp:ListItem>
</asp:DropDownList>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 col-lg">
<div class="form-group">
<label>Notes</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtNotes" runat="server" Height="80px" TextMode="MultiLine" ></asp:TextBox>
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
       $.when.apply($, PageLoaded).then(function ()
       {
           BindDrp();
       });

       function BindDrp()
       {
            $('#<%=ddlCountry.ClientID%>').chosen();  
            $('#<%=ddlDep.ClientID%>').chosen();  
            $('#<%=ddlEmployee.ClientID%>').chosen();  
            $('#<%=ddlStatus.ClientID%>').chosen();
        }
    </script>
</asp:Content>