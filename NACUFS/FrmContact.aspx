<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmContact.aspx.cs" Inherits="NACUFS_FrmContact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Contact Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">University</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3">
                                <asp:DropDownList ID="ddlUniv" CssClass="form-control form-control-sm" runat="server" DataTextField="UniName" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlUniv_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Campus</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3">
                                <asp:DropDownList ID="ddlCampus" CssClass="form-control form-control-sm" runat="server" DataTextField="CampusName" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Contact</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3">
                                <asp:DropDownList ID="ddlContacts" CssClass="form-control form-control-sm" runat="server" DataTextField="Contact" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlContacts_SelectedIndexChanged"></asp:DropDownList>
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
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Contact Details</h5>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>First Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFName" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Last Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtLName" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Designation</label>
                            <asp:DropDownList ID="ddldesg" CssClass="form-control form-control-sm" runat="server" DataTextField="DesgName" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" onblur="phoneMask(this)" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtEml" oninput="emailMask(this)" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Street Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtStreet" autocomplete="off" MaxLength="250" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Zip Code</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtZipCode" autocomplete="off" MaxLength="10" runat="server"></asp:TextBox>
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
            $('#<%=ddlUniv.ClientID%>').chosen();
            $('#<%=ddlContacts.ClientID%>').chosen();
            $('#<%=ddlCampus.ClientID%>').chosen();
            $('#<%=ddldesg.ClientID%>').chosen();
            
        }
    </script>

</asp:Content>

