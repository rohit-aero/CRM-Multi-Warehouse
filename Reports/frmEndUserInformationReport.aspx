<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmEndUserInformationReport.aspx.cs" Inherits="Reports_frmEndUserInformationReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-12 pt-2 border-bottom piDiv position-sticky py-3">
        <div class="row">
            <div class="col-sm-12 col-md-12 mx-auto">
                <div class="row">
                    <div class="col-12">
                        <h4 class="title-hyphen position-relative mb-3">End User Information Report</h4>
                    </div>
                </div>
                <%--                        <div class="row">
                            <div class="col-12">
                                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
                            </div>
                        </div>--%>
                <div class="row">
                    <div class="col-sm-2">
                        <div class="row">
                            <label class="col-12">Start Date</label>
                            <div class="col">
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="row">
                            <label class="col-12">End Date</label>
                            <div class="col">
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtToDate"
                                    TargetControlID="txtToDate">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm">
                        <div class="row">
                            <label class="col-12">&nbsp;</label>
                            <div class="col-12">
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Search" OnClick="btnGenrate_Click" />
                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" CausesValidation="false" runat="server" Enabled="false" Text="Export to Excel" OnClick="btnGenerateExcel_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-12 mt-3">
        <div class="table-responsive eoeTable" style="height: 750px">
            <asp:GridView ID="gvSearch" runat="server" CellPadding="3" EmptyDataText="No Items Found" Width="100%" CssClass="table mainGridTable table-sm"
                EnableModelValidation="True">
            </asp:GridView>
        </div>
    </div>
    <CR:CrystalReportViewer ID="rptTrimark" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>

