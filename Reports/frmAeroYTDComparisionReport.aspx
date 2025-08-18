<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="frmAeroYTDComparisionReport.aspx.cs" Inherits="Reports_frmAeroYTDComparisionReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-auto mx-auto innerMain">
        <div class="row pt-3 flex-column">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Aerowerks YTD Comparision Report Form</h4>
                <%--<h5 class="text-uppercase">Select Filters</h5>--%>
            </div>
            <%--            <div class="col-12">
                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
            </div>--%>
            <div class="col-12">
                <div class="row">
                    <div class="col-12">
                        <h5 class="text-uppercase">Select Option</h5>
                    </div>
                    <div class="col-sm-12 col-md">
                        <asp:DropDownList ID="ddlOptions" runat="server" onchange="ShowHideDives(this.value)">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">Sales by TSM</asp:ListItem>
                            <asp:ListItem Value="3">Sales by Hobart Regions</asp:ListItem>
                            <asp:ListItem Value="4">Sales by Rep Groups</asp:ListItem>
                            <asp:ListItem Value="6">Sales by Rep Groups (Grouped by Dealers)</asp:ListItem>
                            <%--<asp:ListItem Value="5">Spec Credit by Rep Groups</asp:ListItem>
                                <asp:ListItem Value="7">Orders Report by Rep Groups</asp:ListItem>
                                <asp:ListItem Value="8">Opportunities and Jobs not Shipped Report by Rep Groups</asp:ListItem>
                                <asp:ListItem Value="9">Opportunities Report by Rep Groups</asp:ListItem>
                                <asp:ListItem Value="10">Opportunities Report by Hobart Regions</asp:ListItem>
                                <asp:ListItem Value="11">Consultant Summary Report By Value</asp:ListItem>
                                <asp:ListItem Value="13">Consultant Summary Report By State</asp:ListItem>
                                <asp:ListItem Value="12">Consultant Detailed Report</asp:ListItem>
                                <asp:ListItem Value="14">Dealer Summary Report By State</asp:ListItem>
                                <asp:ListItem Value="15">Dealer Detailed Report</asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div style="text-align: center; display: none" id="ShowDiv" runat="server">
            <div class="col-sm-auto">
                <div class="form-group chosenFullWidth  text-left">
                    <asp:Label ID="lblDealers" runat="server" Text="Select TSM"></asp:Label>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSalesbyAllTSM" runat="server" DataTextField="TSM" DataValueField="RepID"></asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-auto">
                <div class="form-group chosenFullWidth text-left">
                    <label>Select Year</label>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSalesbyTSMYear" DataTextField="Year" DataValueField="Year" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div style="text-align: center; display: none" id="ShowDivSalesRep" runat="server">
            <div class="col-sm-auto">
                <div class="form-group chosenFullWidth text-left">
                    <label>Product Line</label>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductLineList" runat="server" DataTextField="Name" DataValueField="ID" Onchange="ShowRepGroup();">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-auto">
                <div class="form-group chosenFullWidth  text-left">
                    <asp:Label ID="Label1" runat="server" Text="Select Rep Group"></asp:Label>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSalesRep" runat="server" DataTextField="Name" DataValueField="ID">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group chosenFullWidth text-left">
                <label>Select Year</label>
                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRepGroupYear" DataTextField="Year" DataValueField="Year" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div style="text-align: center; display: none" id="divSalesRepbyAll" runat="server">
            <div class="col-sm-auto">
                <div class="form-group chosenFullWidth  text-left">
                    <asp:Label ID="Label3" runat="server" Text="Select Rep Group"></asp:Label>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSaleRepAll" DataTextField="Name" DataValueField="ID" runat="server">
                        <%-- <asp:ListItem Value="0">All</asp:ListItem>
                        <asp:ListItem Value="1">Premier Marketing Group</asp:ListItem>
                        <asp:ListItem Value="2">Burlis-Lawson Group</asp:ListItem>
                        <asp:ListItem Value="3">PMR</asp:ListItem>
                        <asp:ListItem Value="5">HRI</asp:ListItem>
                        <asp:ListItem Value="6">PBAC</asp:ListItem>
                        <asp:ListItem Value="7">Woolsey Associates</asp:ListItem>
                        <asp:ListItem Value="8">EPI</asp:ListItem>
                        <asp:ListItem Value="9">KLH</asp:ListItem>
                        <asp:ListItem Value="10">Squier</asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
                <div class="form-group chosenFullWidth text-left">
                    <label>Select Year</label>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSaleRepAllYear" DataTextField="Year" DataValueField="Year" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div style="display: none" id="divOrders" runat="server">
            <div class="row">
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Start Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>End Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtEndDate" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtEndDate"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Select Rep Group</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOrders" runat="server">
                            <asp:ListItem Value="0">All</asp:ListItem>
                            <asp:ListItem Value="1">Premier Marketing Group</asp:ListItem>
                            <asp:ListItem Value="2">Burlis-Lawson Group</asp:ListItem>
                            <asp:ListItem Value="3">PMR</asp:ListItem>
                            <asp:ListItem Value="5">HRI</asp:ListItem>
                            <asp:ListItem Value="6">PBAC</asp:ListItem>
                            <asp:ListItem Value="7">Woolsey Associates</asp:ListItem>
                            <asp:ListItem Value="8">EPI</asp:ListItem>
                            <asp:ListItem Value="9">KLH</asp:ListItem>
                            <asp:ListItem Value="10">Squier</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div style="display: none" id="divOppertunity" runat="server">
            <div class="row">
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Start Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtOpperStart" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtOpperStart"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>End Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtOpperEnd" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtOpperEnd"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Select Rep Group</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOppertunity" runat="server">
                            <asp:ListItem Value="0">All</asp:ListItem>
                            <asp:ListItem Value="12">Premier Marketing Group</asp:ListItem>
                            <asp:ListItem Value="13">Burlis-Lawson Group</asp:ListItem>
                            <asp:ListItem Value="14">PMR</asp:ListItem>
                            <asp:ListItem Value="15">HRI</asp:ListItem>
                            <asp:ListItem Value="16">PBAC</asp:ListItem>
                            <asp:ListItem Value="17">Woolsey Associates</asp:ListItem>
                            <asp:ListItem Value="18">EPI</asp:ListItem>
                            <asp:ListItem Value="19">KLH</asp:ListItem>
                            <asp:ListItem Value="20">Squier</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div style="display: none" id="divTopOpper" runat="server">
            <div class="row">
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Select No. of Records</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRecCount" runat="server">
                            <asp:ListItem Value="10">Top 10</asp:ListItem>
                            <asp:ListItem Value="15">Top 15</asp:ListItem>
                            <asp:ListItem Value="20">Top 20</asp:ListItem>
                            <asp:ListItem Value="25">Top 25</asp:ListItem>
                            <asp:ListItem Value="30">Top 30</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Start Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtTopOpperStart" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender9" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtTopOpperStart" TargetControlID="txtTopOpperStart"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>End Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtTopOpperEnd" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender10" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtTopOpperEnd" TargetControlID="txtTopOpperEnd"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Select Rep Group</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTopOpper" runat="server">
                            <asp:ListItem Value="12">Premier Marketing Group</asp:ListItem>
                            <asp:ListItem Value="13">Burlis-Lawson Group</asp:ListItem>
                            <asp:ListItem Value="14">PMR</asp:ListItem>
                            <asp:ListItem Value="15">HRI</asp:ListItem>
                            <asp:ListItem Value="16">PBAC</asp:ListItem>
                            <asp:ListItem Value="17">Woolsey Associates</asp:ListItem>
                            <asp:ListItem Value="18">EPI</asp:ListItem>
                            <asp:ListItem Value="19">KLH</asp:ListItem>
                            <asp:ListItem Value="20">Squier</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div style="text-align: center; display: none" id="divSalesHobart" runat="server">
            <div class="col-sm-auto">
                <div class="form-group chosenFullWidth  text-left">
                    <asp:Label ID="Label2" runat="server" Text="Select Hobart Region"></asp:Label>
                    <asp:DropDownList CssClass="form-control form-control-sm" DataTextField="Region" DataValueField="RegionID" ID="ddlHobartSalesRep" runat="server">
                        <%-- <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="1">Hobart North</asp:ListItem>
                        <asp:ListItem Value="2">Hobart South</asp:ListItem>
                        <asp:ListItem Value="3">Hobart West</asp:ListItem>
                        <asp:ListItem Value="4">Hobart Midwest</asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-auto">
                <div class="form-group chosenFullWidth text-left">
                    <label>Select Year</label>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlHobartRegionYear" DataTextField="Year" DataValueField="Year" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div style="display: none" id="divOpperHobart" runat="server">
            <div class="row">
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Select No. of Records</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTopHobart" runat="server">
                            <asp:ListItem Value="10">Top 10</asp:ListItem>
                            <asp:ListItem Value="15">Top 15</asp:ListItem>
                            <asp:ListItem Value="20">Top 20</asp:ListItem>
                            <asp:ListItem Value="25">Top 25</asp:ListItem>
                            <asp:ListItem Value="30">Top 30</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Start Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtOpperFrom" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtOpperFrom"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>End Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtOpperTo" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender6" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtOpperTo"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Select Hobart Region</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOppRegion" runat="server">
                            <asp:ListItem Value="1">Hobart North</asp:ListItem>
                            <asp:ListItem Value="2">Hobart South</asp:ListItem>
                            <asp:ListItem Value="3">Hobart West</asp:ListItem>
                            <asp:ListItem Value="4">Hobart Midwest</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div style="display: none" id="dvCon" runat="server">
            <div class="row">
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Select No. of Records</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTopCon" runat="server">
                            <asp:ListItem Value="10">Top 10</asp:ListItem>
                            <asp:ListItem Value="15">Top 15</asp:ListItem>
                            <asp:ListItem Value="20">Top 20</asp:ListItem>
                            <asp:ListItem Value="25">Top 25</asp:ListItem>
                            <asp:ListItem Value="30">Top 30</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Start Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtConFrom" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender7" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtConFrom" TargetControlID="txtConFrom"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>End Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtConTo" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender8" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtConTo" TargetControlID="txtConTo"></asp:CalendarExtender>
                    </div>
                </div>
            </div>
        </div>
        <div style="display: none" id="dvDealers" runat="server">
            <div class="row">
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Select No. of Records</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTopConDealer" runat="server" onchange="showDivDealers();">
                            <asp:ListItem Value="*">All</asp:ListItem>
                            <asp:ListItem Value="">Custom Value</asp:ListItem>
                            <asp:ListItem Value="10">Top 10</asp:ListItem>
                            <asp:ListItem Value="15">Top 15</asp:ListItem>
                            <asp:ListItem Value="20">Top 20</asp:ListItem>
                            <asp:ListItem Value="25">Top 25</asp:ListItem>
                            <asp:ListItem Value="30">Top 30</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>No of Records</label>
                        <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtNoOfRecs" autocomplete="off" onkeypress="return onlyNumbers(event);" MaxLength="4" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>Start Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtDealerStartDate" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender11" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDealerStartDate" TargetControlID="txtDealerStartDate"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="col-sm-auto">
                    <div class="form-group">
                        <label>End Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtDealerEndDate" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender12" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDealerEndDate" TargetControlID="txtDealerEndDate"></asp:CalendarExtender>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-12">
            <div class="form-group mb-0 flex-column">
                <label>&nbsp;</label>
                <div>
                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnGenrate_Click" />
                    <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" CausesValidation="false" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
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
            <div class="col-12 pt-2" runat="server" id="divComparisionReport_TSM_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Sales By TSM</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                        <li><strong>US</strong> projects are shown in the report.</li>
                        <li><strong>USD</strong> currency projects are shown in the report.</li>
                        <li>Projects with <strong>NetEqPrice</strong> <i>greater then</i> <strong>zero </strong>are shown in the report.</li>
                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                        <li>Projects with <i>Selected</i> rep are shown in the report.</li>
                        <li>Projects which has rep <strong>Tom Letizia</strong> are not shown in the report.</li>
                        <li>Projects which are <strong>Active</strong> and <strong>Confirmed</strong> are shown in the report.</li>
                        <li>In case of all reps selected, only active reps will be listed in the report.</li>
                        <li>In case of all reps selected, branch which contains company name <strong>"Hobart"</strong> will be included in the report.</li>
                    </ul>
                </div>
            </div>

            <div class="col-12 pt-2" runat="server" id="divComparision_HobartRegions_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Sales By Hobart Regions</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                        <li><strong>US</strong> projects are shown in the report.</li>
                        <li><strong>USD</strong> currency projects are shown in the report.</li>
                        <li>Projects with <strong>NetEqPrice</strong> <i>greater then</i> <strong>zero </strong>are shown in the report.</li>
                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                        <li>Projects with <i>Selected</i> rep are shown in the report.</li>
                        <li>Projects which has rep <strong>Tom Letizia</strong> are not shown in the report.</li>
                        <li>Projects which are <strong>Active</strong> and <strong>Confirmed</strong> are shown in the report.</li>
                    </ul>
                </div>
            </div>

            <div class="col-12 pt-2" runat="server" id="divComparision_RepGroup_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Sales By Rep Groups</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                        <li><strong>US</strong> projects are shown in the report.</li>
                        <li><strong>USD</strong> currency projects are shown in the report.</li>
                        <li>Projects with <strong>NetEqPrice</strong> <i>greater then</i> <strong>zero </strong>are shown in the report.</li>
                        <%--<li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>--%>
                        <li>Projects with <i>Selected</i> rep are shown in the report.</li>
                        <li>Projects which has rep <strong>Tom Letizia</strong> are not shown in the report.</li>
                        <li>Projects which are <strong>Active</strong> and <strong>Confirmed</strong> are shown in the report.</li>
                    </ul>
                </div>
            </div>

            <div class="col-12 pt-2" runat="server" id="divComparision_RepGroupByDealer_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Sales By Rep Groups (Grouped by Dealer)</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                        <li><strong>US</strong> projects are shown in the report.</li>
                        <li><strong>USD</strong> currency projects are shown in the report.</li>
                        <li>Projects with <strong>NetEqPrice</strong> <i>greater then</i> <strong>zero </strong>are shown in the report.</li>
                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                        <li>Projects with <i>Selected</i> rep are shown in the report.</li>
                        <li>Projects which has rep <strong>Tom Letizia</strong> are not shown in the report.</li>
                        <li>Projects which are <strong>Active</strong> and <strong>Confirmed</strong> are shown in the report.</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script language="javascript" type="text/javascript">
        function ShowRepGroup() {
            var el = document.getElementById('<%= ddlProductLineList.ClientID %>').value;
            var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value = 4;
            var param = { ProductLineId: el };
            $.ajax({
                url: "../Reports/frmAeroYTDComparisionReport.aspx/ddlProductLineList_SelectedIndexChanged",
                data: JSON.stringify(param),
                datatype: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //dataFilter: function (data) { return data; },
                success: function (data) {
                    const info = JSON.stringify(data.d);
                    var obj = JSON.parse(info, function (key, value) {
                        var ddlSalesRep = $("[id*=ddlSalesRep]");
                        ddlSalesRep.empty().append('<option value="0">ALL</option>');
                        $.each(data.d, function () {
                            ddlSalesRep.append($("<option></option>").val(this['ID']).html(this['Name']));
                        });
                    })
                },
                error: function (error) {
                    alert("error");
                }
            })

            ShowHideDives();
        }
        function ShowHideDives() {
            showDiv(); showDivSalesbyRep(); showDivSalesbyRepHoabrt(); showDivSalesbyRepAll(); showDivSpecCreditbyRepGroups;
            showDivOrders(); showDivOppertunity(); showDivTopOppertunity(); showDivOpperByHoabrt();
            showDivOpperByHoabrtNew(); showDivDealers(); HelpSectionHandler();
        }

        function HelpSectionHandler() {
            var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
            if (getSelectValue == "0") {
                document.getElementById('<%=divComparisionReport_TSM_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_HobartRegions_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_RepGroup_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_RepGroupByDealer_HelpSection.ClientID%>').style.display = "none";
            } else if (getSelectValue == "1") {
                document.getElementById('<%=divComparisionReport_TSM_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divComparision_HobartRegions_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_RepGroup_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_RepGroupByDealer_HelpSection.ClientID%>').style.display = "none";
            } else if (getSelectValue == "3") {
                document.getElementById('<%=divComparisionReport_TSM_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_HobartRegions_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divComparision_RepGroup_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_RepGroupByDealer_HelpSection.ClientID%>').style.display = "none";
            } else if (getSelectValue == "4") {
                document.getElementById('<%=divComparisionReport_TSM_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_HobartRegions_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_RepGroup_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divComparision_RepGroupByDealer_HelpSection.ClientID%>').style.display = "none";
            } else if (getSelectValue == "6") {
                document.getElementById('<%=divComparisionReport_TSM_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_HobartRegions_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_RepGroup_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divComparision_RepGroupByDealer_HelpSection.ClientID%>').style.display = "block";
            }
}

