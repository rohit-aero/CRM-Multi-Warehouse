<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmTragenflex.aspx.cs" Inherits="Reports_frmTragenflex" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-auto mx-auto innerMain">
        <div class=" col-7 row pt-3 flex-column">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Tragenflex Report</h4>
                <%-- <h5 class="text-uppercase">Select Filters</h5>--%>
            </div>
            <%--            <div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
            <div class="col-12">
                <div class="row">
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <label>Start Date</label>
                            <asp:TextBox ID="txtFromDate" CssClass="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate"></asp:CalendarExtender>

                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <label>End Date</label>
                            <asp:TextBox ID="txtToDate" CssClass="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate"></asp:CalendarExtender>

                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group mb-0 flex-column">
                            <label>&nbsp;</label>
                            <div>
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnPreview" runat="server" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnPreview_Click" />
                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenExcel" runat="server" Text="Export to Excel" OnClick="btnGenExcel_Click" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="  row border-top pt-3">
            <div class=" col-7">
                <div class="col-12">
                    <h5 class="text-uppercase">Select Option</h5>
                </div>
                <div class="col-sm-12 col-md">
                    <div class="form-group srRadiosBtns">
                        <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large">
                            <asp:ListItem Value="1" Selected="True">YTD Sales Activity Report</asp:ListItem>
                            <asp:ListItem Value="2">Proposals</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnPreview" />
                    <asp:PostBackTrigger ControlID="btnGenExcel" />
                </Triggers>
            </asp:UpdatePanel>

            <div class="col-4">
                <div class="row ">
                    <div class="d-flex align-items-center">
                        <h5>
                            <strong>Help Section: </strong>
                        </h5>
                    </div>
                    <div class="col-12 pt-2" runat="server" id="divYTDSalesActivityReport_HelpSection">
                        <div class="d-flex align-items-center mb-2">
                            <h5>
                                <strong>YTD Sales Activity Report</strong>
                            </h5>
                        </div>
                        <div class="col-12">
                            <ul>
                                <li>Date is based on <strong>Job Order Date</strong>.</li>
                                <li><strong>P135682, P135695 & P135697</strong> projects are <strong>not</strong> shown the report.</li>
                                <li>Project belonging to <strong>TragenFlex</strong> are shown in the report.</li>
                                <li><strong>Active & Confirmed</strong> projects are shown in reports.</li>
                                <li runat="server" id="CADYTD" visible="false"><strong>Canada</strong> projects are shown in reports.</li>
                                <li runat="server" id="USYTD" visible="false"><strong>US</strong> projects are shown in reports.</li>
                            </ul>
                        </div>
                    </div>

                    <div class="col-12 pt-2" runat="server" id="div_Proposal_HelpSection">
                        <div class="d-flex align-items-center mb-2">
                            <h5>
                                <strong>Proposals</strong>
                            </h5>
                        </div>
                        <div class="col-12">
                            <ul>
                                <li>Date is based on <strong>Proposal Date</strong>.</li>
                                <li>Project belonging to <strong>TragenFlex</strong> are shown in the report.</li>
                                <li><strong>Active & Confirmed</strong> projects are shown in reports.</li>
                                <li runat="server" id="CADP" visible="false"><strong>Canada</strong> projects are shown in reports.</li>
                                <li runat="server" id="USP" visible="false"><strong>US</strong> projects are shown in reports.</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hf" runat="server" Value="-1" />
    <CR:CrystalReportViewer ID="rptTrimark" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
