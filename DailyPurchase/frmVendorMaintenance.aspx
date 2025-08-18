<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="frmVendorMaintenance.aspx.cs" Inherits="DailyPurchase_frmVendorMaintenance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HFVendorId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Vendor Maintenance</h4>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Vendors</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendorList" runat="server" DataTextField="text" DataValueField="Id" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlVendorList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" CausesValidation="false" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>

                            <div class="col-12">
                                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Vendor Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-4">
                        <div class="form-group">
                            <label class="text-danger">Vendor Name*</label>
                            <asp:TextBox ID="txtVendorName" CssClass="form-control form-control-sm" runat="server" MaxLength="50" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Lead Time Days</label>
                            <asp:TextBox ID="txtLeadTimeDays" CssClass="form-control form-control-sm text-right" MaxLength="5" runat="server" autocomplete="off" onkeypress="return onlyNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>                    

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Contact Person</label>
                            <asp:TextBox ID="txtContact" CssClass="form-control form-control-sm" MaxLength="50" runat="server" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:TextBox ID="txtPhone" CssClass="form-control form-control-sm" MaxLength="20" onblur="phoneMask(this)" runat="server" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Email*</label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control form-control-sm" MaxLength="50" oninput="emailMask(this)" runat="server" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-4">
                        <div class="form-group">
                            <label>Street Address</label>
                            <asp:TextBox ID="txtStreetAddress" CssClass="form-control form-control-sm" MaxLength="250" runat="server" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-4">
                        <div class="form-group">
                            <label>Notes</label>
                            <asp:TextBox ID="txtNotes" CssClass="form-control form-control-sm" MaxLength="250" runat="server" autocomplete="off"></asp:TextBox>
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
            $('#<%=ddlVendorList.ClientID%>').chosen();
        }
    </script>
</asp:Content>
