<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmDailyPurchaseParts.aspx.cs" Inherits="DailyPurchase_FrmDailyPurchaseParts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content_SalesActivity" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_SalesActivity" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Daily Purchase Parts</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Part #</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartHeaderList" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPartHeaderList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4 mt-2">
                        <div class="form-group">
                            <br />
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12">
                <div class="row">
                    <div class="col-12">
                        <h5 class="text-uppercase">PART INFORMATION</h5>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Part #*</label>
                            <asp:TextBox ID="txtPartNo" CssClass="form-control form-control-sm" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-4">
                        <div class="form-group">
                            <label>Part Description</label>
                            <asp:TextBox ID="txtPartDescription" CssClass="form-control form-control-sm" autocomplete="off" MaxLength="250" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>UM</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlUM" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Min Order Qty</label>
                            <asp:TextBox ID="txtMinOrderQty" CssClass="form-control form-control-sm text-right" autocomplete="off" MaxLength="5" runat="server" onkeypress="return onlNumbers(this, event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Max Stock Qty</label>
                            <asp:TextBox ID="txtMaxStockQty" CssClass="form-control form-control-sm text-right" autocomplete="off" MaxLength="5" runat="server" onkeypress="return onlyNumbers(this, event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Re-Order Point</label>
                            <asp:TextBox ID="txtReOrderPoint" CssClass="form-control form-control-sm text-right" autocomplete="off" MaxLength="5" runat="server" onkeypress="return onlyNumbers(this, event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Lead Time Days</label>
                            <asp:TextBox ID="txtLeadTimeDays" CssClass="form-control form-control-sm text-right" autocomplete="off" MaxLength="5" runat="server" onkeypress="return onlyNumbers(this, event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Preferred Vendor</label>
                            <asp:DropDownList ID="ddlVendor" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Product Line</label>
                            <asp:DropDownList ID="ddlProductLine" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
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
            $('#<%=ddlPartHeaderList.ClientID%>').chosen();
            $('#<%=ddlUM.ClientID%>').chosen();
            $('#<%=ddlVendor.ClientID%>').chosen();
            $('#<%=ddlProductLine.ClientID%>').chosen();
        }
    </script>
</asp:Content>
