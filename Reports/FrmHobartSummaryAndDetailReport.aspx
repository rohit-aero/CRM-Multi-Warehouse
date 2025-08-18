<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/main.master" CodeFile="FrmHobartSummaryAndDetailReport.aspx.cs" Inherits="Reports_FrmHobartSummaryAndDetailReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_HobartSummaryAndDetailReport" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Hobart Summary And Detail Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-2">
                        <div class="form-group">
                            <label>Year</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlYear" DataTextField="YearName" DataValueField="Year">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Report Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReportType" runat="server">
                                <asp:ListItem Value="D">Detail</asp:ListItem>
                                <asp:ListItem Value="S" Selected>Summary</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-5">
                        <label>&nbsp;</label>
                        <div class="row">
                            <div class="col-md-auto">
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnExportToPdf" CausesValidation="false" runat="server" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnExportToPdf_Click" />
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <h5>
                                <strong>Help Section: Detail & Summary Reports</strong>
                            </h5>
                        </div>
                    </div>

                    <div class="col-12">
                        <ul>
                            <li>Year is based on <strong>Ship Date</strong>.</li>
                            <li><strong>United States</strong> projects are shown in the report.</li>
                            <li><strong>USD</strong> currency projects are shown in the report.</li>
                            <li>Projects with <strong>Net Eq Price($)</strong><i> Greater then zero</i> are shown in the report.</li>
                            <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                            <li>Projects which are <strong>Active</strong> and <strong>Confirmed</strong> are shown in the report.</li>
                            <li>Projects which has rep <strong>Tom Letizia</strong> are not shown in the report.</li>
                        </ul>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToPdf" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptHobartSummaryAndDetail" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlYear.ClientID%>').chosen();
            $('#<%=ddlReportType.ClientID%>').chosen();
        }
    </script>
</asp:Content>
