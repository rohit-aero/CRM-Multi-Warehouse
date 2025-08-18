<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmYTDDealerRebate.aspx.cs" Inherits="Reports_frmYTDDealerRebate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-auto mx-auto innerMain">
        <div class="row pt-3 flex-column">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">YTD Individual Dealer Rebate</h4>
            </div>
            <%--<div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
            <div class="col-12">
                <div class="row">

                    <div class="col-6">
                        <div class="form-group">
                            <label>Select Dealer</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRebate" runat="server" DataTextField="CompanyName" DataValueField="DealerID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group mb-0 flex-column">
                            <label>&nbsp;</label>
                            <div>
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" OnClick="btnGenrate_Click" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" />
                                <asp:Button ID="btnExport" CssClass="btn btn-primary btn-sm" runat="server" Text="Export to Excel" CausesValidation="false" OnClick="btnExport_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="col-8 mx-auto">
        <!-- Help section on the right -->
        <div class="row pt-3">
            <div class="d-flex align-items-center mb-2">
                <h4>
                    <strong>Help Section: </strong>
                </h4>
            </div>
            <div class="col-12 pt-2" runat="server" id="divGrossPurchase_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>YTD Individual Dealer Rebate</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong> for <i>current year</i>.</li>
                        <li>Projects which has <strong>Invoice Number</strong> are shown in the reports.</li>
                        <li>Projects which has status <strong>Active/Confirmed</strong> are shown in the report. </li>
                    </ul>
                </div>
            </div>

        </div>
    </div>
    <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlRebate.ClientID%>').chosen();

        }
    </script>
</asp:Content>

