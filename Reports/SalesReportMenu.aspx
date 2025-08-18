<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="SalesReportMenu.aspx.cs" Inherits="Reports_SalesReportMenu" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_HobartSummaryAndDetailReport" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Reports Menu</h4>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 row">
                <div class="col-12">
                    <h5>Sales Reports</h5>
                </div>
                <div class="col-12">
                    <a runat="server" class="btn btn-outline-dark btn-sm" style="width: 200px;" href="../Reports/SalesRepGroup.aspx" target="_blank">Hobart US</a>
                    <a runat="server" class="btn btn-outline-dark btn-sm" style="width: 200px;" href="../Reports/rptHobartCanadaSale.aspx" target="_blank">Hobart Canada</a>
                    <%-- <a runat="server" class="btn btn-success btn-sm" href="../Reports/frmAeroYTDComparisionReport.aspx" target="_blank">Reps Performance</a>
                    <a runat="server" class="btn btn-primary btn-sm" href="../Reports/frmTragenflex.aspx" target="_blank">TragenFlex Report</a>--%>
                </div>
                <div class="col-12  mt-3">
                    <%--<a runat="server" class="btn btn-primary btn-sm" href="../Reports/SalesRepGroup.aspx" target="_blank">Hobart US</a>
                    <a runat="server" class="btn btn-secondary btn-sm" href="../Reports/rptHobartCanadaSale.aspx" target="_blank">Hobart Canada</a>--%>
                    <a runat="server" class="btn btn-outline-dark btn-sm" style="width: 200px;" href="../Reports/frmTragenflex.aspx?Country=US" target="_blank">TragenFlex US</a>
                    <a runat="server" class="btn btn-outline-dark btn-sm" style="width: 200px;" href="../Reports/frmTragenflex.aspx?Country=CANADA" target="_blank">TragenFlex Canada</a>
                </div>
                <div class="col mt-3 border">
                </div>
                <div class="col-12 mt-3">
                    <h5>Performance Reports</h5>
                </div>
                <div class="col-12">
                    <a runat="server" class="btn btn-outline-dark btn-sm" style="width: 200px;" href="../Reports/frmAeroYTDComparisionReport.aspx" target="_blank">Reps Performance</a>
                    <a runat="server" class="btn btn-outline-dark btn-sm" style="width: 200px;" href="../Reports/frmYTDDealerRebate.aspx" target="_blank">Dealers Performance</a>
                </div>
                <div class="col-12 mt-3">
                    <a runat="server" class="btn btn-outline-dark btn-sm" style="width: 200px;" href="../Reports/frmYTDConsultantProjects.aspx" target="_blank">Consultants Specfied Projects</a>
                </div>
                <div class="col mt-3 border">
                </div>
                <div class="col-12 mt-3">
                    <h5>Commission Reports</h5>
                </div>
                <div class="col-12">
                    <asp:Button Text="Monthly" runat="server" class="btn btn-outline-dark btn-sm" ID="ank1" Style="width: 200px;" OnClientClick="window.open('../Reports/frmAeroCommissions.aspx', '_blank');"></asp:Button>
                    <asp:Button Text="Quaterly" runat="server" class="btn btn-outline-dark btn-sm" ID="ank2" Style="width: 200px;" OnClientClick="window.open('../Reports/frmSpecCredit.aspx', '_blank');"></asp:Button>

                </div>
                <div class="col-12 mt-3">
                    <asp:Button Text="Yearly" runat="server" class="btn btn-outline-dark btn-sm" ID="ank3" Style="width: 200px;" OnClientClick="window.open('../Reports/frmDealerRebate.aspx', '_blank');"></asp:Button>
                    <asp:Button Text="Trimark" runat="server" class="btn btn-outline-dark btn-sm" ID="ank4" Style="width: 200px;" OnClientClick="window.open('../Reports/frmTrimark.aspx', '_blank');"></asp:Button>
                </div>
                <%-- <div class="col-12  mt-3">
                    
                </div>--%>
                <div class="col-12 mt-3" runat="server" id="ThirdRow">
                    <asp:Button Text="Hobart Sales & Commission" runat="server" class="btn btn-outline-dark btn-sm" ID="ank5" Style="width: 200px;" OnClientClick="window.open('../Reports/frmSalesandCommissionReport.aspx', '_blank');"></asp:Button>
                </div>
                <div class="col mt-3 border">
                </div>
                <div class="col-12 mt-3">
                    <h5>Other Reports</h5>
                </div>
                <div class="col-12">
                    <a runat="server" class="btn btn-outline-dark btn-sm" style="width: 200px;" href="../Reports/frmSalesReport.aspx" target="_blank">Miscellaneous</a>
                    <%--<a runat="server" class="btn btn-primary btn-sm" href="../Reports/frmSalesWeekly.aspx">Monthly Sales</a>
                    <a runat="server" class="btn btn-secondary btn-sm" href="../Reports/frmOpenProposals.aspx">Scheduled Followups</a>
                    <a runat="server" class="btn btn-success btn-sm" href="../Reports/frmSalesActivity.aspx">Sales Followups</a>
                    <a runat="server" class="btn btn-danger btn-sm" href="../Reports/frmAeroOrders.aspx">Orders Report</a>
                    <a runat="server" class="btn btn-primary btn-sm" href="../Reports/FrmPOWeeklyReport.aspx">Weekly Sales Activity Report</a>
                    <a runat="server" class="btn btn-secondary btn-sm" href="../Reports/frmAeroQuotes.aspx">Quotes Report</a>
                    <a runat="server" class="btn btn-success btn-sm" href="../Reports/frmChinaProjects.aspx">China Projects</a>--%>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
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

        }
    </script>
</asp:Content>
