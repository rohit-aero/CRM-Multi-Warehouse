<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmAeroCommissions.aspx.cs" Inherits="Reports_frmAeroCommissions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-8">
        <div class="row pt-3 flex-column">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Aerowerks Commission Reports</h4>
                <%-- <h5 class="text-uppercase">Select Filters</h5>--%>
            </div>
            <%--            <div class="col-12">
                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
            </div>--%>
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
                        <div class="form-group chosenFullWidth">
                            <label>Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-auto mb-1">
                        <div class="form-group mb-0 flex-column">
                            <label>&nbsp;</label>
                            <div>
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnGenrate_Click" />
                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" runat="server" Text="Export To Excel" CausesValidation="false" OnClick="btnGenerateExcel_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" CausesValidation="false" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row border-top pt-3">
            <div class="col-12">
                <h5 class="text-uppercase">Select Report</h5>
            </div>
            <div class="col-sm-12 col-md">
                <div class="form-group srRadiosBtns">
                    <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large" onchange="showDiv()">
                        <asp:ListItem Value="0" Selected="True">Hobart Commission Report </asp:ListItem>
                        <asp:ListItem Value="6">Hobart Commission Pending Report</asp:ListItem>
                        <asp:ListItem Value="1">Internal Commission Report</asp:ListItem>
                        <asp:ListItem Value="2">Monthly Commission Report</asp:ListItem>
                        <asp:ListItem Value="3">Hobart Commission Payment Report</asp:ListItem>
                        <asp:ListItem Value="4">TragenFlex Commission Report</asp:ListItem>
                        <asp:ListItem Value="5">Government Sales Inc Commission Report</asp:ListItem>
                        <%--<asp:ListItem Value="7">Sale Rep Letters</asp:ListItem>
                        <asp:ListItem Value="8">Edward Don Summary Rebate Report</asp:ListItem>
                        <asp:ListItem Value="9">Edward Don Detail Rebate Report</asp:ListItem>--%>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>

        <div style="text-align: center; display: none" id="ShowDiv" runat="server">
            <div class="col-sm-auto">
                <div class="form-group chosenFullWidth">
                    <asp:Label ID="lblDealers" runat="server" Text="Rep Group"></asp:Label>
                    <asp:DropDownList ID="ddlIndividualSalesRep" runat="server" DataTextField="text" DataValueField="id">
                        <%--<asp:ListItem Value="-1">All</asp:ListItem>
                        <asp:ListItem Value="0">Burlis-Lawson Group</asp:ListItem>
                        <asp:ListItem Value="1">PMR</asp:ListItem>
                        <asp:ListItem Value="2">HRI</asp:ListItem>
                        <asp:ListItem Value="3">PBAC</asp:ListItem>
                        <asp:ListItem Value="4">Woolsey Associates</asp:ListItem>
                        <asp:ListItem Value="5">EPI</asp:ListItem>
                        <asp:ListItem Value="6">KLH</asp:ListItem>
                        <asp:ListItem Value="7">PMG</asp:ListItem>
                        <asp:ListItem Value="8">Squier</asp:ListItem>
                        <asp:ListItem Value="9">Hobart (All Regions)</asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <asp:GridView ID="grdMonthlyReports" runat="server" CssClass="HeaderFreez" AutoGenerateColumns="False"
            EnableModelValidation="True" OnDataBound="grdMonthlyReports_DataBound">
            <Columns>
                <asp:BoundField DataField="DateInvoiceSent" HeaderText="Invoice Date" DataFormatString="{0:dd/MM/yyyy}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice No">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="JobID" HeaderText="Job No">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ProjectName" HeaderText="Customer Name">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="RepNmae" HeaderText="Des. Rep">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="OrgRep" HeaderText="Org. Rep">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="NetEqPrice" HeaderText="Equipment Cost" DataFormatString="{0:C}">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="CommissionType" HeaderText="Comm %" DataFormatString="{0:C}">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Commission" HeaderText="Comm. Amt" DataFormatString="{0:C}">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="CompanyName" HeaderText="Dealer">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="PONumber" HeaderText="PO Number">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="DatePaymentReceived" HeaderText="Payment Received" DataFormatString="{0:dd/MM/yyyy}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="DatePaymentReceived" HeaderText="Comm. Due Date" DataFormatString="{0:dd/MM/yyyy}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                </asp:BoundField>
                <asp:BoundField DataField="DateCommissionPaid" HeaderText="Comm. Paid Date" DataFormatString="{0:dd/MM/yyyy}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="AeroChequeNum" HeaderText="Aerowerks Check No">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-4">
        <div class="row pt-3">
            <div class="d-flex align-items-center mb-2">
                <h4>
                    <strong>Help Section: </strong>
                </h4>
            </div>
            <div class="col-12 pt-2" runat="server" id="divHobartCommissionReport_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Hobart Commission Report</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                        <li><strong>Selected country</strong> projects are shown in the report.</li>
                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>                       
                        <li>Projects with <strong>Rate %</strong> <i>selected</i> are shown in the report.</li>
                        <li>Projects which has rep <strong>Aerowerks Inc</strong> and <strong>Tom Letizia</strong> are not shown in the report.</li>
                    </ul>
                </div>
            </div>

            <div class="col-12 pt-2" runat="server" id="divHobartCommissionPendingReport_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Hobart Commission Pending Report</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                        <li><strong>Selected country</strong> projects are shown in the report.</li>
                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>                       
                        <li>Projects which has no <strong>Commission Paid Date</strong> are shown in the report.</li>
                        <li>Projects which has rep <strong>Aerowerks Inc</strong> and <strong>Tom Letizia</strong> are not shown in the report.</li>                        
                    </ul>
                </div>
            </div>

            <div class="col-12 pt-2" runat="server" id="divInternalCommissionReport_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Internal Commission Report</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                        <li><strong>Selected country</strong> projects are shown in the report.</li>
                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>                       
                        <li>Projects with <strong>Rate %</strong> <i>selected</i> are shown in the report.</li>
                        <li>Projects which has rep <strong>Aerowerks Inc</strong> and <strong>Tom Letizia</strong> are not shown in the report.</li>
                    </ul>
                </div>
            </div>

            <div class="col-12 pt-2" runat="server" id="divMonthlyCommissionReport_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Monthly Commission Report</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                        <li><strong>Selected country</strong> projects are shown in the report.</li>
                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>                       
                        <li>Projects with <strong>Rate %</strong> <i>selected</i> are shown in the report.</li>
                        <li>Projects which has rep <strong>Aerowerks Inc</strong> and <strong>Tom Letizia</strong> are not shown in the report.</li>
                    </ul>
                </div>
            </div>

            <div class="col-12 pt-2" runat="server" id="divHobartCommissionPaymentReport_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Hobart Commission Payment Report</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Date Paid</strong>.</li>
                        <li><strong>Selected country</strong> projects are shown in the report.</li>
                        <li>Projects with <strong>Rate %</strong> <i>selected</i> are shown in the report.</li>
                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>                      
                        <li>Projects which has rep <strong>Tom Letizia</strong> are not shown in the report.</li>
                    </ul>
                </div>
            </div>

            <div class="col-12 pt-2" runat="server" id="divTragenFlexCommissionReport_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>TragenFlex Commission Report</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                        <li>Group name <i><strong>cannot be </strong></i><strong>TragenFlex, Unknown, Not Applicable</strong></li>
                        <li>Projects with Order for <strong>TragenFlex</strong> are shown in the report.</li>
                        <li>Projects with <strong>Rate %</strong> <i>selected</i> are shown in the report.</li>
                        <li>Selected <strong>country</strong> projects are shown in the report.</li>
                        <li>Selected <strong>Rep Group</strong> projects are shown in the report.</li>                       
                    </ul>
                </div>
            </div>

            <div class="col-12 pt-2" runat="server" id="divGovCommissionReport_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Government Sales Inc Commission Report</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                        <li>Projects which has rep <strong>Aerowerks Inc</strong> are not shown in the report.</li>
                        <li>Projects with dealer <strong>Government Sales LLC</strong> are shown in report</li>
                        <li>Projects with <strong>Rate %</strong> <i>selected</i> are shown in the report.</li>
                        <li><strong>Selected country</strong> projects are shown in the report.</li>                       
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script language="javascript" type="text/javascript">

        function showDiv() {
            var getSelectValue = $("input[name='ctl00$ContentPlaceHolder1$rdbList']:checked").val();
            var div = document.getElementById('<%=ShowDiv.ClientID%>');
            if (getSelectValue == "0") {
                document.getElementById('<%=divHobartCommissionReport_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divHobartCommissionPendingReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divInternalCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divMonthlyCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPaymentReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divTragenFlexCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divGovCommissionReport_HelpSection.ClientID%>').style.display = "none";
            } else if (getSelectValue == "6") {
                document.getElementById('<%=divHobartCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPendingReport_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divInternalCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divMonthlyCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPaymentReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divTragenFlexCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divGovCommissionReport_HelpSection.ClientID%>').style.display = "none";

            } else if (getSelectValue == "1") {
                document.getElementById('<%=divHobartCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPendingReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divInternalCommissionReport_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divMonthlyCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPaymentReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divTragenFlexCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divGovCommissionReport_HelpSection.ClientID%>').style.display = "none";
            } else if (getSelectValue == "2") {
                document.getElementById('<%=divHobartCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPendingReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divInternalCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divMonthlyCommissionReport_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divHobartCommissionPaymentReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divTragenFlexCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divGovCommissionReport_HelpSection.ClientID%>').style.display = "none";
            } else if (getSelectValue == "3") {
                document.getElementById('<%=divHobartCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPendingReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divInternalCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divMonthlyCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPaymentReport_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divTragenFlexCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divGovCommissionReport_HelpSection.ClientID%>').style.display = "none";
            } else if (getSelectValue == "4") {
                document.getElementById('<%=divHobartCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPendingReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divInternalCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divMonthlyCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPaymentReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divTragenFlexCommissionReport_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divGovCommissionReport_HelpSection.ClientID%>').style.display = "none";
            } else if (getSelectValue == "5") {
                document.getElementById('<%=divHobartCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPendingReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divInternalCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divMonthlyCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divHobartCommissionPaymentReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divTragenFlexCommissionReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divGovCommissionReport_HelpSection.ClientID%>').style.display = "block";
            }

    if (getSelectValue == "4") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}

$(document).ready(function () {
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
});

function PageLoaded(sender, args) {
    DDL();
}

$.when.apply($, PageLoaded).then(function () {
    DDL();
    hideAll();
});

function DDL() {
    $('#<%=ddlCountry.ClientID%>').chosen();
    $('#<%=ddlIndividualSalesRep.ClientID%>').chosen();
}

function hideAll() {
    document.getElementById('<%=divHobartCommissionReport_HelpSection.ClientID%>').style.display = "block";
    document.getElementById('<%=divHobartCommissionPendingReport_HelpSection.ClientID%>').style.display = "none";
    document.getElementById('<%=divInternalCommissionReport_HelpSection.ClientID%>').style.display = "none";
    document.getElementById('<%=divMonthlyCommissionReport_HelpSection.ClientID%>').style.display = "none";
    document.getElementById('<%=divHobartCommissionPaymentReport_HelpSection.ClientID%>').style.display = "none";
    document.getElementById('<%=divTragenFlexCommissionReport_HelpSection.ClientID%>').style.display = "none";
    document.getElementById('<%=divGovCommissionReport_HelpSection.ClientID%>').style.display = "none";
}

    </script>
</asp:Content>
