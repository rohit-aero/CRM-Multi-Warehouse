<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="PreventativeMaintenanceCallLogsReport.aspx.cs" Inherits="Reports_PreventativeMaintenanceCallLogsReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Preventative Maintenance Call Logs Filters</h5>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>JobID/Job Name Search</label>
                            <asp:TextBox ID="txtJob" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Called From</label>
                            <asp:TextBox ID="txtDateCalledFrom" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtDateCalledFrom_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtDateCalledFrom" TargetControlID="txtDateCalledFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Called To</label>
                            <asp:TextBox ID="txtDateCalledTo" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtDateCalledTo_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtDateCalledTo" TargetControlID="txtDateCalledTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-md-auto">
                                <asp:Button ID="btnExportToPDF" runat="server" CssClass="btn btn-info btn-sm" OnClientClick="window.document.forms[0].target='_blank';" CausesValidation="false" Text="Preview Report" OnClick="btnExportToPDF_Click" />
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToPDF" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptPreventativeMaintenanceCallLogs" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
