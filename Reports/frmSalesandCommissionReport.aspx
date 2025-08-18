<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmSalesandCommissionReport.aspx.cs" Inherits="Reports_frmSalesandCommissionReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-8">
                        <!-- Main content area -->
                        <!-- Your main content here -->
                        <div class="col-md-auto mx-auto innerMain">
                            <div class="row pt-3 flex-column">
                                <div class="col-12">
                                    <h4 class="title-hyphen position-relative mb-3">Hobart Sales and Commission Reports</h4>
                                    <%-- <h5 class="text-uppercase">Select Filters</h5>--%>
                                </div>
                                <%--            <div class="col-12">
                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
            </div>--%>
                                <div class="col-12">
                                    <div class="row">
                                        <div class="row border-top pt-3">
                                            <div class="col-12">
                                                <h5 class="text-uppercase">Select Report</h5>
                                            </div>
                                            <div class="col-sm-12 col-md">
                                                <div class="form-group srRadiosBtns">
                                                    <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large" onchange="showDiv();">
                                                        <asp:ListItem Value="0" Selected="True">Sales and Commission Summary Report </asp:ListItem>
                                                        <asp:ListItem Value="1">Opportunities Report</asp:ListItem>
                                                        <asp:ListItem Value="2">Sales Report </asp:ListItem>
                                                        <asp:ListItem Value="3">Opportunities Report Rep Group Wise</asp:ListItem>
                                                        <asp:ListItem Value="4">Sales Report Rep Group Wise</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="col-sm-auto">
                                                    <div class="form-group">
                                                        <label>Year</label>
                                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlYear" DataTextField="year" DataValueField="year" runat="server">
                                                            <%--  <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="2019">2019</asp:ListItem>
                                <asp:ListItem Value="2020">2020</asp:ListItem>
                                <asp:ListItem Value="2021">2021</asp:ListItem>
                                <asp:ListItem Value="2022">2022</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-sm-auto">
                                                    <div class="form-group mb-0 flex-column">
                                                        <label>&nbsp;</label>
                                                        <div>
                                                            <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnGenrate_Click" />
                                                            <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" CausesValidation="false" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-4">
                        <!-- Help section on the right -->
                        <div class="row pt-3">
                            <div class="d-flex align-items-center mb-2">
                                <h4>
                                    <strong>Help Section: </strong>
                                </h4>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divSalesandCommSummary_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Sales and Commission Summary Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Commission Paid Date</strong>.</li>
                                        <li><strong>US</strong> projects are shown in the report.</li>
                                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                                        <li>Projects with <strong>Rate %</strong> <i>selected</i> are shown in the report.</li>
                                        <li>Projects which are <strong>Active/confirmed</strong> are shown in the reports.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divOpportunityReport_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Opportunities Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Proposal Date</strong>.</li>
                                        <li>Proposals with <strong>Proposal Number</strong> are shown in report.</li>
                                        <li>Proposals <strong>without Job ID#</strong> are shown in the report.</li>
                                        <li><strong>US</strong> Projects are shown in the report.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divSalesReport_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Sales Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                                        <li><strong>US</strong> projects are shown in the reports.</li>
                                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                                        <li>Projects which are <strong>Active/confirmed</strong> are shown in the reports.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divOpportunityReportRepGroupWise_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Opportunities Report Rep Group Wise</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Proposal Date</strong>.</li>
                                        <li>Proposals with <strong>Proposal Number</strong> are shown in report.</li>
                                        <li>Proposals <strong>without Job ID#</strong> are shown in the report.</li>
                                        <li><strong>US</strong> Projects are shown in the report.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divOSalesReportRepGroupWise_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Sales Report Rep Group Wise</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                                        <li><strong>US</strong> Projects are shown in the report.</li>
                                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                                        <li>Projects which are <strong>Active/confirmed</strong> are shown in the reports.</li>
                                    </ul>
                                </div>
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
    <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script language="javascript" type="text/javascript">
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
            $('#<%=ddlYear.ClientID%>').chosen();
        }
        function showDiv() {
            console.log('Test');
            var getSelectValue = $("input[name='ctl00$ContentPlaceHolder1$rdbList']:checked").val();
            if (getSelectValue == "0") {
                document.getElementById('<%=divSalesandCommSummary_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divOpportunityReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSalesReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOpportunityReportRepGroupWise_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOSalesReportRepGroupWise_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "1") {
                document.getElementById('<%=divSalesandCommSummary_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOpportunityReport_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divSalesReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOpportunityReportRepGroupWise_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOSalesReportRepGroupWise_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "2") {
                document.getElementById('<%=divSalesandCommSummary_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOpportunityReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSalesReport_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divOpportunityReportRepGroupWise_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOSalesReportRepGroupWise_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "3") {
                document.getElementById('<%=divSalesandCommSummary_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOpportunityReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSalesReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOpportunityReportRepGroupWise_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divOSalesReportRepGroupWise_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "4") {
                document.getElementById('<%=divSalesandCommSummary_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOpportunityReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSalesReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOpportunityReportRepGroupWise_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOSalesReportRepGroupWise_HelpSection.ClientID%>').style.display = "block";
            }
            else {
                document.getElementById('<%=divSalesandCommSummary_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOpportunityReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSalesReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOpportunityReportRepGroupWise_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divOSalesReportRepGroupWise_HelpSection.ClientID%>').style.display = "none";
            }
}
    </script>
</asp:Content>
