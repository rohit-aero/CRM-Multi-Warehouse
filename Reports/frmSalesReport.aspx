<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmSalesReport.aspx.cs" Inherits="Reports_frmSpecCredit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row mx-auto innerMain">
        <div class="col-7 row pt-3">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Other Sales Reports</h4>
            </div>
            <%--    <div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
            <div class="col-12">
                <div class="row">
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Start Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate"></asp:CalendarExtender>

                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>End Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate"></asp:CalendarExtender>

                        </div>
                    </div>

                    <div class="col-sm-8">
                        <div class="form-group flex-column">
                            <label>&nbsp;</label>
                            <div>
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnGenrate_Click" />
                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" CausesValidation="false" runat="server" Text="Export to Excel" OnClick="btnGenerateExcel_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-7 row border-top pt-3">
            <div class="col-12">
                <h5 class="text-uppercase">Filter Records</h5>
            </div>
            <div class="col-sm-12 col-md">
                <asp:UpdatePanel ID="up1" runat="server">
                    <ContentTemplate>
                        <div class="form-group srRadiosBtns">
                            <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large" onchange="showDiv()">
                                <asp:ListItem Value="0" Selected>By State</asp:ListItem>
                                <asp:ListItem Value="4">By Sales Rep</asp:ListItem>
                                <asp:ListItem Value="2">By Dealer</asp:ListItem>
                                <asp:ListItem Value="3">By Consultant</asp:ListItem>
                                <asp:ListItem Value="1">By Conveyor Model</asp:ListItem>
                                <asp:ListItem Value="5">By Conveyor Type</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-sm-12 col-md">
                <div id="ShowDiv0" class="row" style="display: none;">
                    <div class="col-sm-auto">
                        <label class="mb-0">Select Country</label>
                    </div>
                    <div class="col-sm chosenFullWidth">
                        <asp:DropDownList ID="ddlCountry" CssClass="form-control form-control-sm w-auto" runat="server" DataTextField="Country" DataValueField="CountryID">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="ShowDiv1" class="row" style="display: none;">
                    <div class="col-sm-auto">
                        <label class="mb-0">Select Conveyor Model</label>
                    </div>
                    <div class="col-sm chosenFullWidth">
                        <asp:DropDownList ID="ddlModel" CssClass="form-control form-control-sm w-auto" runat="server" DataTextField="ModelName" DataValueField="ModelID">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="ShowDiv2" class="row" style="display: none;">
                    <div class="col-sm-auto">
                        <label class="mb-0">Select Dealer</label>
                    </div>
                    <div class="col-sm chosenFullWidth">
                        <asp:DropDownList ID="ddlDealer" CssClass="form-control form-control-sm w-auto" runat="server" DataTextField="CompanyName" DataValueField="DealerID">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="ShowDiv3" class="row" style="display: none;">
                    <div class="col-sm-auto">
                        <label class="mb-0">Select Consultant</label>
                    </div>
                    <div class="col-sm chosenFullWidth">
                        <asp:DropDownList ID="ddlConsultant" CssClass="form-control form-control-sm w-auto" runat="server" DataTextField="CompanyName" DataValueField="ConsultantID">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="ShowDiv4" class="row" style="display: none;">
                    <div class="col-sm-auto">
                        <label class="mb-0">Select Sales Rep</label>
                    </div>
                    <div class="col-sm chosenFullWidth">
                        <asp:DropDownList ID="ddlRep" CssClass="form-control form-control-sm w-auto" runat="server" DataTextField="RepName" DataValueField="RepID">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="ShowDiv5" class="row" style="display: none;">
                    <div class="col-sm-auto">
                        <label class="mb-0">Select Conveyor Type</label>
                    </div>
                    <div class="col-sm chosenFullWidth">
                        <asp:DropDownList ID="ddlType" CssClass="form-control form-control-sm w-auto" runat="server" DataTextField="ConveyorType" DataValueField="ConveyorTypeID">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

        </div>
        <div class="col-4">
            <div class="row pt-3">
                <div class="d-flex align-items-center mb-2">
                    <h4>
                        <strong>Help Section: </strong>
                    </h4>
                </div>
                <div class="col-12 pt-2" id="divByStates_HelpSection">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>By States</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Date is based on <strong>Invoice Date</strong>.</li>
                            <li><strong>Active & Confirmed</strong> projects are shown the report.</li>
                            <li>Projects which has <strong>NetEqPrice</strong> greater then zero are shown in the report.</li>
                            <li>Selected country projects are shown in the report.</li>
                        </ul>
                    </div>
                </div>
                <%-- divByStates_HelpSection 0 --%>
                <div class="col-12 pt-2" id="divBySalesRep_HelpSection">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>By Sales Rep</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Date is based on <strong>Invoice Date</strong>.</li>
                            <li><strong>Active & Confirmed</strong> projects are shown the report.</li>
                            <li>Projects which has <strong>NetEqPrice</strong> greater then zero are shown in the report.</li>
                            <li>Selected Sales Rep projects are shown in the report.</li>
                        </ul>
                    </div>
                </div>
                <%-- divBySalesRep_HelpSection 4 --%>
                <div class="col-12 pt-2" id="divByDealer_HelpSection">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>By Dealer</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Date is based on <strong>Invoice Date</strong>.</li>
                            <li><strong>Active & Confirmed</strong> projects are shown the report.</li>
                            <li>Projects which has <strong>NetEqPrice</strong> greater then zero are shown in the report.</li>
                            <li>Selected dealer projects are shown in the report.</li>
                        </ul>
                    </div>
                </div>
                <%--divByDealer_HelpSection 2 --%>
                <div class="col-12 pt-2" id="divByConsultant_HelpSection">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>By Consultant</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Date is based on <strong>Invoice Date</strong>.</li>
                            <li><strong>Active & Confirmed</strong> projects are shown the report.</li>
                            <li>Projects which has <strong>NetEqPrice</strong> greater then zero are shown in the report.</li>
                            <li>Selected Consultant projects are shown in the report.</li>
                        </ul>
                    </div>
                </div>
                <%--divByConsultant_HelpSection 3 --%>
                <div class="col-12 pt-2" id="divByConveyorModel_HelpSection">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>By Conveyor Model</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Date is based on <strong>Invoice Date</strong>.</li>
                            <li><strong>Active & Confirmed</strong> projects are shown the report.</li>
                            <li>Projects which has <strong>NetEqPrice</strong> greater then zero are shown in the report.</li>
                            <li>Selected Conveyor Models projects are shown in the report.</li>
                        </ul>
                    </div>
                </div>
                <%--divByConveyorModel_HelpSection 1 --%>
                <div class="col-12 pt-2" id="divByConveyorType_HelpSection">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>By Conveyor Type</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Date is based on <strong>Invoice Date</strong>.</li>
                            <li><strong>Active & Confirmed</strong> projects are shown the report.</li>
                            <li>Projects which has <strong>NetEqPrice</strong> greater then zero are shown in the report.</li>
                            <li>Selected Conveyor Type projects are shown in the report.</li>
                        </ul>
                    </div>
                </div>
                <%--divByConveyorType_HelpSection 5 --%>
            </div>
        </div>
        <CR:CrystalReportViewer ID="rptSpecCreditReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnGenrate" />
                <asp:PostBackTrigger ControlID="btnGenerateExcel" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <script language="javascript" type="text/javascript">
        function showDiv() {
            var getSelectValue = $('#<%= rdbList.ClientID %> input:checked').val();
            //By State
            if (getSelectValue == '0') {
                document.getElementById("ShowDiv0").style.display = "block";
                document.getElementById("ShowDiv1").style.display = "none";
                document.getElementById("ShowDiv2").style.display = "none";
                document.getElementById("ShowDiv3").style.display = "none";
                document.getElementById("ShowDiv4").style.display = "none";
                document.getElementById("ShowDiv5").style.display = "none";

                document.getElementById("divByStates_HelpSection").style.display = "block";
                document.getElementById("divByConveyorModel_HelpSection").style.display = "none";
                document.getElementById("divByDealer_HelpSection").style.display = "none";
                document.getElementById("divByConsultant_HelpSection").style.display = "none";
                document.getElementById("divBySalesRep_HelpSection").style.display = "none";
                document.getElementById("divByConveyorType_HelpSection").style.display = "none";
            }
                //By Conveyor Model
            else if (getSelectValue == '1') {
                document.getElementById("ShowDiv1").style.display = "block";
                document.getElementById("ShowDiv0").style.display = "none";
                document.getElementById("ShowDiv2").style.display = "none";
                document.getElementById("ShowDiv3").style.display = "none";
                document.getElementById("ShowDiv4").style.display = "none";
                document.getElementById("ShowDiv5").style.display = "none";

                document.getElementById("divByConveyorModel_HelpSection").style.display = "block";
                document.getElementById("divByStates_HelpSection").style.display = "none";
                document.getElementById("divByDealer_HelpSection").style.display = "none";
                document.getElementById("divByConsultant_HelpSection").style.display = "none";
                document.getElementById("divBySalesRep_HelpSection").style.display = "none";
                document.getElementById("divByConveyorType_HelpSection").style.display = "none";
            }
                //By Dealer
            else if (getSelectValue == '2') {
                document.getElementById("ShowDiv2").style.display = "block";
                document.getElementById("ShowDiv0").style.display = "none";
                document.getElementById("ShowDiv1").style.display = "none";
                document.getElementById("ShowDiv3").style.display = "none";
                document.getElementById("ShowDiv4").style.display = "none";
                document.getElementById("ShowDiv5").style.display = "none";

                document.getElementById("divByDealer_HelpSection").style.display = "block";
                document.getElementById("divByConveyorModel_HelpSection").style.display = "none";
                document.getElementById("divByStates_HelpSection").style.display = "none";
                document.getElementById("divByConsultant_HelpSection").style.display = "none";
                document.getElementById("divBySalesRep_HelpSection").style.display = "none";
                document.getElementById("divByConveyorType_HelpSection").style.display = "none";
            }
                //By Consultant
            else if (getSelectValue == '3') {
                document.getElementById("ShowDiv3").style.display = "block";
                document.getElementById("ShowDiv0").style.display = "none";
                document.getElementById("ShowDiv1").style.display = "none";
                document.getElementById("ShowDiv2").style.display = "none";
                document.getElementById("ShowDiv4").style.display = "none";
                document.getElementById("ShowDiv5").style.display = "none";

                document.getElementById("divByConsultant_HelpSection").style.display = "block";
                document.getElementById("divByDealer_HelpSection").style.display = "none";
                document.getElementById("divByConveyorModel_HelpSection").style.display = "none";
                document.getElementById("divByStates_HelpSection").style.display = "none";
                document.getElementById("divBySalesRep_HelpSection").style.display = "none";
                document.getElementById("divByConveyorType_HelpSection").style.display = "none";
            }
                //By Sales Rep
            else if (getSelectValue == '4') {
                document.getElementById("ShowDiv4").style.display = "block";
                document.getElementById("ShowDiv0").style.display = "none";
                document.getElementById("ShowDiv1").style.display = "none";
                document.getElementById("ShowDiv2").style.display = "none";
                document.getElementById("ShowDiv3").style.display = "none";
                document.getElementById("ShowDiv5").style.display = "none";

                document.getElementById("divBySalesRep_HelpSection").style.display = "block";
                document.getElementById("divByConsultant_HelpSection").style.display = "none";
                document.getElementById("divByDealer_HelpSection").style.display = "none";
                document.getElementById("divByConveyorModel_HelpSection").style.display = "none";
                document.getElementById("divByStates_HelpSection").style.display = "none";
                document.getElementById("divByConveyorType_HelpSection").style.display = "none";
            }
                //By Conveyor Type
            else if (getSelectValue == '5') {
                document.getElementById("ShowDiv5").style.display = "block";
                document.getElementById("ShowDiv0").style.display = "none";
                document.getElementById("ShowDiv1").style.display = "none";
                document.getElementById("ShowDiv2").style.display = "none";
                document.getElementById("ShowDiv3").style.display = "none";
                document.getElementById("ShowDiv4").style.display = "none";

                document.getElementById("divByConveyorType_HelpSection").style.display = "block";
                document.getElementById("divBySalesRep_HelpSection").style.display = "none";
                document.getElementById("divByConsultant_HelpSection").style.display = "none";
                document.getElementById("divByDealer_HelpSection").style.display = "none";
                document.getElementById("divByConveyorModel_HelpSection").style.display = "none";
                document.getElementById("divByStates_HelpSection").style.display = "none";
            }
        }

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            DDLName();

        }
        $.when.apply($, PageLoaded).then(function () {
            DDLName();
            helpSectionInitialState();
        });

        function helpSectionInitialState() {
            document.getElementById("ShowDiv0").style.display = "block";
            document.getElementById("divByStates_HelpSection").style.display = "block";
            document.getElementById("divByConveyorModel_HelpSection").style.display = "none";
            document.getElementById("divByDealer_HelpSection").style.display = "none";
            document.getElementById("divByConsultant_HelpSection").style.display = "none";
            document.getElementById("divBySalesRep_HelpSection").style.display = "none";
            document.getElementById("divByConveyorType_HelpSection").style.display = "none";
        }

        function DDLName() {
            $('#<%=ddlCountry.ClientID%>').chosen();
            $('#<%=ddlRep.ClientID%>').chosen();
            $('#<%=ddlDealer.ClientID%>').chosen();
            $('#<%=ddlConsultant.ClientID%>').chosen();
            $('#<%=ddlModel.ClientID%>').chosen();
            $('#<%=ddlType.ClientID%>').chosen();
        }
    </script>
</asp:Content>
