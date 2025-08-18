<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmFabricationChinaDailyReport.aspx.cs" Inherits="Reports_FrmFabricationChinaDailyReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content_Projects_Eng" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_Projects_Eng" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-8">
                        <!-- Main content area -->
                        <!-- Your main content here -->
                        <div class="col-md-auto mx-auto innerMain">
                            <div class="row pt-3 flex-column">
                                <div class="col-12">
                                    <h4 class="title-hyphen position-relative mb-3">Fabrication China Daily Report</h4>
                                </div>
                                <div class="col-12">
                                    <div class="row">
                                        <div class="col-4">
                                            <div class="form-group chosenFullWidth">
                                                <label>Issued For</label>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlIssued" runat="server">
                                                    <asp:ListItem Value="">All</asp:ListItem>
                                                    <asp:ListItem Value="D">Drawings</asp:ListItem>
                                                    <asp:ListItem Value="P">Production</asp:ListItem>
                                                    <asp:ListItem Value="B">Drawings and Production</asp:ListItem>
                                                    <%-- Value=B for BOTH --%>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-12 pt-2">
                                            <div class="form-group mb-0 flex-column">
                                                <div>
                                                    <asp:Button ID="btnGenerateReport" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';"
                                                        Text="Preview Report" OnClick="btnGenerateReport_Click" />
                                                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-4">
                        <!-- Help section on the right -->
                        <div class="row pt-3">
                            <div class="d-flex align-items-center mb-2">
                                <h4>
                                    <strong>Help Section: </strong>
                                </h4>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divProposal_HelpSection">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Fabrication China Daily Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Projects which are <i>not</i> <strong>Completed, Shipped, Arrived</strong> are shown in the report.</li>
                                        <li>Projects which are <strong>Active, confirmed</strong> are shown in the report.</li>
                                        <li>Projects are also filtered according to <i>Issued For</i> Dropdown.</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerateReport" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptFabricationChinaDailyReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%"
        EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlIssued.ClientID%>').chosen();
        }
    </script>
</asp:Content>
