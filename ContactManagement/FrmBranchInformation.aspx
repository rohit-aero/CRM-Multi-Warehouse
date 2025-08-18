<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmBranchInformation.aspx.cs" Inherits="ContactManagement_FrmBranchInformation" %>

<%@ Register Assembly="AjaxControlToolKit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Search</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                     <div class="col-sm-6 col-md-7 col-lg-7 col-xl">
                        <div class="row">
                            <div class="col-2">
                                <div class="row">
                                    <div class="col-12 mb-3">
                                        <label class="mb-0">Business Division</label>
                                    </div>
                                    <div class="col-12 mb-3">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDivisionHeaderList" runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlDivisionHeader_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-3">
                                <div class="row">
                                    <div class="col-12 mb-3">
                                        <label class="mb-0">Rep Group</label>
                                    </div>
                                    <div class="col-12 mb-3">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRepGroupHeaderList" runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlRepGroupHeader_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-3">
                                <div class="row">
                                    <div class="col-12 mb-3">
                                        <label class="mb-0">Branch</label>
                                    </div>
                                    <div class="col-12 mb-3">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlbranch" runat="server" DataTextField="branch" DataValueField="BranchID" AutoPostBack="True" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="row">
                                    <div class="col-12 mb-3">
                                        <label class="mb-0">Rep</label>
                                    </div>
                                    <div class="col-12 mb-3">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRepHeaderList" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlRepHeaderList_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="row">
                                    <div class="col-12 mb-3">
                                        <label class="mb-0">&nbsp;</label>
                                    </div>
                                    <div class="col-12 mb-3">
                                        <asp:Button ID="btnSave" CssClass="btn btn-success btn-sm" runat="server" Text="Save" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Sales Rep Company's Branch Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Business Division*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDivision" runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Rep Group*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRepGroup" runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Branch Location*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtBranchLocation" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Branch Name*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtBranchName" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
<%--                    <div class="col-sm-6 col-md-3 d-flex align-items-center">
                        <div class="d-flex">
                            <div class="form-check pr-4">
                                <asp:CheckBox CssClass="form-check-input" ID="chkHobart" runat="server" />
                                <label class="form-check-label" for="chkHobart">
                                    Hobart Group
                                </label>
                            </div>
                            <div class="form-check">
                                <asp:CheckBox CssClass="form-check-input" ID="chkStero" runat="server" />
                                <label class="form-check-label" for="chkStero">
                                    Stero Group
                                </label>
                            </div>
                        </div>
                    </div>--%>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Region*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRegion" runat="server" DataTextField="Region" DataValueField="RegionID" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">company Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label class="text-danger">Company Name*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyName" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Street Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtStrAddress" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryId" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>State</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" runat="server" DataTextField="State" DataValueField="StateId" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" MaxLength="50" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Zip Code</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtZipCode" MaxLength="15" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Telephone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtTelephone" onblur="phoneMask(this)" MaxLength="20" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3" style="display: none;">
                        <div class="form-group">
                            <label>Fax Number</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFaxNumber" MaxLength="20" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Toll Free</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtTollFree" MaxLength="20" onblur="phoneMask(this)" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3" style="display: none;">
                        <div class="form-group">
                            <label>Toll Fax</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtTollFax" MaxLength="20" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-6 mt-3">
                        <div class="form-group">
                            <label>States Covered</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtStates" runat="server" AutoComplete="off" MaxLength="80"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3" style="display: none;">
                    <div class="col-12">
                        <h5 class="text-uppercase">Inside Sales Support Information </h5>
                    </div>
                    <div class="col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Name</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSaleName" runat="server" DataTextField="ISSName" DataValueField="RepID" AutoPostBack="true" OnSelectedIndexChanged="ddlSaleName_SelectedIndexChanged1"></asp:DropDownList>
                        </div>
                    </div>
                    <div class=" col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Company</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleCompany" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleAddress" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSaleCountry" runat="server" DataTextField="Country" DataValueField="CountryId" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>State</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSaleState" runat="server" DataTextField="State" DataValueField="StateId" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleCity" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Telephone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleTelephone" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Cell Phone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleCellPhone" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Fax </label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleFax" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSaleEmail" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
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
            $('#<%=ddlDivisionHeaderList.ClientID%>').chosen();
            $('#<%=ddlRepGroupHeaderList.ClientID%>').chosen();
            $('#<%=ddlRepHeaderList.ClientID%>').chosen();
            $('#<%=ddlRepGroup.ClientID%>').chosen();
            $('#<%=ddlDivision.ClientID%>').chosen();
            $('#<%=ddlbranch.ClientID%>').chosen();
            $('#<%=ddlRegion.ClientID%>').chosen();
            $('#<%=ddlCountry.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
            $('#<%=ddlSaleName.ClientID%>').chosen();
            $('#<%=ddlSaleState.ClientID%>').chosen();
            $('#<%=ddlSaleCountry.ClientID%>').chosen();
        }
    </script>
</asp:Content>
