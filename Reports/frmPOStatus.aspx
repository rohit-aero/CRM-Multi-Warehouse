<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmPOStatus.aspx.cs" Inherits="Reports_frmPOStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Search Purchase Order</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>By Source</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendor" runat="server" DataTextField="Source" DataValueField="SourceId" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>By Destination</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDestination" runat="server" DataTextField="Name" DataValueField="WareHouseID" AutoPostBack="True" OnSelectedIndexChanged="ddlDestination_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Order Date From*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtOrderDateFrom" runat="server" AutoPostBack="True" OnTextChanged="txtOrderDateFrom_TextChanged" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtOrderDateFrom"
                                TargetControlID="txtOrderDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Order Date To*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtOrderDateTo" runat="server" AutoPostBack="True" OnTextChanged="txtOrderDateTo_TextChanged" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtOrderDateTo" TargetControlID="txtOrderDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPOStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPOStatus_SelectedIndexChanged">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                <asp:ListItem Value="2">Close</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Purchase Order No*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPurchaseOrder" runat="server" DataValueField="PurchaseOrderID" DataTextField="PONumber"></asp:DropDownList>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md justify-content-center">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-sm" Text="Preview PO" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnDeletePO" runat="server" CssClass="btn btn-danger btn-sm" Text="Delete PO"
                            OnClientClick="return confirm('Are you sure you want to delete this PO ?');" CausesValidation="false" OnClick="btnDeletePO_Click" Enabled="false" />

                    </div>
                </div>
            </div>
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
                    $('#<%=ddlVendor.ClientID%>').chosen();
                    $('#<%=ddlDestination.ClientID%>').chosen();
                    $('#<%=ddlPOStatus.ClientID%>').chosen();
                    $('#<%=ddlPurchaseOrder.ClientID%>').chosen();
                }
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptGenerateReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
