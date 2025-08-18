<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmCustomerCareReports.aspx.cs" Inherits="Reports_frmCustomerCareReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-md-12 mx-auto innerMain">
                        <div class="row pt-3 flex-column">
                            <div class="col-12">
                                <h4 class="title-hyphen position-relative mb-3">Aerowerks Customer Care Reports</h4>
                            </div>
                            <%--<div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-sm-auto">
                                        <div class="form-group">
                                            <label>Start Date</label>
                                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate"></asp:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="col-sm-auto">
                                        <div class="form-group">
                                            <label>End Date</label>
                                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate"></asp:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="col-sm-auto">
                                        <div class="form-group mb-0 flex-column">
                                            <label>&nbsp;</label>
                                            <div>
                                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnGenrate_Click" />
                                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" runat="server" CausesValidation="false" Text="Generate To Excel" OnClick="btnGenerateExcel_Click" />
                                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-6">
                        <!-- Main content area -->
                        <!-- Your main content here -->
                        <div class="row border-top pt-3">
                            <div class="col-12">
                                <h5 class="text-uppercase">Select Report</h5>
                            </div>
                            <div class="col-sm-12 col-md">
                                <div class="form-group srRadiosBtns">
                                    <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large" onchange="showDiv()">
                                        <%--<asp:ListItem Value="0" Selected="True" >By Released To Shop Date </asp:ListItem>
        <asp:ListItem Value="1" >By Ship to Arrive Date </asp:ListItem>--%>
                                        <asp:ListItem Value="2" Selected="True">CCT Project Report </asp:ListItem>
                                        <%--<asp:ListItem Value="3">View Daily Updated</asp:ListItem>--%>
                                        <asp:ListItem Value="4">Project Accessory</asp:ListItem>
                                        <asp:ListItem Value="5">Stock Status Report </asp:ListItem>
                                        <asp:ListItem Value="6">Stock Adjustment Report </asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-6">
                        <!-- Help section on the right -->
                        <div class="row pt-3">
                            <div class="d-flex align-items-center mb-2">
                                <h4>
                                    <strong>Help Section: </strong>
                                </h4>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divCCTProject_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>CCT Project Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Ship Date</strong>.</li>
                                        <li>Project Status <strong>Active/Confirmed</strong>.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divProjectAcc_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Project Accessory Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Ship Date</strong>.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divStockStatus_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Stock Status Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li><strong>Condition Not Found !</strong>.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divStockAdj_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Stock Adjustment Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li><strong>Condition Not Found !</strong>.</li>
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
            <asp:PostBackTrigger ControlID="btnGenerateExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptProdcutionReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script language="javascript" type="text/javascript">
        function showDiv() {
            var getSelectValue = $("input[name='ctl00$ContentPlaceHolder1$rdbList']:checked").val();

            if (getSelectValue == "2") {
                document.getElementById('<%=divCCTProject_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divProjectAcc_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divStockStatus_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divStockAdj_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "4") {
                document.getElementById('<%=divCCTProject_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divProjectAcc_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divStockStatus_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divStockAdj_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "5") {
                document.getElementById('<%=divCCTProject_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divProjectAcc_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divStockStatus_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divStockAdj_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "6") {
                document.getElementById('<%=divCCTProject_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divProjectAcc_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divStockStatus_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divStockAdj_HelpSection.ClientID%>').style.display = "block";
            }
            else {
                document.getElementById('<%=divCCTProject_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divProjectAcc_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divStockStatus_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divStockAdj_HelpSection.ClientID%>').style.display = "none";
            }
}
    </script>
</asp:Content>
