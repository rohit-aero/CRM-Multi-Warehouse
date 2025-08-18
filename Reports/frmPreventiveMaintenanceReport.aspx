<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="frmPreventiveMaintenanceReport.aspx.cs" Inherits="Reports_frmPreventiveMaintenanceReport" %>

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
                            <h4 class="title-hyphen position-relative">Aerowerks Preventive Maintenance Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row w-75 mx-auto justify-content-center">
                    <div class="col-6">
                        <div class="form-group">
                            <label>JobID</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlJob" DataTextField="ProjectName" DataValueField="JobID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlStatus" DataTextField="Name" DataValueField="ID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 ">
                        <div class="form-group">
                            <label>PO Rec. Date From</label>
                            <asp:TextBox ID="txtPORecDateFrom" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtPORecDateFromExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtPORecDateFrom" TargetControlID="txtPORecDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 ">
                        <div class="form-group">
                            <label>PO Rec. Date To</label>
                            <asp:TextBox ID="txtPORecDateTo" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtPORecDateToExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtPORecDateTo" TargetControlID="txtPORecDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 ">
                        <div class="form-group">
                            <label>Contract Start Date From</label>
                            <asp:TextBox ID="txtContractStartDateFrom" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtContractStartDateFromExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtContractStartDateFrom" TargetControlID="txtContractStartDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 ">
                        <div class="form-group">
                            <label>Contract Start Date To</label>
                            <asp:TextBox ID="txtContractStartDateTo" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtContractStartDateToExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtContractStartDateTo" TargetControlID="txtContractStartDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-6 ">
                        <div class="form-group">
                            <label>Contract End Date From</label>
                            <asp:TextBox ID="txtContractEndDateFrom" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtContractEndDateFromExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtContractEndDateFrom" TargetControlID="txtContractEndDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 ">
                        <div class="form-group">
                            <label>Contract End Date To</label>
                            <asp:TextBox ID="txtContractEndDateTo" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtContractEndDateToExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtContractEndDateTo" TargetControlID="txtContractEndDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-6 ">
                        <div class="form-group">
                            <label>Invoice Date From</label>
                            <asp:TextBox ID="txtInvoiceDateFrom" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtInvoiceDateFromExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtInvoiceDateFrom" TargetControlID="txtInvoiceDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-6 ">
                        <div class="form-group">
                            <label>Invoice Date To</label>
                            <asp:TextBox ID="txtInvoiceDateTo" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtInvoiceDateToExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtInvoiceDateTo" TargetControlID="txtInvoiceDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-md-auto">
                                <%--<asp:Button ID="btnSearch" runat="server" CssClass="btn btn-secondary btn-sm" Text="Search" OnClick="btnSearch_Click" />--%>
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" OnClick="btnGenrate_Click" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" />
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenrate" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptTickets" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlJob.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
        }
    </script>
</asp:Content>
