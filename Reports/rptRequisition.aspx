<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="rptRequisition.aspx.cs" Inherits="Reports_rptRequisition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-7 mx-auto">
        <div class="row pt-3">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Select Dates</h4>
            </div>
            <%-- <div class="col-12"><asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label></div>--%>
            <div class="col-sm-6 col-md-4">
                <div class="form-group">
                    <label>From Date</label>
                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFrom" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFrom"></asp:CalendarExtender>
                </div>
            </div>
            <div class="col-sm-6 col-md-4">
                <div class="form-group">
                    <label>To Date</label>
                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtTo" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal2" TargetControlID="txtTo"></asp:CalendarExtender>
                </div>
            </div>
            <div class="col-sm-6 col-md-4">
                <div class="form-group">
                    <label>&nbsp;</label>
                    <asp:Button CssClass="btn btn-success btn-sm btn-block" ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" CausesValidation="False" />
                </div>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-sm-12">
                <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
            </div>
        </div>
    </div>
</asp:Content>
