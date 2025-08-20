<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmContainerStatus.aspx.cs" Inherits="Reports_frmContainerStatus" %>

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
                            <h4 class="title-hyphen position-relative">Search Container</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-2 col-sm-2 col-md-2 col-lg-1">
                        <div class="form-group">
                            <label>By Vendor</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendor" runat="server" DataTextField="Source" DataValueField="SourceId" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-2 col-sm-2 col-md-2 col-lg-2">
                    <div class="form-group">
                            <label>By Destination</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDestination" runat="server" DataTextField="Name" DataValueField="WareHouseID" AutoPostBack="True" OnSelectedIndexChanged="ddlDestination_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Sent Date From</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSentDateFrom" runat="server" autocomplete="off" AutoPostBack="True" OnTextChanged="txtSentDateFrom_TextChanged" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="caltxtSentDateFrom" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtSentDateFrom" TargetControlID="txtSentDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Sent Date To</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSentDateTo" runat="server" autocomplete="off" AutoPostBack="True" OnTextChanged="txtSentDateTo_TextChanged" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="caltxtSentDateTo" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtSentDateTo" TargetControlID="txtSentDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-1">
                        <div class="form-group">
                            <label>Ship By</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShipmentBy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlShipmentBy_SelectedIndexChanged">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">By Sea</asp:ListItem>
                                <asp:ListItem Value="2">By Air</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-6 col-sm-4 col-md-3 col-lg-1">
                        <div class="form-group">
                            <label>By Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlContainerCheckStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlContainerCheckStatus_SelectedIndexChanged">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Invoice No./Container No.*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlContainerNo" runat="server" DataTextField="InvoiceNo" DataValueField="Containerid"></asp:DropDownList>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md justify-content-center">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-sm" Text="Preview Packing List" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />

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
                    //ddlContainerNo
                    $('#<%=ddlContainerNo.ClientID%>').chosen();
                    $('#<%=ddlContainerCheckStatus.ClientID%>').chosen();
                    $('#<%=ddlShipmentBy.ClientID%>').chosen();
                }
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptGenerateReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