function showDiv() {
    var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
    var div = document.getElementById('<%=ShowDiv.ClientID%>');
    if (getSelectValue == "1") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}

function showDivSalesbyRep() {
    var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
    var div = document.getElementById('<%=ShowDivSalesRep.ClientID%>');
    if (getSelectValue == "4") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}

function showDivSalesbyRepHoabrt() {
    var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
    var div = document.getElementById('<%=divSalesHobart.ClientID%>');
    if (getSelectValue == "3") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}

function showDivSalesbyRepAll() {
    var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
    var div = document.getElementById('<%=divSalesRepbyAll.ClientID%>');
    if (getSelectValue == "6") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}

function showDivSpecCreditbyRepGroups() {
    var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
    var div = document.getElementById('<%=divSalesRepbyAll.ClientID%>');
    if (getSelectValue == "5") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}

function showDivOrders() {
    var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
    var div = document.getElementById('<%=divOrders.ClientID%>');
    if (getSelectValue == "7") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}

function showDivOppertunity() {
    var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
    var div = document.getElementById('<%=divOppertunity.ClientID%>');
    if (getSelectValue == "8") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}
//divTopOpper
function showDivTopOppertunity() {
    var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
    var div = document.getElementById('<%=divTopOpper.ClientID%>');
    if (getSelectValue == "9") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}

