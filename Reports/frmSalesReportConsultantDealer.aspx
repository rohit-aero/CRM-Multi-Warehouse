<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmSalesReportConsultantDealer.aspx.cs" Inherits="Reports_frmSalesReportConsultantDealer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-4 mx-auto">
        <div class="row pt-3">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Aerowerks Sales Comparison Report</h4>
            </div>
            <%--    <div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
            <div class="col-sm-6 col-md-6">
                <div class="form-group">
                    <label>Group by</label>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNestingStatus" runat="server">
                        <asp:ListItem Value="1">Dealer</asp:ListItem>
                        <asp:ListItem Value="2">Consultant</asp:ListItem>
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
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });
        function PageLoaded(sender, args) {
            DDL();
        }
        $.when.apply($, PageLoaded).then(function () {
            DDL();
        });
        function DDL() {
            $('#<%=ddlNestingStatus.ClientID%>').chosen();
        }
    </script>
</asp:Content>
