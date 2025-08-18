<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="rptHobartCanadaSale.aspx.cs" Inherits="Reports_rptHobartCanadaSale" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-auto mx-auto innerMain">
        <div class="row pt-3">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Hobart Canada Sales</h4>
            </div>
            <%--<div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
            <div class="col-7">
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
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnGenrate_Click" />
                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" CausesValidation="false" runat="server" Text="Export to Excel" OnClick="btnGenerateExcel_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" CausesValidation="false" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row border-top pt-3">
                    <%--<div class="row">--%>
                    <div class="col-12">
                        <h5 class="text-uppercase">
                        Select Report
                    </div>
                    <div class="col-sm-12 col-md">
                        <div class="form-group srRadiosBtns">
                            <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large" onchange="HelpSectionHandler()">
                                <%-- <asp:ListItem Value="0" Selected="True">Year to Date</asp:ListItem>--%>
                                <asp:ListItem Value="1" Selected="True">By Monthly</asp:ListItem>
                                <asp:ListItem Value="2">By Province</asp:ListItem>
                                <asp:ListItem Value="3">By Province with Sales Rep</asp:ListItem>
                                <asp:ListItem Value="4">Year To Date</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <%--</div>--%>
                </div>
            </div>
            <div class="col-4">
                <div class="row pt-3">
                    <div class="d-flex align-items-center mb-2">
                        <h4>
                            <strong>Help Section: </strong>
                        </h4>
                    </div>
                    <div class="col-12 pt-2" runat="server" id="divByMonthly_HelpSection">
                        <div class="d-flex align-items-center mb-2">
                            <h5>
                                <strong>By Monthly</strong>
                            </h5>
                        </div>
                        <div class="col-12">
                            <ul>
                                <li>Date is based on <strong>Invoice Date</strong>.</li>
                                <li><strong>Active & Confirmed</strong> projects are shown the report.</li>
                                <li>Projects which has <strong>Invoice Date</strong> are shown in the report.</li>
                                <li><strong>Canada</strong> projects are shown in the report.</li>
                                <%--<li><strong>Aerowerks</strong> branch projects are shown in the report.</li>--%>
                                <li>Projects which has rep <strong>Aerowerks Inc</strong> are not shown in the report.</li>
                            </ul>
                        </div>
                    </div>

                    <div class="col-12 pt-2" runat="server" id="divByProvince_HelpSection">
                        <div class="d-flex align-items-center mb-2">
                            <h5>
                                <strong>By Province</strong>
                            </h5>
                        </div>
                        <div class="col-12">
                            <ul>
                                <li>Date is based on <strong>Invoice Date</strong>.</li>
                                <li><strong>Active & Confirmed</strong> projects are shown the report.</li>
                                <li>Projects which has <strong>Invoice Date</strong> are shown in the report.</li>
                                <li><strong>CAD</strong> currency projects are shown in the report.</li>
                                <li><strong>Canada</strong> projects are shown in the report.</li>
                                <%--<li><strong>Aerowerks</strong> branch projects are shown in the report.</li>--%>
                                <li>Projects which has rep <strong>Aerowerks Inc</strong> are not shown in the report.</li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-12 pt-2" runat="server" id="divbyProvinceWithSalesRep_HelpSection">
                        <div class="d-flex align-items-center mb-2">
                            <h5>
                                <strong>By Province with Sales Rep</strong>
                            </h5>
                        </div>
                        <div class="col-12">
                            <ul>
                                <li>Date is based on <strong>Invoice Date</strong>.</li>
                                <li><strong>Active & Confirmed</strong> projects are shown the report.</li>
                                <li>Projects which has <strong>Invoice Date</strong> are shown in the report.</li>
                                <li><strong>Canada</strong> projects are shown in the report.</li>
                                <%--<li><strong>Aerowerks</strong> branch projects are shown in the report.</li>--%>
                                <li>Projects which has rep <strong>Aerowerks Inc</strong> are not shown in the report.</li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-12 pt-2" runat="server" id="divYearToDate_HelpSection">
                        <div class="d-flex align-items-center mb-2">
                            <h5>
                                <strong>Year To Date</strong>
                            </h5>
                        </div>
                        <div class="col-12">
                            <ul>
                                <li>Date is based on <strong>Invoice Date</strong>.</li>
                                <li><strong>Active & Confirmed</strong> projects are shown the report.</li>
                                <li>Projects which has <strong>Invoice Date</strong> are shown in the report.</li>
                                <li><strong>Canada</strong> projects are shown in the report.</li>
                                <li><strong>CAD & USD</strong> currency projects are shown in the report.</li>
                                <%--<li><strong>Aerowerks</strong> branch projects are shown in the report.</li>--%>
                                <li>Projects which has rep <strong>Aerowerks Inc</strong> are not shown in the report.</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script language="javascript" type="text/javascript">
        function HelpSectionHandler() {
            var getSelectValue = $("input[name='ctl00$ContentPlaceHolder1$rdbList']:checked").val();

            if (getSelectValue) {
                if (getSelectValue == "1") {
                    document.getElementById('<%=divByMonthly_HelpSection.ClientID%>').style.display = "block";
                    document.getElementById('<%=divByProvince_HelpSection.ClientID%>').style.display = "none";
                    document.getElementById('<%=divbyProvinceWithSalesRep_HelpSection.ClientID%>').style.display = "none";
                    document.getElementById('<%=divYearToDate_HelpSection.ClientID%>').style.display = "none";
                } else if (getSelectValue == "2") {
                    document.getElementById('<%=divByMonthly_HelpSection.ClientID%>').style.display = "none";
                    document.getElementById('<%=divByProvince_HelpSection.ClientID%>').style.display = "block";
                    document.getElementById('<%=divbyProvinceWithSalesRep_HelpSection.ClientID%>').style.display = "none";
                    document.getElementById('<%=divYearToDate_HelpSection.ClientID%>').style.display = "none";
                } else if (getSelectValue == "3") {
                    document.getElementById('<%=divByMonthly_HelpSection.ClientID%>').style.display = "none";
                    document.getElementById('<%=divByProvince_HelpSection.ClientID%>').style.display = "none";
                    document.getElementById('<%=divbyProvinceWithSalesRep_HelpSection.ClientID%>').style.display = "block";
                    document.getElementById('<%=divYearToDate_HelpSection.ClientID%>').style.display = "none";
                } else if (getSelectValue == "4") {
                    document.getElementById('<%=divByMonthly_HelpSection.ClientID%>').style.display = "none";
                    document.getElementById('<%=divByProvince_HelpSection.ClientID%>').style.display = "none";
                    document.getElementById('<%=divbyProvinceWithSalesRep_HelpSection.ClientID%>').style.display = "none";
                    document.getElementById('<%=divYearToDate_HelpSection.ClientID%>').style.display = "block";
                }
        } else {
            document.getElementById('<%=divByMonthly_HelpSection.ClientID%>').style.display = "none";
                        document.getElementById('<%=divByProvince_HelpSection.ClientID%>').style.display = "none";
                        document.getElementById('<%=divbyProvinceWithSalesRep_HelpSection.ClientID%>').style.display = "none";
                        document.getElementById('<%=divYearToDate_HelpSection.ClientID%>').style.display = "none";
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
            HelpSectionHandler();
        });
        function DDL() {

        }
    </script>
</asp:Content>