function showDivOpperByHoabrt() {
    var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
    var div = document.getElementById('<%=divOpperHobart.ClientID%>');
    if (getSelectValue == "10") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}
function showDivOpperByHoabrtNew() {
    var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
    var div = document.getElementById('<%=dvCon.ClientID%>');
    if (getSelectValue == "11" || getSelectValue == "12" || getSelectValue == "13") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}
function showDivDealers() {
    debugger;
    var getSelectValue = document.getElementById('<%= ddlOptions.ClientID %>').value;
    var noofrec = document.getElementById('<%= ddlTopConDealer.ClientID %>').value;
    var div = document.getElementById('<%=dvDealers.ClientID%>');
    if (getSelectValue == "14" || getSelectValue == "15") {
        div.style.display = "block";
        if (noofrec != '') {
            document.getElementById('<%= txtNoOfRecs.ClientID %>').disabled = true;
                document.getElementById('<%= txtNoOfRecs.ClientID %>').value = '';
            }
            else {
                document.getElementById('<%= txtNoOfRecs.ClientID %>').disabled = false;
            }
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
        HelpSectionHandler();
    });
    function DDL() {
        $('#<%=ddlSalesbyAllTSM.ClientID%>').chosen();
            //$('#<%=ddlSalesRep.ClientID%>').chosen();
            $('#<%=ddlHobartSalesRep.ClientID%>').chosen();
            $('#<%=ddlSaleRepAll.ClientID%>').chosen();
            $('#<%=ddlOptions.ClientID%>').chosen();
            $('#<%=ddlProductLineList.ClientID%>').chosen();
            $('#<%=ddlRepGroupYear.ClientID%>').chosen();
            $('#<%=ddlSaleRepAllYear.ClientID%>').chosen();
            $('#<%=ddlHobartRegionYear.ClientID%>').chosen();
            $('#<%=ddlSalesbyTSMYear.ClientID%>').chosen();
            //$('#<%=ddlSalesRep.ClientID%>').chosen();
        }
    </script>
</asp:Content>
