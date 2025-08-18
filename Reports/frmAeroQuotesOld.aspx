<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmAeroQuotesOld.aspx.cs" Inherits="Reports_frmAeroQuotesOld" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-4 mx-auto">
        <div class="row pt-3">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Aerowerks Quotes Report</h4>
            </div>
            <div class="col-12">
                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
            </div>
            <div class="col-sm-6 col-md-6">
                <div class="form-group">
                    <label id="lblFrom">Quote Req. Received Date From</label>
                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtProposalShipDateFrom" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtProposalShipDateFrom" TargetControlID="txtProposalShipDateFrom"></asp:CalendarExtender>
                </div>
            </div>
            <div class="col-sm-6 col-md-6">
                <div class="form-group">
                    <label id="lblTo">Quote Req. Received Date To</label>
                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtProposalShipDateTo" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtProposalShipDateTo" TargetControlID="txtProposalShipDateTo"></asp:CalendarExtender>
                </div>
            </div>
            <div class="col-sm-6 col-md-6">
                <div class="form-group">
                    <label>Report Type</label>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlType" runat="server" onchange="ChangeText();">
                        <asp:ListItem Value="0">Quote Report</asp:ListItem>
                        <asp:ListItem Value="1">Order Report</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-auto">
                <div class="form-group">
                    <asp:Button ID="btnSearchProposal" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnSearchProposal_Click" />
                    <asp:Button ID="btnExportExcel" runat="server" CssClass="btn btn-info btn-sm" Text="Export to Excel" CausesValidation="false" OnClick="btnExportExcel_Click" />
                    <asp:Button ID="btnClearProposal" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClearProposal_Click" />
                </div>
            </div>
        </div>
    </div>
    <CR:CrystalReportViewer ID="rptSalesRepGroup" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script type="text/javascript">
        function ChangeText() {
            var typename = document.getElementById('<%=ddlType.ClientID%>').value;
            if (typename == "0") {
                document.getElementById('lblFrom').innerHTML = "Quote Req. Received Date From";
                document.getElementById('lblTo').innerHTML = "Quote Req. Received Date To";
            }
            else {
                document.getElementById('lblFrom').innerHTML = "PO Received Date From";
                document.getElementById('lblTo').innerHTML = "PO Received Date To";
            }
        }
    </script>
</asp:Content>
