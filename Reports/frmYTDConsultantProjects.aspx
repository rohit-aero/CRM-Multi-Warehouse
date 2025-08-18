<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmYTDConsultantProjects.aspx.cs" Inherits="Reports_frmYTDConsultantProjects" %>

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
                                    <h4 class="title-hyphen position-relative mb-3">YTD Consultant Projects</h4>
                                </div>
                                <%--<div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
                                <div class="col-12">
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label>Start Date</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate"></asp:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label>End Date</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate"></asp:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group chosenFullWidth">
                                                <label>Select Consultant</label>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlConsultant" runat="server" DataTextField="CompanyName" DataValueField="ConsultantID">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="form-group srRadiosBtns">
                                                <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large" onchange="showDiv();">
                                                    <asp:ListItem Value="1" Selected="True">Sales Report </asp:ListItem>
                                                    <asp:ListItem Value="2">Prime Spec Report</asp:ListItem>
                                                    <asp:ListItem Value="3">Alternate Report</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group mb-0 flex-column">
                                                <label></label>
                                                <div>
                                                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnGenrate_Click1" />
                                                    <asp:Button ID="btnExport" CssClass="btn btn-primary btn-sm" runat="server" Text="Export to Excel" Enabled="false" Visible="false" />
                                                    <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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
                            <div class="col-12 pt-2" runat="server" id="divSales_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Sales Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                                        <li>Projects which has <strong>Invoice Number</strong> are shown in the report.</li>
                                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                                        <li>Projects which has consultant <strong>company name</strong> present are shown in the report.</li>
                                        <li>Projects which are <strong>Active/confirmed</strong> are shown in the reports.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divPrimeSpec_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Prime Spec Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Proposal Date</strong>.</li>
                                        <li>Projects which has <strong>Invoice Number</strong> are shown in the report.</li>
                                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                                        <li>Projects which has consultant <strong>company name</strong> present are shown in the report.</li>
                                        <li>Projects which are <strong>Active/confirmed</strong> are shown in the reports.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divAlternate_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Alternate Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Proposal Date</strong>.</li>
                                        <li>Projects which has <strong>Invoice Number</strong> are shown in the report.</li>
                                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                                        <li>Projects which has consultant <strong>company name</strong> present are shown in the report.</li>
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
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
    </asp:UpdatePanel>
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
            $('#<%=ddlConsultant.ClientID%>').chosen();

        }

        function showDiv() {
            var getSelectValue = $("input[name='ctl00$ContentPlaceHolder1$rdbList']:checked").val();
            if (getSelectValue == "1") {
                document.getElementById('<%=divSales_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divPrimeSpec_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divAlternate_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "2") {
                document.getElementById('<%=divSales_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divPrimeSpec_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divAlternate_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "3") {
                document.getElementById('<%=divSales_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divPrimeSpec_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divAlternate_HelpSection.ClientID%>').style.display = "block";
            }
            else {
                document.getElementById('<%=divSales_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divPrimeSpec_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divAlternate_HelpSection.ClientID%>').style.display = "none";
            }
}
    </script>
</asp:Content>

