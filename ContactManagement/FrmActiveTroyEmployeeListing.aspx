<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmActiveTroyEmployeeListing.aspx.cs" Inherits="ContactManagement_FrmActiveTroyEmployeeListing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
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
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl-6">
                        <div class="row">
                            <div class="col-sm-auto col-md-auto mb-3">
                                <label class="mb-0">Troy Employee</label>
                            </div>
                            <div class="col-sm col-md mb-3">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTroyEmployee" runat="server" DataTextField="Name" DataValueField="RepID" OnSelectedIndexChanged="ddlTroyEmployee_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
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
                    <div class="col-12">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Company Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Company</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompany" MaxLength="50" runat="server" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Branch</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlBranch" runat="server" DataTextField="Name" DataValueField="BranchID" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Branch Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtBranchName" MaxLength="50" runat="server" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Company Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtBranchCompany" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Employee Information</h5>
                    </div>
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
                            <label>Abbreviation</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlAbbreviation" runat="server" DataTextField="Abbreviation" DataValueField="AbbreviationID" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Direct Phone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" onblur="phoneMask(this)" runat="server" MaxLength="25"></asp:TextBox>
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
                            <label>Direct Fax</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDirectFax" runat="server" MaxLength="25"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Cell Phone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCellPhone" onblur="phoneMask(this)" runat="server" MaxLength="25"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox CssClass="form-control form-control-sm" oninput="emailMask(this)" ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server" AutoPostBack="True">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="Active">Active</asp:ListItem>
                                <asp:ListItem Value="Quit">Quit</asp:ListItem>
                                <asp:ListItem Value="Retired">Retired</asp:ListItem>
                                <asp:ListItem Value="Temp. Leave">Temp. Leave</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>
                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Home Office Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>City</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCity" runat="server" DataTextField="CityName" DataValueField="CityName" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 mt-3">
                        <div class="form-group">
                            <label>State</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" runat="server" DataTextField="State" DataValueField="State" AutoPostBack="True"></asp:DropDownList>
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
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtTelephone" runat="server" MaxLength="25"></asp:TextBox>
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

            $('#<%=ddlTroyEmployee.ClientID%>').chosen();
        }
    </script>

</asp:Content>
