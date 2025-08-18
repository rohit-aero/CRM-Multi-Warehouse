<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="AerowerksSalesReportForm.aspx.cs" Inherits="Reports_AerowerksSalesReportForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-auto mx-auto innerMain">
        <div class="row pt-3 flex-column">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Total Hobart Sales</h4>
            </div>
            <%--            <div class="col-12">
                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
            </div>--%>
            <div class="col-12 row">
                <div class="row col-7">
                    <div class="col-sm-auto">
                        <div class="form-group mb-0">
                            <label>Start Date</label>
                            <asp:TextBox ID="txtFromDate" CssClass="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group mb-0">
                            <label>End Date</label>
                            <asp:TextBox ID="txtToDate" CssClass="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group mb-0 flex-column">
                            <label class="">&nbsp;</label>
                            <div>
                                <asp:Button ID="btnGenrate" CssClass="btn btn-success btn-sm" runat="server" CausesValidation="false" OnClientClick="NewWindow();" Text="Preview Report" OnClick="btnGenrate_Click" />
                                <asp:Button ID="btnGenerateExcel" CssClass="btn btn-info btn-sm" CausesValidation="false" runat="server" Text="Export to Excel" OnClick="btnGenerateExcel_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-5 pl-0">
                    <div class="row">
                        <div class="col-12 pt-2">
                            <div class="d-flex align-items-center mb-2">
                                <h5>
                                    <strong>Help Section</strong>
                                </h5>
                            </div>
                        </div>

                        <div class="col-12">
                            <ul>
                                <li>Date is based on <strong>Invoice Date</strong>.</li>
                                <li><strong>Active & Confirmed</strong> projects are shown in reports.</li>
                                <li>Projects with <strong>NetEqPrice</strong> <i>greater then</i> <strong>zero </strong>are shown in the report.</li>
                                <li>Projects with currency <strong>USD</strong> <i>OR</i> <strong>CAD</strong> are shown in the report.</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
