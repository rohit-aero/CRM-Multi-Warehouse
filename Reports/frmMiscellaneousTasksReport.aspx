<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="frmMiscellaneousTasksReport.aspx.cs" Inherits="Reports_frmMiscellaneousTasksReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Miscellaneous Tasks Filters</h5>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Company Name/Reference Number</label>
                            <asp:DropDownList ID="ddlCompanyName" runat="server" DataTextField="CompanyName" DataValueField="id" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Issue Date From</label>
                            <asp:TextBox ID="txtIssueDateFrom" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtIssueDateFrom_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtIssueDateFrom" TargetControlID="txtIssueDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Issue Date To</label>
                            <asp:TextBox ID="txtIssueDateTo" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtIssueDateTo_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtIssueDateTo" TargetControlID="txtIssueDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Solution Date From</label>
                            <asp:TextBox ID="txtSolutionDateFrom" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtSolutionDateFrom_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtSolutionDateFrom" TargetControlID="txtSolutionDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Solution Date To</label>
                            <asp:TextBox ID="txtSolutionDateTo" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtSolutionDateTo_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtSolutionDateTo" TargetControlID="txtSolutionDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-md-auto">
                               <asp:Button ID="btnExportToPDF" runat="server" CssClass="btn btn-info btn-sm" OnClientClick="window.document.forms[0].target='_blank';" CausesValidation="false" Text="Preview Report" OnClick="btnExportToPDF_Click" />                                
                                 <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                                <%--<asp:Button CssClass="btn btn-secondary btn-sm" ID="btnGenrate" runat="server" Text="Search" OnClick="btnSearch_Click" />--%>
                                <%--<asp:Button ID="btnExportToExcel" runat="server" Enabled="false" CssClass="btn btn-primary btn-sm" CausesValidation="false" Text="Export To Excel" OnClick="btnGenerateExcel" />--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="btnExportToExcel" />--%>
            <asp:PostBackTrigger ControlID="btnExportToPDF" />            
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            BindDrp();
        }

        $.when.apply($, PageLoaded).then(function () {
            BindDrp();
        });

        function BindDrp() {
            $('#<%=ddlCompanyName.ClientID%>').chosen();
        }
    </script>
    <CR:CrystalReportViewer ID="rptMiscellaneousTasks" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
